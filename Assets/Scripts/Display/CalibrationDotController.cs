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

    [Header("Calibration Result")]
    public GameObject resultPrefab;


    private Vector3 initialScale = new Vector3(10, 10, 10);
    private Vector3 targetScale;
    private Vector2 dotPosition;
    private Camera cam;
    private bool isScaling = false;

    private List<Vector3> calibrationResults = new List<Vector3>();
    private int index = 0;
    private bool complete = false;

    private void Start()
    {
        cam = GetComponent<Camera>();
        targetScale = new Vector3(endRadius, endRadius, endRadius);
        dotPosition = new Vector2(transform.position.x, transform.position.y);
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 gazeOverlayPosition = new Vector2(gazeOverlay.position.x, gazeOverlay.position.y);
        if (Vector2.Distance(dotPosition, gazeOverlayPosition) < calibrationRadius)
        {
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
            complete = true;    
        }
    }

    public void Reset()
    {
        dot.localScale = initialScale;
        complete = false;
        gameObject.SetActive(false);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public bool isComplete()
    {
        return complete;
    }




}
