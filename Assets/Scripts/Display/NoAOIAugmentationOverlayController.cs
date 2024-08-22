using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class NoAOIAugmentationOverlayController : GUIController
{
    // Start is called before the first frame update

    public DisplayCoordinateController displayCoordinateController;
    public TargetImageController targetImageController;

    [Header("Event Marker")]
    public EventMarkerLSLOutletController eventMarkerLSLOutletController;

    [Header("AOI Augmentation Overlay Controller")]
    public AOIAugmentationAttentionHeatmapStreamZMQSubSocketController aOIAugmentationAttentionHeatmapStreamZMQSubSocketController;

    [Header("Target Image")]
    public GameObject targetImage;

    [Header("Image Received")]
    public bool aoiAugmentationOriginalImageReceived = false;

    [Header("AOI Augmentation Cursor Overlay Controller")]
    public CursorOverlayController cursorOverlayController;

    [Header("Bscan Buttons")]
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;

    [Header("textures")]
    public Texture2D bscan1Texture;
    public Texture2D bscan2Texture;
    public Texture2D bscan3Texture;
    public Texture2D bscan4Texture;
    public Texture2D bscan5Texture;

    public EventMarkerLSLOutletController eventMarkerLSL;

    void Start()
    {
        bscan1Texture = new Texture2D(2, 2);
        bscan2Texture = new Texture2D(2, 2);
        bscan3Texture = new Texture2D(2, 2);
        bscan4Texture = new Texture2D(2, 2);
        bscan5Texture = new Texture2D(2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        float updateFrequency = 1.0f / Time.deltaTime;
        AOIAugmentationZMQStream();

        
        //button1.GetComponent<Button>().onClick.AddListener(setBscan1);
        //button2.GetComponent<Button>().onClick.AddListener(setBscan2);
        //button3.GetComponent<Button>().onClick.AddListener(setBscan3);
        //button4.GetComponent<Button>().onClick.AddListener(setBscan4);
        //button5.GetComponent<Button>().onClick.AddListener(setBscan5);
        
    }


    void AOIAugmentationZMQStream()
    {
        bool messageReceived = aOIAugmentationAttentionHeatmapStreamZMQSubSocketController.ReceiveMessage();

        if (messageReceived)
        {
            Debug.Log("Message Received");

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

            byte[] bscan1Byte = recieveBytes[4];
            
            bscan1Texture.LoadImage(bscan1Byte);
            targetImageController.setImage(bscan1Texture);

            byte[] bscan2Byte = recieveBytes[5];
            bscan2Texture.LoadImage(bscan2Byte);

            byte[] bscan3Byte = recieveBytes[6];
            bscan3Texture.LoadImage(bscan3Byte);

            byte[] bscan4Byte = recieveBytes[7];
            bscan4Texture.LoadImage(bscan4Byte);

            byte[] bscan5Byte = recieveBytes[8];
            bscan5Texture.LoadImage(bscan5Byte);

            setButtonsImage();

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

    public void setBscan1()
    {
        targetImage.GetComponent<Image>().sprite = Sprite.Create(bscan1Texture, new Rect(0, 0, bscan1Texture.width, bscan1Texture.height), new Vector2(0.5f, 0.5f));
        Debug.Log("Bscan1 Set");
        eventMarkerLSL.SendBScanLayerSelection(1);
    }

    public void setBscan2()
    {
        targetImage.GetComponent<Image>().sprite = Sprite.Create(bscan2Texture, new Rect(0, 0, bscan2Texture.width, bscan2Texture.height), new Vector2(0.5f, 0.5f));
        Debug.Log("Bscan2 Set");
        eventMarkerLSL.SendBScanLayerSelection(2);

    }

    public void setBscan3()
    {
        targetImage.GetComponent<Image>().sprite = Sprite.Create(bscan3Texture, new Rect(0, 0, bscan3Texture.width, bscan3Texture.height), new Vector2(0.5f, 0.5f));
        Debug.Log("Bscan3 Set");
        eventMarkerLSL.SendBScanLayerSelection(3);
    }

    public void setBscan4()
    {
        targetImage.GetComponent<Image>().sprite = Sprite.Create(bscan4Texture, new Rect(0, 0, bscan4Texture.width, bscan4Texture.height), new Vector2(0.5f, 0.5f));
        Debug.Log("Bscan4 Set");
        eventMarkerLSL.SendBScanLayerSelection(4);
    }

    public void setBscan5()
    {
        targetImage.GetComponent<Image>().sprite = Sprite.Create(bscan5Texture, new Rect(0, 0, bscan5Texture.width, bscan5Texture.height), new Vector2(0.5f, 0.5f));
        Debug.Log("Bscan5 Set");
        eventMarkerLSL.SendBScanLayerSelection(5);
    }

    private void setButtonsImage()
    {
        int textureWidth = bscan1Texture.width;
        int textureHeight = bscan1Texture.height;

        button1.GetComponent<Image>().sprite = Sprite.Create(bscan1Texture, new Rect(0, 0, textureWidth, textureHeight), new Vector2(0.5f, 0.5f));
        button2.GetComponent<Image>().sprite = Sprite.Create(bscan2Texture, new Rect(0, 0, textureWidth, textureHeight), new Vector2(0.5f, 0.5f));
        button3.GetComponent<Image>().sprite = Sprite.Create(bscan3Texture, new Rect(0, 0, textureWidth, textureHeight), new Vector2(0.5f, 0.5f));
        button4.GetComponent<Image>().sprite = Sprite.Create(bscan4Texture, new Rect(0, 0, textureWidth, textureHeight), new Vector2(0.5f, 0.5f));
        button5.GetComponent<Image>().sprite = Sprite.Create(bscan5Texture, new Rect(0, 0, textureWidth, textureHeight), new Vector2(0.5f, 0.5f));
    }

}
