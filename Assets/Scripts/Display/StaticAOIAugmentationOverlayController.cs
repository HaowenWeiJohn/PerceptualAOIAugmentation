using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StaticAOIAugmentationOverlayController : MonoBehaviour
{

    public GameObject polygon;
    public GameObject polygonFast;
    public DisplayCoordinateController displayCoordinateController;
    public TargetImageController targetImageController;

    public Vector3[,] patchCenterPositions;

    // Start is called before the first frame update
    void Start()
    {
        getPatchCenterPositions();
        constructPolygon();
        constructPolygonFast();

    }

    // Update is called once per frame
    void Update()
    {
        float updateFrequency = 1.0f / Time.deltaTime;
        Debug.Log("Update Frequency: " + updateFrequency + " FPS");
    }



    void getPatchCenterPositions()
    {
        patchCenterPositions = GeneralUtils.getPatchCenterPositions(
            targetImageController.width, 
            targetImageController.height, 
            targetImageController.localPosition, 
            Presets.AttentionGridShape, 
            Presets.OriginalImageShape);
    }

    void constructPolygonFast()
    {

        for (int i = 0; i < Presets.AttentionGridShape[0]; i++)
        {
            for (int j = 0; j < Presets.AttentionGridShape[1]; j++)
            {
                GameObject circle = Instantiate(polygonFast, patchCenterPositions[i, j], Quaternion.identity);
                circle.transform.SetParent(transform);
                circle.transform.localPosition = patchCenterPositions[i, j];
                circle.transform.localScale = polygonFast.transform.localScale;

            }
        }
    }



    void constructPolygon()
    {

        for (int i = 0; i < Presets.AttentionGridShape[0]; i++)
        {
            for (int j = 0; j < Presets.AttentionGridShape[1]; j++)
            {
                GameObject circle = Instantiate(polygon, patchCenterPositions[i, j], Quaternion.identity);
                circle.transform.SetParent(transform);
                circle.transform.localPosition = patchCenterPositions[i, j];
                circle.transform.localScale = polygon.transform.localScale;
                circle.SetActive(false);

            }
        }
    }





}
