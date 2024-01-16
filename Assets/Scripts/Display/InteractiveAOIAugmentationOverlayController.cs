using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel.Channels;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InteractiveAOIAugmentationOverlayController : GUIController
{


    public DisplayCoordinateController displayCoordinateController;
    public TargetImageController targetImageController;

    public AOIAugmentationAttentionHeatmapStreamLSLInletController aOIAugmentationAttentionHeatmapStreamLSLInletController;


    // not needed anymore

    [Header("Event Marker")]
    public EventMarkerLSLOutletController eventMarkerLSLOutletController;

    //[Header("Contour")]
    //public GameObject contours;
    //public GameObject contourPrefab;
    //public List<ContourController> contourControllers = new List<ContourController>();
    //public bool enableContourVisualization = true;
    //public AOIAugmentationAttentionContourStreamLSLInletController aOIAugmentationAttentionContourStreamLSLInletController;

    [Header("Heatmap Overlay")]
    public AOIHeatmapOverlayController aoiHeatmapOverlayController;
    public AOIAugmentationAttentionHeatmapStreamZMQSubSocketController aOIAugmentationAttentionHeatmapStreamZMQSubSocketController;
    public bool visualCueReceived = false;


    [Header("Heatmap History Scroll Area")]
    public ScrollRect interactiveAOIAugmentationHistoryScrollViewScrollRect;
    public ToggleGroup interactiveAOIAugmentationHistoryScrollViewToggleGroup;
    public GameObject aoiAugmentationHistoryWidgetControllerPrefab;
    public List<AOIAugmentationHistoryWidgetController> aoiAugmentationHistoryWidgetControllers = new List<AOIAugmentationHistoryWidgetController>();

    //bool setScrollAinteractiveAOIAugmentationHistoryScrollViewreaToBtttom = false;


    //public List<HeatmapController> heatmapControllers = new List<HeatmapController>();
    //public StaticAOIAugmentationStateLSLInletController staticAOIAugmentationStateLSLInletController;
    [Header("Audio Effect")]
    public AudioClip visualCueReceivedSoundEffect;
    public AudioClip updateVisualCueInstructionSendSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        targetImageController.updateTargetImageInfo();
    }

    // Update is called once per frame
    void Update()
    {
        float updateFrequency = 1.0f / Time.deltaTime;
        AOIAugmentationAttentionHeatmapStream();

        if (targetImageController.IsCursorOverTargetImage())
        {
            EnableDisableHeatmapsWithKeyPress();
            AOIAugmentationInteractionStateUpdateCueKeyPressed();
        }

    }


    //public void SetTargetImageTexture(Texture2D texture)
    //{
    //    targetImageController.setImage(texture);
    //}

    //public void SetHeatmapOverlayTextrue(Texture2D texture, bool enabled=true)
    //{
    //    heatmapOverlay.texture = texture;
    //    heatmapOverlay.SetNativeSize();

    //    heatmapOverlay.enabled = enabled;
    //}




    void AOIAugmentationAttentionHeatmapStream()
    {
        bool messageReceived = aOIAugmentationAttentionHeatmapStreamZMQSubSocketController.ReceiveMessage();




        if (messageReceived)
        {
            visualCueReceived = true;
            aoiHeatmapOverlayController.SetHeatmapVisibility(true);
            Debug.Log("Heatmap Received");
            List<byte[]> recieveBytes = aOIAugmentationAttentionHeatmapStreamZMQSubSocketController.recieveBytes;
            string topicName = Encoding.UTF8.GetString(recieveBytes[0]);
            Debug.Log("Topic Name: " + topicName);
            double timestamp = BitConverter.ToDouble(recieveBytes[1], 0);
            Debug.Log("Timestamp: " + timestamp);

            byte[] originalImageByte = recieveBytes[2];
            byte[] aoiHeatmapImageByte = recieveBytes[3];

            byte[] gazeHeatmapImageByte = recieveBytes.Count == 5 ? recieveBytes[4] : null;




            //Texture2D originalImageTexture = new Texture2D(2, 2);
            //originalImageTexture.LoadImage(originalImageByte);
            ////targetImageController.setImage(originalImageTexture);


            //Texture2D aoiHeatmapImageTexture = new Texture2D(2, 2);
            //aoiHeatmapImageTexture.LoadImage(aoiHeatmapImageByte);
            ////heatmapOverlayController.SetHeatmapTexture(aoiHeatmapImageTexture);


            

            // create scroll area
            // 

            GameObject aOIAugmentationHistoryWidget = Instantiate(aoiAugmentationHistoryWidgetControllerPrefab, interactiveAOIAugmentationHistoryScrollViewScrollRect.content.transform);

            AOIAugmentationHistoryWidgetController aOIAugmentationHistoryWidgetController = aOIAugmentationHistoryWidget.GetComponent<AOIAugmentationHistoryWidgetController>();
            aoiAugmentationHistoryWidgetControllers.Add(aOIAugmentationHistoryWidgetController);

            // set history widget index
            aOIAugmentationHistoryWidgetController.historyWidgetId = aoiAugmentationHistoryWidgetControllers.Count;
            // set toggle group
            aOIAugmentationHistoryWidgetController.visualizationToggleSelection.group = interactiveAOIAugmentationHistoryScrollViewToggleGroup;

            // set scroll rect
            aOIAugmentationHistoryWidgetController.interactiveAOIAugmentationHistoryScrollViewScrollRect = interactiveAOIAugmentationHistoryScrollViewScrollRect;

            // set target image controller
            aOIAugmentationHistoryWidgetController.targetImageController = targetImageController;
            aOIAugmentationHistoryWidgetController.aoiHeatmapOverlayController = aoiHeatmapOverlayController;



            // set images
            Texture2D originalImageTexture = new Texture2D(2, 2);
            originalImageTexture.LoadImage(originalImageByte);
            aOIAugmentationHistoryWidgetController.SetAOIBackgroundImageTexture(originalImageTexture);

            Texture2D aoiHeatmapImageTexture = new Texture2D(2, 2);
            aoiHeatmapImageTexture.LoadImage(aoiHeatmapImageByte);
            aOIAugmentationHistoryWidgetController.SetAOIBackgroundImageHeatmapOverlayImageTexture(aoiHeatmapImageTexture);


            if (gazeHeatmapImageByte != null)
            {

                aOIAugmentationHistoryWidgetController.SetGazeAttentionBackgroundImageTexture(originalImageTexture);

                Texture2D gazeHeatmapImageTexture = new Texture2D(2, 2);
                gazeHeatmapImageTexture.LoadImage(gazeHeatmapImageByte);
                aOIAugmentationHistoryWidgetController.SetGazeAttentionBackgroundImageHeatmapOverlayImageTexture(gazeHeatmapImageTexture);
            }
            else
            {
                // do nothing
            }

            // set visualization toggle selection
            aOIAugmentationHistoryWidgetController.visualizationToggleSelection.isOn = true;
            aOIAugmentationHistoryWidgetController.OnAOIAugmentationHistoryWidgetSelected(true);
            //setScrollAinteractiveAOIAugmentationHistoryScrollViewreaToBtttom = true;

            Canvas.ForceUpdateCanvases();
            interactiveAOIAugmentationHistoryScrollViewScrollRect.verticalNormalizedPosition = 0f;


            // set scroll area to bottom


            // play sound effect
            AudioSource.PlayClipAtPoint(visualCueReceivedSoundEffect, Camera.main.transform.position);
        }




        //if (messageReceived)
        //{
        //    //RemoveAllHeatmaps(); // remove all heatmaps first

        //    Debug.Log("Heatmap Received");
        //    List<byte[]> recieveBytes = aOIAugmentationAttentionHeatmapStreamZMQSubSocketController.recieveBytes;
        //    string topicName = Encoding.UTF8.GetString(recieveBytes[0]);
        //    Debug.Log("Topic Name: " + topicName);
        //    double timestamp = BitConverter.ToDouble(recieveBytes[1], 0);
        //    Debug.Log("Timestamp: " + timestamp);
        //    int heatmapNumber = BitConverter.ToInt32(recieveBytes[2], 0);
        //    Debug.Log("Heatmap Number: " + heatmapNumber);

        //    int pointer = 3;
        //    for (int imageIndex = 0; imageIndex < 6; imageIndex++)
        //    {
        //        List<int> imagePosition = GeneralUtils.ToListOf<int>(recieveBytes[pointer], BitConverter.ToInt32);

        //        pointer++;
        //        byte[] pngBytes = recieveBytes[pointer];
        //        Debug.Log("PNG Bytes Length: " + pngBytes.Length);
        //        Texture2D texture = new Texture2D(2, 2);
        //        texture.LoadImage(pngBytes);

        //        GameObject heatmapInstance = Instantiate(heatmapPrefab, gameObject.transform.position, Quaternion.identity);
        //        heatmapInstance.transform.SetParent(heatmaps.transform);
        //        heatmapInstance.transform.localPosition = gameObject.transform.localPosition;
        //        heatmapInstance.transform.localScale = gameObject.transform.localScale;
        //        HeatmapController heatmapController = heatmapInstance.GetComponent<HeatmapController>();
        //        heatmapController.targetImageController = targetImageController;
        //        heatmapController.setHeatmapTexture(texture, imagePosition);

        //        heatmapControllers.Add(heatmapController);

        //        pointer++;

        //    }

        //    enableHeatmapVisualization = true;
        //    // play sound effect
        //    AudioSource.PlayClipAtPoint(visualCueReceivedSoundEffect, Camera.main.transform.position);

        //}
        //else
        //{
        //    // do nothing
        //}



    }




    public void EnableDisableHeatmapsWithKeyPress()
    {
        bool switchEnableDisableHeatmaps = Input.GetKeyDown(Presets.AOIAugmentationToggleVisualCueVisibilityCueKey);

        if (switchEnableDisableHeatmaps)
        {
            if (aoiHeatmapOverlayController.HeatmapOverlayEnabled())
            {
                aoiHeatmapOverlayController.SetHeatmapVisibility(false);
                eventMarkerLSLOutletController.sendToggleVisualCueVisibilityMarker(false);
            }
            else
            {
                aoiHeatmapOverlayController.SetHeatmapVisibility(true);
                eventMarkerLSLOutletController.sendToggleVisualCueVisibilityMarker(true);
            }
        }
    }





    public void AOIAugmentationInteractionStateUpdateCueKeyPressed()
    {
        bool keyPressed = Input.GetKeyDown(Presets.AOIAugmentationUpdateVisualCueKey);

        if (keyPressed && visualCueReceived)
        {
            // send update visual cue marker
            eventMarkerLSLOutletController.sendUpdateVisualCueMarker();

            // play sound effect
            AudioSource.PlayClipAtPoint(updateVisualCueInstructionSendSoundEffect, Camera.main.transform.position);
            visualCueReceived = false;

            //eventMarkerLSLOutletController.sendUserInputsMarker
            //    (Presets.UserInputTypes.AOIAugmentationInteractionStateUpdateCueKeyPressed);
        }
    }






    public void ClearAOIAugmentationHistory()
    {

        foreach (AOIAugmentationHistoryWidgetController AOIAugmentationHistoryWidgetController in aoiAugmentationHistoryWidgetControllers)
        {
            Destroy(AOIAugmentationHistoryWidgetController.gameObject);
        }

        aoiAugmentationHistoryWidgetControllers.Clear();

    }








    public void CleanUp()
    {
        //targetImageController.CleanUp();
        visualCueReceived = false;
        aoiHeatmapOverlayController.CleanUp();
        ClearAOIAugmentationHistory();

    }


    public override void EnableSelf()
    {
        //contourInfoReceived = false;
        CleanUp();
        base.EnableSelf();
    }

    public override void DisableSelf()
    {
        //contourInfoReceived = false;
        CleanUp();
        base.DisableSelf();
    }


}
