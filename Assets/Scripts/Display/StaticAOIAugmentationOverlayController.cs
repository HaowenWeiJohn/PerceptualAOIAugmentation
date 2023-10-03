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


    public ContourController contourController;

    public List<ContourController> contourControllers = new List<ContourController>();


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
        int currentReadIndex = 0;
        int overflowFlag = (int)contourslvt[0];
        currentReadIndex += 1;

        if (overflowFlag != 0)
        {
            return;
        }
        
        int contourCount = (int)contourslvt[1];
        currentReadIndex += 1;


        for (int i = 0; i < contourCount; i++)
        {

            GameObject contourInstance = Instantiate(contourController.gameObject, gameObject.transform.position, Quaternion.identity);
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



}
