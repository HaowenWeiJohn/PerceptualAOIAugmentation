using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel.Channels;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


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

    [Header("Heatmap Overlay")]
    public AOIHeatmapOverlayController aoiHeatmapOverlayController;
    public AOIAugmentationAttentionHeatmapStreamZMQSubSocketController aOIAugmentationAttentionHeatmapStreamZMQSubSocketController;
    public bool visualCueReceived = false;

    [Header("Target Image")]
    public GameObject targetImage;

    [Header("Target Heatmap")]
    public RawImage targetHeatmap;

    //public List<HeatmapController> heatmapControllers = new List<HeatmapController>();
    //public StaticAOIAugmentationStateLSLInletController staticAOIAugmentationStateLSLInletController;
    [Header("Audio Effect")]
    public AudioClip visualCueReceivedSoundEffect;

    [Header("AOI Augmentation Cursor Overlay Controller")]
    public CursorOverlayController cursorOverlayController;

    [Header("Bscan Buttons")]
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;

    [Header("Bscan textures")]
    public Texture2D bscan1Texture;
    public Texture2D bscan2Texture;
    public Texture2D bscan3Texture;
    public Texture2D bscan4Texture;
    public Texture2D bscan5Texture;

    [Header("Heatmap textures")]
    public Texture2D heatmap1Texture;
    public Texture2D heatmap2Texture;
    public Texture2D heatmap3Texture;
    public Texture2D heatmap4Texture;
    public Texture2D heatmap5Texture;

    // Start is called before the first frame update
    void Start()
    {
        bscan1Texture = new Texture2D(2, 2);
        bscan2Texture = new Texture2D(2, 2);
        bscan3Texture = new Texture2D(2, 2);
        bscan4Texture = new Texture2D(2, 2);
        bscan5Texture = new Texture2D(2, 2);
        heatmap1Texture = new Texture2D(2, 2);
        heatmap2Texture = new Texture2D(2, 2);
        heatmap3Texture = new Texture2D(2, 2);
        heatmap4Texture = new Texture2D(2, 2);
        heatmap5Texture = new Texture2D(2, 2);
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
            targetImageController.targetImage.enabled = true;
            visualCueReceived = true;
            cursorOverlayController.DeactivateCursorLoadingImage();

            aoiHeatmapOverlayController.SetHeatmapVisibility(true);
            Debug.Log("Heatmap Received");
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

            byte[] heatmap1Byte = recieveBytes[9];
            heatmap1Texture.LoadImage(heatmap1Byte);
            aoiHeatmapOverlayController.SetHeatmapTexture(heatmap1Texture);
            targetHeatmap.color = new Color(1f, 0.7f, 0, 1f);

            byte[] heatmap2Byte = recieveBytes[10];
            heatmap2Texture.LoadImage(heatmap2Byte);

            byte[] heatmap3Byte = recieveBytes[11];
            heatmap3Texture.LoadImage(heatmap3Byte);

            byte[] heatmap4Byte = recieveBytes[12];
            heatmap4Texture.LoadImage(heatmap4Byte);

            byte[] heatmap5Byte = recieveBytes[13];
            heatmap5Texture.LoadImage(heatmap5Byte);

            // play sound effect
            AudioSource.PlayClipAtPoint(visualCueReceivedSoundEffect, Camera.main.transform.position);

            // send AOIAugmentation Start Event Marker
            eventMarkerLSLOutletController.sendAOIAugmentationInteractionStartMarker();
        }
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


    public void CleanUp()
    {
        //targetImageController.CleanUp();
        visualCueReceived = false;
        aoiHeatmapOverlayController.CleanUp();

    }


    public override void EnableSelf()
    {
        //contourInfoReceived = false;
        CleanUp();
        cursorOverlayController.ActivateCursorLoadingImage();
        base.EnableSelf();
    }

    public override void DisableSelf()
    {
        //contourInfoReceived = false;
        CleanUp();
        base.DisableSelf();
    }

    public void setBscan1()
    {
        targetImage.GetComponent<Image>().sprite = Sprite.Create(bscan1Texture, new Rect(0, 0, bscan1Texture.width, bscan1Texture.height), new Vector2(0.5f, 0.5f));
    }

    public void setBscan2()
    {
        targetImage.GetComponent<Image>().sprite = Sprite.Create(bscan2Texture, new Rect(0, 0, bscan2Texture.width, bscan2Texture.height), new Vector2(0.5f, 0.5f));
    }

    public void setBscan3()
    {
        targetImage.GetComponent<Image>().sprite = Sprite.Create(bscan3Texture, new Rect(0, 0, bscan3Texture.width, bscan3Texture.height), new Vector2(0.5f, 0.5f));
    }

    public void setBscan4()
    {
        targetImage.GetComponent<Image>().sprite = Sprite.Create(bscan4Texture, new Rect(0, 0, bscan4Texture.width, bscan4Texture.height), new Vector2(0.5f, 0.5f));
    }

    public void setBscan5()
    {
        targetImage.GetComponent<Image>().sprite = Sprite.Create(bscan5Texture, new Rect(0, 0, bscan5Texture.width, bscan5Texture.height), new Vector2(0.5f, 0.5f));
    }

    public void setHeatmap1()
    {
        targetHeatmap.texture = heatmap1Texture;
    }

    public void setHeatmap2()
    {
        targetHeatmap.texture = heatmap2Texture;
    }

    public void setHeatmap3()
    {
        targetHeatmap.texture = heatmap3Texture;
    }

    public void setHeatmap4()
    {
        targetHeatmap.texture = heatmap4Texture;
    }

    public void setHeatmap5()
    {
        targetHeatmap.texture = heatmap5Texture;
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
