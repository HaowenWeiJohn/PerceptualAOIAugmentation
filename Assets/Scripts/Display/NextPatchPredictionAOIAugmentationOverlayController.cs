using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel.Channels;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class NextPatchPredictionAOIAugmentationOverlayController : GUIController
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
    public Vector2 gridSize = new Vector2(7, 7);
    public int boundingBoxWidth = 10;
    public bool showBoundingBox = false;
    public Color boundingBoxColor = Color.white;
    public bool loop = true;
    public bool flipXY = false;

    //public List<HeatmapController> heatmapControllers = new List<HeatmapController>();
    //public StaticAOIAugmentationStateLSLInletController staticAOIAugmentationStateLSLInletController;
    [Header("Audio Effect")]
    public AudioClip visualCueReceivedSoundEffect;

    [Header("AOI Augmentation Cursor Overlay Controller")]
    public CursorOverlayController cursorOverlayController;

    private Texture2D originalTexture;
    private int currentPosition = -1;
    private List<Vector2> sequence;


    // Start is called before the first frame update
    void Start()
    {
        //targetImageController.updateTargetImageInfo();
    }

    // Update is called once per frame
    void Update()
    {
        float updateFrequency = 1.0f / Time.deltaTime;
        AOIAugmentationZMQStream();

        if (Input.GetKeyDown("d"))
        {
            if (currentPosition < sequence.Count - 1)
            {
                currentPosition++;
                aoiHeatmapOverlayController.SetHeatmapTexture(CropTextureWithTransparency(originalTexture));
            }
            else if (loop && currentPosition == sequence.Count - 1)
            {
                currentPosition = -1;
                aoiHeatmapOverlayController.SetHeatmapTexture(originalTexture);
            }
        }
        if (Input.GetKeyDown("a"))
        {
            if (currentPosition > 0)
            {
                currentPosition--;
                aoiHeatmapOverlayController.SetHeatmapTexture(CropTextureWithTransparency(originalTexture));

            }
            else if(loop && currentPosition == 0)
            {
                currentPosition = -1;
                aoiHeatmapOverlayController.SetHeatmapTexture(originalTexture);
            }
            else if(loop && currentPosition == -1)
            {
                currentPosition = sequence.Count - 1;
                aoiHeatmapOverlayController.SetHeatmapTexture(CropTextureWithTransparency(originalTexture));
            }
        }
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


            byte[] originalImageByte = recieveBytes[4];
            byte[] aoiHeatmapImageByte = recieveBytes[5];

            string sequenceJson = Encoding.UTF8.GetString(recieveBytes[6]);
            Debug.Log("Sequence list string: " + sequenceJson);
            sequence = ParseStringToListOfVector2(sequenceJson);


            Texture2D originalImageTexture = new Texture2D(2, 2);
            originalImageTexture.LoadImage(originalImageByte);
            targetImageController.setImage(originalImageTexture);


            Texture2D heatmapImageTexture = new Texture2D(2, 2);
            heatmapImageTexture.LoadImage(aoiHeatmapImageByte);
            originalTexture = heatmapImageTexture;
            aoiHeatmapOverlayController.SetHeatmapTexture(heatmapImageTexture);

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

    public Texture2D CropTextureWithTransparency(Texture2D original)
    {
        int x = (int)(sequence[currentPosition].x * original.width / gridSize.x);
        int y = (int)original.height - (int)(sequence[currentPosition].y * original.height / gridSize.y) - (int)(original.height / gridSize.y);
        int width = (int)(original.width / gridSize.x);
        int height = (int)(original.height / gridSize.y);

        // Create a new Texture2D with the same dimensions as the original and with transparency
        Texture2D croppedTexture = new Texture2D(original.width, original.height, TextureFormat.RGBA32, false);

        // Set all pixels to transparent
        Color[] transparentPixels = new Color[original.width * original.height];
        for (int i = 0; i < transparentPixels.Length; i++)
        {
            transparentPixels[i].a = 0f;
        }
        croppedTexture.SetPixels(transparentPixels);

        // Check if the coordinates and dimensions are within the bounds of the original texture
        if (x < 0 || y < 0 || x + width > original.width || y + height > original.height)
        {
            Debug.LogError("Crop area is out of bounds.");
            return croppedTexture;
        }

        if (showBoundingBox)
        {
            Color[] boundingArea = new Color[original.width * original.height];
            for (int i = 0; i < boundingArea.Length; i++)
            {
                boundingArea[i] = boundingBoxColor;
            }
            croppedTexture.SetPixels(x, y, width, height, boundingArea);
        }

        if (!showBoundingBox)
        {
            boundingBoxWidth = 0;
        }

        // Copy the pixel data from the original texture to the cropped region in the new texture
        Color[] pixels = original.GetPixels(x + boundingBoxWidth, y + boundingBoxWidth, width - boundingBoxWidth * 2, height - boundingBoxWidth * 2);
        croppedTexture.SetPixels(x + boundingBoxWidth, y + boundingBoxWidth, width - boundingBoxWidth * 2, height - boundingBoxWidth * 2, pixels);
        croppedTexture.Apply();

        return croppedTexture;
    }

    public List<Vector2> ParseStringToListOfVector2(string input)
    {
        var vectors = new List<Vector2>();

        // Remove the outer brackets and split by "], ["
        string trimmedInput = input.Trim(new char[] { '[', ']' });
        var pairs = trimmedInput.Split(new string[] { "], [" }, StringSplitOptions.None);

        foreach (var pair in pairs)
        {
            // Split by comma to get the individual numbers
            var coordinates = pair.Split(',');

            // Parse the numbers and create a Vector2
            float x = float.Parse(coordinates[0].Trim());
            float y = float.Parse(coordinates[1].Trim());

            if (flipXY)
            {
                vectors.Add(new Vector2(y, x));
            }
            else
            {
                vectors.Add(new Vector2(x, y));
            }
        }

        return vectors;
    }
}