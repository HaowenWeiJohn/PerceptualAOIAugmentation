using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StaticAOIAugmentationOverlayController : GUIController
{


    public DisplayCoordinateController displayCoordinateController;
    public TargetImageController targetImageController;

    public AOIAugmentationAttentionContourStreamLSLInletController aOIAugmentationAttentionContourStreamLSLInletController;

    public bool contourInfoReceived = false;


    public GameObject contour;
    public GameObject contourPrefab;

    public List<ContourController> contourControllers = new List<ContourController>();

    public bool enableContourVisualization = true;


    //public StaticAOIAugmentationStateLSLInletController staticAOIAugmentationStateLSLInletController;


    // Start is called before the first frame update
    void Start()
    {
        targetImageController.updateTargetImageInfo();
    }

    // Update is called once per frame
    void Update()
    {
        float updateFrequency = 1.0f / Time.deltaTime;
        //Debug.Log("Update Frequency: " + updateFrequency + " FPS");

        if (contourInfoReceived==false)
        {
            AOIAugmentationAttentionContourStream();
        }

        enableDisableContoursWithKeyPress();
        enableDisableContoursWithKeyHold();


    }



    void AOIAugmentationAttentionContourStream()
    {
        aOIAugmentationAttentionContourStreamLSLInletController.pullContoursInfo();
        if (aOIAugmentationAttentionContourStreamLSLInletController.frameTimestamp!=0)
        {
            contourInfoReceived = true;
            Debug.Log("Contour Info Received");
            initContours(aOIAugmentationAttentionContourStreamLSLInletController.frameDataBuffer);


        }
        else
        {
            Debug.Log("No Contour Info Received");
        }

    }



    void initContours(float[] contourslvt)
    {
        int nextDataIndex = 0;

        int overflowFlag = (int)contourslvt[0];

        nextDataIndex += 1;

        if (overflowFlag != 0)
        {
            return;
        }
        
        int contourCount = (int)contourslvt[1];

        nextDataIndex += 1;


        for (int i = 0; i < contourCount; i++)
        {
            int contourIndex = (int)contourslvt[nextDataIndex];
            nextDataIndex += 1;

            int hierarchyInfoLength = (int)contourslvt[nextDataIndex];
            nextDataIndex += 1;
            //hierarchyinfo list:
            int[] hierarchy = new int[hierarchyInfoLength];
            for (int j = 0; j < hierarchyInfoLength; j++)
            {
                hierarchy[j] = (int)contourslvt[nextDataIndex];
                nextDataIndex += 1;
            }

            int contourVertexCount = (int)contourslvt[nextDataIndex];
            nextDataIndex += 1;

            Vector2[] contourVertices = new Vector2[contourVertexCount];
            for (int j = 0; j < contourVertexCount; j++)
            {
                float x = contourslvt[nextDataIndex];
                float y = contourslvt[nextDataIndex + 1];

                x = x - (targetImageController.targetImageRectTransform.pivot.x * targetImageController.imageWidth);
                y = (1 - targetImageController.targetImageRectTransform.pivot.y) * targetImageController.imageHeight - y;


                contourVertices[j] = new Vector2(x, y);


                nextDataIndex += 2;
            }

            GameObject contourInstance = Instantiate(contourPrefab, gameObject.transform.position, Quaternion.identity);
            contourInstance.transform.SetParent(contour.transform);
            contourInstance.transform.localPosition = gameObject.transform.localPosition;
            contourInstance.transform.localScale = gameObject.transform.localScale;
            ContourController contourController = contourInstance.GetComponent<ContourController>();

            contourController.contourIndex = contourIndex;
            contourController.hierarchy = hierarchy;
            contourController.contourVertices = contourVertices;
            contourController.drawContour();
            contourControllers.Add(contourController);

        }

    }






    public override void EnableSelf()
    {
        contourInfoReceived = false;
        base.EnableSelf();
    }

    public override void DisableSelf()
    {
        contourInfoReceived = false;
        base.DisableSelf();
    }
    

    public void removeAllContourContours()
    {

        foreach (ContourController contourController in contourControllers)
        {
            Destroy(contourController.gameObject);
        }

        contourControllers.Clear();
    }

    public void disableAllContours()
    {

        foreach (ContourController contourController in contourControllers)
        {
            contourController.gameObject.SetActive(false);
        }

    }

    public void enableAllContours()
    {

        foreach (ContourController contourController in contourControllers)
        {
            contourController.gameObject.SetActive(true);
        }

    }


    public void enableDisableContoursWithKeyPress() {
         bool switchEnableDisableContours = Input.GetKeyDown(Presets.StaticAOIAugmentationEnableDisableContoursPressKey);
            if (switchEnableDisableContours)
            {
                enableContourVisualization = !enableContourVisualization;
                if (enableContourVisualization)
                {
                    enableAllContours();
                }
                else
                {
                    disableAllContours();
                }
            }
    }

    public void enableDisableContoursWithKeyHold()
    {
        bool disableContoursKeyHold = Input.GetKey(Presets.StaticAOIAugmentationEnableDisableContoursHoldKey);
        if (disableContoursKeyHold) { 
            if (enableContourVisualization)
            {
                disableAllContours();
                enableContourVisualization = false;
            }
        }
        else
        {
            if (enableContourVisualization==false)
            {
                enableAllContours();
                enableContourVisualization = true;
            }
        }
    }


}
