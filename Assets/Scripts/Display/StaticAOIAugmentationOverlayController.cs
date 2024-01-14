using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel.Channels;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StaticAOIAugmentationOverlayController : GUIController
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

    [Header("Heatmap")]
    public HeatmapOverlayController heatmapOverlayController;
    public AOIAugmentationAttentionHeatmapStreamZMQSubSocketController aOIAugmentationAttentionHeatmapStreamZMQSubSocketController;
    public bool visualCueReceived = false;

    //public List<HeatmapController> heatmapControllers = new List<HeatmapController>();
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
        AOIAugmentationAttentionHeatmapStream();

        EnableDisableHeatmapsWithKeyPress();

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
            heatmapOverlayController.SetHeatmapVisibility(true);
            Debug.Log("Heatmap Received");
            List<byte[]> recieveBytes = aOIAugmentationAttentionHeatmapStreamZMQSubSocketController.recieveBytes;
            string topicName = Encoding.UTF8.GetString(recieveBytes[0]);
            Debug.Log("Topic Name: " + topicName);
            double timestamp = BitConverter.ToDouble(recieveBytes[1], 0);
            Debug.Log("Timestamp: " + timestamp);

            byte[] originalImageByte = recieveBytes[2];
            byte[] heatmapImageByte = recieveBytes[3];


            Texture2D originalImageTexture = new Texture2D(2, 2);
            originalImageTexture.LoadImage(originalImageByte);
            targetImageController.setImage(originalImageTexture);


            Texture2D heatmapImageTexture = new Texture2D(2, 2);
            heatmapImageTexture.LoadImage(heatmapImageByte);
            heatmapOverlayController.SetHeatmapTexture(heatmapImageTexture);

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
            if (heatmapOverlayController.HeatmapOverlayEnabled())
            {
                heatmapOverlayController.SetHeatmapVisibility(false);
                eventMarkerLSLOutletController.sendToggleVisualCueVisibilityMarker(false);
            }
            else
            {
                heatmapOverlayController.SetHeatmapVisibility(true);
                eventMarkerLSLOutletController.sendToggleVisualCueVisibilityMarker(true);
            }
        }
    }


    public void CleanUp()
    {
        //targetImageController.CleanUp();
        visualCueReceived = false;
        heatmapOverlayController.CleanUp();

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
