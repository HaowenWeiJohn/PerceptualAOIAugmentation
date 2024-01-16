using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [Header("Survey Components")]
    public ToggleGroup GlaucomaDecisionToggleGroup;
    // message box
    public TMP_InputField MessageBox;

    [Header("Game Manager")]
    public GameManager gameManager;


    [Header("Logger")]
    public AOIAugmentationFeedbackStateWritterController aOIAugmentationFeedbackStateWritterController;


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


    public void ClearResponse()
    {
        GlaucomaDecisionToggleGroup.SetAllTogglesOff();
        MessageBox.text = "";
    }


    public string GetGlaucomaDecision()
    {
        int index = 0;
        foreach (Toggle toggle in GlaucomaDecisionToggleGroup.ActiveToggles())
        {
            index = GlaucomaDecisionToggleGroup.transform.GetSiblingIndex();
        }
        return index == 0 ? "S" : "G";
    }

    public bool ResponseAcceptable()
    {
        if (GlaucomaDecisionToggleGroup.AnyTogglesOn() && MessageBox.text != "")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetAOIAugmentationFeedbackStateWritter()
    {
        aOIAugmentationFeedbackStateWritterController.Block = Enum.GetName(typeof(Presets.ExperimentBlock), gameManager.currentBlock.experimentBlock);
        aOIAugmentationFeedbackStateWritterController.InteractionMode = Enum.GetName(typeof(Presets.ExperimentState), gameManager.currentState.experimentState);

        aOIAugmentationFeedbackStateWritterController.ImageName = targetImageController.imageName;
        aOIAugmentationFeedbackStateWritterController.GlaucomaGroundTruth = targetImageController.imageType;

        aOIAugmentationFeedbackStateWritterController.GlaucomaDecision = GetGlaucomaDecision();
        aOIAugmentationFeedbackStateWritterController.Message = MessageBox.text;

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
