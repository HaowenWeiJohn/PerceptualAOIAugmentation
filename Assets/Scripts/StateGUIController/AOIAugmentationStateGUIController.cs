using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AOIAugmentationStateGUIController : GUIController
{
    // Start is called before the first frame update
    public TargetImageController targetImageController;

    [Header("AOI Augmentation Overlay Controller")]
    public NoAOIAugmentationOverlayController noAOIAugmentationOverlayController;
    public StaticAOIAugmentationOverlayController staticAOIAugmentationOverlayController;
    public InteractiveAOIAugmentationOverlayController interactiveAOIAugmentationOverlayController;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public void setImage(Texture2D imageTexture)
    {
        targetImageController.setImage(imageTexture);
    }


    /// <summary>
    /// ////////////////////////////////
    /// 
    /// </summary>
    public void activateNoAOIAugmentationOverlayController()
    {
        noAOIAugmentationOverlayController.EnableSelf();
    }


    public void deactivateNoAOIAugmentationOverlayController()
    {
        noAOIAugmentationOverlayController.DisableSelf();
    }


    /// <summary>
    /// ////////////////////////////////
    /// 
    /// </summary>
    public void activateStaticAOIAugmentationOverlayController()
    {
        //staticAOIAugmentationOverlayController.RemoveOverlayElements(); // clear all contours
        staticAOIAugmentationOverlayController.EnableSelf();
    }


    public void deactivateStaticAOIAugmentationOverlayController()
    {
        //staticAOIAugmentationOverlayController.RemoveOverlayElements(); // clear all contours
        staticAOIAugmentationOverlayController.DisableSelf();
    }


    /// <summary>
    /// ////////////////////////////////
    /// 
    /// </summary>
    public void activateInteractiveAOIAugmentationOverlayController()
    {
        //interactiveAOIAugmentationOverlayController.RemoveOverlayElements();
        interactiveAOIAugmentationOverlayController.EnableSelf();
    }


    public void deactivateInteractiveAOIAugmentationOverlayController()
    {
        //interactiveAOIAugmentationOverlayController.RemoveOverlayElements();
        interactiveAOIAugmentationOverlayController.DisableSelf();
    }

    public override void EnableSelf()
    {
        base.EnableSelf();
        //Cursor.visible = false;
        targetImageController.ResetImageColor();

    }

    public override void DisableSelf()
    {
        base.DisableSelf();
        //Cursor.visible = true;
        targetImageController.ResetImageColor();
    }

}
