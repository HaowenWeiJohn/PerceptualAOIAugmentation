using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
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

    public List<GameObject> polygonList = new List<GameObject>();
    public List<GameObject> polygonFastList = new List<GameObject>();
    public StaticAOIAugmentationStateLSLInletController staticAOIAugmentationStateLSLInletController;


    // Start is called before the first frame update
    void Start()
    {
        targetImageController.updateTargetImageInfo();
        getPatchCenterPositions();
        constructPolygon();
        constructPolygonFast();

    }

    // Update is called once per frame
    void Update()
    {
        float updateFrequency = 1.0f / Time.deltaTime;
        //Debug.Log("Update Frequency: " + updateFrequency + " FPS");
        updatePolygonVisualization();
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
                GameObject polygonFastInstance = Instantiate(polygonFast, patchCenterPositions[i, j], Quaternion.identity);
                polygonFastInstance.transform.SetParent(transform);
                polygonFastInstance.transform.localPosition = patchCenterPositions[i, j];
                polygonFastInstance.transform.localScale = polygonFast.transform.localScale;

                polygonFastList.Add(polygonFastInstance);

            }
        }
    }



    void constructPolygon()
    {

        for (int i = 0; i < Presets.AttentionGridShape[0]; i++)
        {
            for (int j = 0; j < Presets.AttentionGridShape[1]; j++)
            {
                GameObject polygonInstance = Instantiate(polygon, patchCenterPositions[i, j], Quaternion.identity);
                polygonInstance.transform.SetParent(transform);
                polygonInstance.transform.localPosition = patchCenterPositions[i, j];
                polygonInstance.transform.localScale = polygon.transform.localScale;
                polygonInstance.SetActive(false);

                polygonList.Add(polygonInstance);
            }
        }
    }

    
    void updatePolygonVisualization()
    {
        if (staticAOIAugmentationStateLSLInletController.activated)
        {
            if (staticAOIAugmentationStateLSLInletController.frameTimestamp != 0)
            {
                //Debug.Log("John");
                setPolyonVisualization(staticAOIAugmentationStateLSLInletController.frameDataBuffer);
            }
        }
    }

    void setPolyonVisualization(float[] polygonsState)
    {
        for (int i = 0; i < polygonsState.Length; i++)
        {
            if (polygonsState[i] == 1 && polygonList[i].activeSelf == false)
            {
                polygonList[i].SetActive(true);
            }
            else if (polygonsState[i] == 0 && polygonList[i].activeSelf == true)
            {
                polygonList[i].SetActive(false);
            }
        }
    }


    void disableAllPolygonFast()
    {
        foreach (var polygonFast in polygonFastList)
        {
            polygonFast.SetActive(false);
        }
    }

    void enableAllPolygonFast()
    {
        foreach (var polygonFast in polygonFastList)
        {
            polygonFast.SetActive(true);
        }
    }

    void disableAllPolygon()
    {
        foreach (var polygon in polygonList)
        {
            polygon.SetActive(false);
        }
    }

    // we cannot enable all polygons, this will kill the process!!!!

}
