using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class NoAOIAugmentationOverlayController : GUIController
{
    // Start is called before the first frame update

    public DisplayCoordinateController displayCoordinateController;
    public TargetImageController targetImageController;

    [Header("Event Marker")]
    public EventMarkerLSLOutletController eventMarkerLSLOutletController;

    [Header("AOI Augmentation Overlay Controller")]
    public AOIAugmentationAttentionHeatmapStreamZMQSubSocketController aOIAugmentationAttentionHeatmapStreamZMQSubSocketController;

    [Header("Image Received")]
    public bool aoiAugmentationOriginalImageReceived = false;

    [Header("AOI Augmentation Cursor Overlay Controller")]
    public CursorOverlayController cursorOverlayController;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float updateFrequency = 1.0f / Time.deltaTime;
        AOIAugmentationZMQStream();

    }


    void AOIAugmentationZMQStream()
    {
        bool messageReceived = aOIAugmentationAttentionHeatmapStreamZMQSubSocketController.ReceiveMessage();

        if (messageReceived)
        {
            aoiAugmentationOriginalImageReceived = true;
            targetImageController.targetImage.enabled = true;
            cursorOverlayController.DeactivateCursorLoadingImage();

            List<byte[]> recieveBytes = aOIAugmentationAttentionHeatmapStreamZMQSubSocketController.recieveBytes;
            string topicName = Encoding.UTF8.GetString(recieveBytes[0]);
            Debug.Log("Topic Name: " + topicName);
            double timestamp = BitConverter.ToDouble(recieveBytes[1], 0);
            Debug.Log("Timestamp: " + timestamp);

            string imageName = Encoding.UTF8.GetString(recieveBytes[2]);
            targetImageController.imageName = imageName;
            Debug.Log("Image Name: " + imageName);

            string imageType = Encoding.UTF8.GetString(recieveBytes[3]);
            targetImageController.imageType = imageType;
            Debug.Log("Image Type: " + imageType);

            byte[] originalImageByte = recieveBytes[4];

            Texture2D originalImageTexture = new Texture2D(2, 2);
            originalImageTexture.LoadImage(originalImageByte);
            targetImageController.setImage(originalImageTexture);


            // send AOIAugmentation Start Event Marker
            eventMarkerLSLOutletController.sendAOIAugmentationInteractionStartMarker();

        }
    }


    public override void EnableSelf()
    {

        aoiAugmentationOriginalImageReceived = false;
        cursorOverlayController.ActivateCursorLoadingImage();
        base.EnableSelf();
    }

    public override void DisableSelf()
    {

        aoiAugmentationOriginalImageReceived = false;
        base.DisableSelf();
    }


}
