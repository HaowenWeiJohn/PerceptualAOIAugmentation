using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BscanNoAOIAugmentationOverlayController : GUIController
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

        button1.GetComponent<Button>().onClick.AddListener(delegate { setImage(bscan1Texture); });
        button2.GetComponent<Button>().onClick.AddListener(delegate { setImage(bscan2Texture); });
        button3.GetComponent<Button>().onClick.AddListener(delegate { setImage(bscan3Texture); });
        button4.GetComponent<Button>().onClick.AddListener(delegate { setImage(bscan4Texture); });
        button5.GetComponent<Button>().onClick.AddListener(delegate { setImage(bscan5Texture); });
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

            bool isLoaded = bscan1Texture.LoadImage(bscan1Byte);
            targetImageController.setImage(bscan1Texture);

            if (isLoaded)
            {
                Debug.Log("Texture size: " + bscan1Texture.width + "x" + bscan1Texture.height);
            }

            if(!isLoaded)
            {
                Debug.Log("Texture not loaded");
            }

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

    private void setImage(Texture2D image)
    {
        //targetImage.GetComponent<Renderer>().material.mainTexture = image;
        Debug.Log("Image Set");
    }

    private void setButtonsImage()
    {
        button1.GetComponent<Renderer>().material.mainTexture = bscan1Texture;
        button2.GetComponent<Renderer>().material.mainTexture = bscan2Texture;
        button3.GetComponent<Renderer>().material.mainTexture = bscan3Texture;
        button4.GetComponent<Renderer>().material.mainTexture = bscan4Texture;
        button5.GetComponent<Renderer>().material.mainTexture = bscan5Texture;
    }

}
