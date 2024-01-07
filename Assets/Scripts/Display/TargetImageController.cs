using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
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

    void Start()
    {
        updateTargetImageInfo();
    }

    // Update is called once per frame
    void Update()
    {
        updateTargetImageInfo();
    }

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
        //targetImage.SetNativeSize();
    }






}
