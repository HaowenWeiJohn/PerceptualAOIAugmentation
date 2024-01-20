using NetMQ;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TargetImageController : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform targetImageRectTransform;



    public float width = 0;
    public float height = 0;

    public float originalImageWidth = 0;
    public float originalImageHeight = 0;


    public float aspectRatio = 0;

    public float imageWidth = 0;
    public float imageHeight = 0;





    public Vector3 localPosition = new Vector3();
    //public Vector2 targetImageShape = new Vector2 (0, 0); // in matrix format height, width
    //public Vector2 targetImagePosition = new Vector2(0, 0); // center position. in canvas space
    public Image targetImage;

    [Header("Network Controller")]
    public TargetImageInfoLSLOutletController targetImageInfoLSLOutletController;

    [Header("Interaction State")]
    public GameManager gameManager;

    [Header("Audio Clip")]
    public AudioClip imageTransparencyHitBoundrySoundEffect;

    [Header("Image Meta Info")]
    public string imageName;
    public string imageType;


    //[Header("AOI Augmentation Image LineRender")]
    //public LineRenderer targetImageContourLineRenderer;


    void Start()
    {
        //updateTargetImageInfo();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetImage.enabled)
        {
            updateTargetImageInfo();
            targetImageInfoLSLOutletController.sendImageInfo(targetImage);
        }
        if (IsCursorOverTargetImage())
        {
            if (gameManager.currentState.experimentState == Presets.ExperimentState.InteractiveAOIAugmentationState || 
                gameManager.currentState.experimentState == Presets.ExperimentState.StaticAOIAugmentationState || 
                gameManager.currentState.experimentState == Presets.ExperimentState.ResnetAOIAugmentationState)
            {
                // AdjustTransparency only if the cursor  
                AdjustTransparency();
            }
        }

    }

    //public void setImageContour(Texture2D targetImageTexture)
    //{
        
    //}

    public void updateTargetImageInfo()
    {
        width = targetImageRectTransform.rect.width;
        height = targetImageRectTransform.rect.height;

        originalImageWidth = targetImage.sprite.rect.width;
        originalImageHeight = targetImage.sprite.rect.height;

        localPosition = targetImageRectTransform.localPosition;

        imageWidth = width;
        imageHeight = height;

        if (targetImage.preserveAspect)
        {
            aspectRatio = originalImageWidth / originalImageHeight;

            if(imageWidth/imageHeight > aspectRatio)
            {
                imageWidth = imageHeight * aspectRatio;
            }
            else
            {
                imageHeight = imageWidth / aspectRatio;
            }
        }



    }

    public void setImage(Texture2D imageTexture)
    {
        Sprite imageSprite = Sprite.Create(imageTexture, new Rect(0, 0, imageTexture.width, imageTexture.height), Vector2.one * 0.5f);
        targetImage.sprite = imageSprite;

        // 

        // rescale the image to fit the target image rect transform
        float imageWidth = targetImage.sprite.rect.width;
        float imageHeight = targetImage.sprite.rect.height;

        float imageMaxWidth = Presets.imageMaxWidth;
        float imageMaxHeight = Presets.imageMaxHeight;

        float xScale = Presets.imageMaxWidth / imageWidth;
        float yScale = Presets.imageMaxHeight / imageHeight;


        if (targetImage.preserveAspect)
        {
            float scale = Mathf.Min(xScale, yScale);
            targetImageRectTransform.localScale = new Vector3(scale, scale, 1);
        }
        else
        {
            targetImageRectTransform.localScale = new Vector3(xScale, yScale, 1);
        }
        targetImage.SetNativeSize();





        // set the image position to the top left corner of the screen
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float x = screenWidth / 2;
        float y = screenHeight / 2;

        targetImageRectTransform.localPosition = new Vector3(-x, y, 0);

        //// set the create line renderer to the image bounding box
        //imageBoudingBoxLineRenderer.positionCount = 4;
        //imageBoudingBoxLineRenderer.SetPosition(0, new Vector3(-x, y, 0));
        //imageBoudingBoxLineRenderer.SetPosition(1, new Vector3(-x + imageWidth, y, 0));
        //imageBoudingBoxLineRenderer.SetPosition(2, new Vector3(-x + imageWidth, y - imageHeight, 0));

    }


    void AdjustTransparency()
    {
        // Get the current color of the image
        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
        Color currentColor = targetImage.color;





        // Adjust the alpha (transparency) based on the mouse wheel input
        currentColor.r += scrollWheelInput;
        currentColor.g += scrollWheelInput;
        currentColor.b += scrollWheelInput;

        currentColor.r = Mathf.Clamp(currentColor.r, 0f, 1f);
        currentColor.g = Mathf.Clamp(currentColor.g, 0f, 1f);
        currentColor.b = Mathf.Clamp(currentColor.b, 0f, 1f);
        // Update the image color with the adjusted transparency
        targetImage.color = currentColor;


        if (
            (scrollWheelInput != 0 && currentColor.r == 1 && currentColor.g == 1 && currentColor.b == 1)
            ||
            (scrollWheelInput != 0 && currentColor.r == 0 && currentColor.g == 0 && currentColor.b == 0)
            )
        {
            AudioSource.PlayClipAtPoint(imageTransparencyHitBoundrySoundEffect, Camera.main.transform.position);
        }


    }


    public void ResetImageColor()
    {
        // Reset the image color to full transparency
        Color currentColor = targetImage.color;
        currentColor.r = 1f;
        currentColor.g = 1f;
        currentColor.b = 1f;
        currentColor.a = 1f;
        targetImage.color = currentColor;
    }






    public bool IsCursorOverTargetImage()
    {

        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResultList = new List<RaycastResult>();

        EventSystem.current.RaycastAll(pointerEventData, raycastResultList);

        for (int i = 0; i < raycastResultList.Count; i++)
        {
            RaycastResult raycastResult = raycastResultList[i];
            if (raycastResult.gameObject == targetImage.gameObject)
            {
                return true;
            }
        }
        return false;

    }







    public void CleanUp()
    {
        ResetImageColor();
        targetImage.enabled = false;
        targetImage.sprite = null;
    }







}
