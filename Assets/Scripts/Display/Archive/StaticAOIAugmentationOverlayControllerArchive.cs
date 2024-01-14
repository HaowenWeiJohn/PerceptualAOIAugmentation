using System;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StaticAOIAugmentationOverlayControllerArchive : GUIController
{


    public DisplayCoordinateController displayCoordinateController;
    public TargetImageController targetImageController;

    public AOIAugmentationAttentionHeatmapStreamLSLInletController aOIAugmentationAttentionHeatmapStreamLSLInletController;


    // not needed anymore
    public bool contourInfoReceived = false;

    [Header("Event Marker")]
    public EventMarkerLSLOutletController eventMarkerLSLOutletController;

    [Header("Contour")]
    public GameObject contour;
    public GameObject contourPrefab;
    public List<ContourController> contourControllers = new List<ContourController>();
    public bool enableContourVisualization = true;
    public AOIAugmentationAttentionContourStreamLSLInletController aOIAugmentationAttentionContourStreamLSLInletController;

    [Header("Heatmap")]
    public GameObject heatmap;
    public GameObject heatmapPrefab;
    public List<HeatmapController> heatmapControllers = new List<HeatmapController>();
    public bool enableHeatmapVisualization = true;
    public AOIAugmentationAttentionHeatmapStreamZMQSubSocketController aOIAugmentationAttentionHeatmapStreamZMQSubSocketController;

    //public StaticAOIAugmentationStateLSLInletController staticAOIAugmentationStateLSLInletController;
    [Header("Audio Effect")]
    public AudioClip visualCueReceivedSoundEffect;

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

        //if (contourInfoReceived==false)
        //{
        //    AOIAugmentationAttentionContourStream();
        //}


        AOIAugmentationAttentionHeatmapStream();
        EnableDisableHeatmapsWithKeyPress();

        //enableDisableContoursWithKeyPress();
        //enableDisableContoursWithKeyHold();


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


    void AOIAugmentationAttentionHeatmapStream()
    {
        bool messageReceived = aOIAugmentationAttentionHeatmapStreamZMQSubSocketController.ReceiveMessage();
        if (messageReceived)
        {
            RemoveAllHeatmaps(); // remove all heatmaps first

            Debug.Log("Heatmap Received");
            List<byte[]> recieveBytes = aOIAugmentationAttentionHeatmapStreamZMQSubSocketController.recieveBytes;
            string topicName = Encoding.UTF8.GetString(recieveBytes[0]);
            Debug.Log("Topic Name: " + topicName);
            double timestamp = BitConverter.ToDouble(recieveBytes[1], 0);
            Debug.Log("Timestamp: " + timestamp);
            int heatmapNumber = BitConverter.ToInt32(recieveBytes[2], 0);
            Debug.Log("Heatmap Number: " + heatmapNumber);

            int pointer = 3;
            for (int imageIndex = 0; imageIndex < 6; imageIndex++) 
            {
                List<int> imagePosition = GeneralUtils.ToListOf<int>(recieveBytes[pointer], BitConverter.ToInt32);
                
                pointer++;
                byte[] pngBytes = recieveBytes[pointer];
                Debug.Log("PNG Bytes Length: " + pngBytes.Length);
                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(pngBytes);

                GameObject heatmapInstance = Instantiate(heatmapPrefab, gameObject.transform.position, Quaternion.identity);
                heatmapInstance.transform.SetParent(heatmap.transform);
                heatmapInstance.transform.localPosition = gameObject.transform.localPosition;
                heatmapInstance.transform.localScale = gameObject.transform.localScale;
                HeatmapController heatmapController = heatmapInstance.GetComponent<HeatmapController>();
                heatmapController.targetImageController = targetImageController;
                heatmapController.setHeatmapTexture(texture, imagePosition);
                
                heatmapControllers.Add(heatmapController);

                pointer++;

            }

            enableHeatmapVisualization = true;
            // play sound effect
            AudioSource.PlayClipAtPoint(visualCueReceivedSoundEffect, Camera.main.transform.position);

        }
        else
        { 
            // do nothing
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
        enableHeatmapVisualization = true;
        base.EnableSelf();
    }

    public override void DisableSelf()
    {
        contourInfoReceived = false;
        enableHeatmapVisualization = true;
        base.DisableSelf();
    }








    public void RemoveOverlayElements()
    {
        RemoveAllHeatmaps();
        RemoveAllContours();

    }








    public void RemoveAllHeatmaps()
    {
        foreach (HeatmapController heatmapController in heatmapControllers)
        {
                Destroy(heatmapController.gameObject);
            }
    
            heatmapControllers.Clear();
    }

    public void DisableAllHeatmaps()
    {
        foreach (HeatmapController heatmapController in heatmapControllers)
        {
            heatmapController.gameObject.SetActive(false);
        }

        eventMarkerLSLOutletController.sendToggleVisualCueVisibilityMarker(false);
    }

    public void EnableAllHeatmaps()
    {
        foreach (HeatmapController heatmapController in heatmapControllers)
        {
            heatmapController.gameObject.SetActive(true);
        }

        eventMarkerLSLOutletController.sendToggleVisualCueVisibilityMarker(true);
    }

    public void EnableDisableHeatmapsWithKeyPress()
    {
        bool switchEnableDisableHeatmaps = Input.GetKeyDown(Presets.AOIAugmentationToggleVisualCueVisibilityCueKey);
        if (switchEnableDisableHeatmaps)
        {
            enableHeatmapVisualization = !enableHeatmapVisualization;
            if (enableHeatmapVisualization)
            {
                EnableAllHeatmaps();
            }
            else
            {
                DisableAllHeatmaps();
            }
        }
    }









    public void RemoveAllContours()
    {

        foreach (ContourController contourController in contourControllers)
        {
            Destroy(contourController.gameObject);
        }

        contourControllers.Clear();
    }

    public void DisableAllContours()
    {

        foreach (ContourController contourController in contourControllers)
        {
            contourController.gameObject.SetActive(false);
        }

    }

    public void EnableAllContours()
    {

        foreach (ContourController contourController in contourControllers)
        {
            contourController.gameObject.SetActive(true);
        }

    }


    public void aOIAugmentationInteractionStateUpdateCueKeyPressed()
    {
        bool keyPressed = Input.GetKeyDown(Presets.AOIAugmentationInteractionStateUpdateCueKey);

        if (keyPressed)
        {
            // send update visual cue marker
            eventMarkerLSLOutletController.sendUpdateVisualCueMarker();
            //eventMarkerLSLOutletController.sendUserInputsMarker
            //    (Presets.UserInputTypes.AOIAugmentationInteractionStateUpdateCueKeyPressed);
        }
    }










    //public void enableDisableContoursWithKeyPress() {
    //     bool switchEnableDisableContours = Input.GetKeyDown(Presets.AOIAugmentationEnableDisableContoursPressKey);
    //        if (switchEnableDisableContours)
    //        {
    //            enableContourVisualization = !enableContourVisualization;
    //            if (enableContourVisualization)
    //            {
    //                enableAllContours();
    //            }
    //            else
    //            {
    //                disableAllContours();
    //            }
    //        }
    //}


    //public void enableDisableContoursWithKeyHold()
    //{
    //    bool disableContoursKeyHold = Input.GetKey(Presets.AOIAugmentationEnableDisableContoursHoldKey);
    //    if (disableContoursKeyHold) { 
    //        if (enableContourVisualization)
    //        {
    //            disableAllContours();
    //            enableContourVisualization = false;
    //        }
    //    }
    //    else
    //    {
    //        if (enableContourVisualization==false)
    //        {
    //            enableAllContours();
    //            enableContourVisualization = true;
    //        }
    //    }
    //}


}
