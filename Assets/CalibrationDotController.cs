using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CalibrationDotController : MonoBehaviour
{
    [Header("Calibration Dots")]
    public float startRadius;
    public float endRadius;
    public Transform dot;

    [Header("Gaze Overlay")]
    public Transform gazeOverlay;

    [Header("Calibration Setting")]
    public float calibrationTime;
    public float calibrationRadius;

    [Header("Next Calibration Dot")]
    public GameObject nextCalibrationDot = null;

    public GameObject resultPrefab;


    private Vector3 initialScale = new Vector3(20, 20, 20);
    private Vector3 targetScale;
    private Vector2 dotPosition;
    private Camera cam;
    private bool isScaling = false;

    private List<Vector3> calibrationResults = new List<Vector3>();
    private int index = 0;

    private void Start()
    {
        cam = GetComponent<Camera>();
        initialScale = 
        targetScale = new Vector3(endRadius, endRadius, endRadius);//baseDot.localScale;
        dotPosition = new Vector2(transform.position.x, transform.position.y);
        
    }

    private void OnEnable()
    {
        Debug.Log("Reset calibration dot radius: " + initialScale);
        dot.localScale = initialScale;
    }


    // Update is called once per frame
    void Update()
    {

        Vector2 gazeOverlayPosition = new Vector2(gazeOverlay.position.x, gazeOverlay.position.y);
        Debug.Log("calibration positin: " + dotPosition);
        Debug.Log("distance: " + Vector2.Distance(dotPosition, gazeOverlayPosition));
        if (Vector2.Distance(dotPosition, gazeOverlayPosition) < calibrationRadius)
        {
            Debug.Log("Gaze Overlay reached dot");
            isScaling = true;
        }
        else
        {
            isScaling = false;
        }

        if(isScaling && dot.localScale.x < targetScale.x)
        {
            float i = (endRadius - startRadius) * Time.deltaTime / calibrationTime;
            dot.localScale += new Vector3(i, i, i);
            index += 1;
            if(index % 30 == 1)
            {
                calibrationResults.Add(gazeOverlay.position);
            }
        }

        if(dot.localScale.x > targetScale.x)
        {
            

            if (calibrationResults.Count != 0)
            {
                foreach (Vector3 position in calibrationResults)
                {
                    GameObject result = Instantiate(resultPrefab, position, Quaternion.identity);
                    result.transform.SetParent(transform);
                    result.transform.localScale = new Vector3(10f, 10f, 10f);
                    result.transform.localPosition = new Vector3(result.transform.localPosition.x, result.transform.localPosition.y, -4f);
                }
                calibrationResults.Clear();
            }
            if (nextCalibrationDot != null)
            {
                nextCalibrationDot.SetActive(true);
                gameObject.SetActive(false);
            }
            else
            {
                 GameObject[] results = GameObject.FindGameObjectsWithTag("CalibrationDot");
                foreach (GameObject result in results)
                {
                    result.SetActive(true);
                }
            }
        }
    }
}
