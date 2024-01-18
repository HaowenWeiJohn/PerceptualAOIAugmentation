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
    public ResnetAOIAugmentationOverlayController resnetAOIAugmentationOverlayController;

    [Header("Survey Components")]
    public ToggleGroup GlaucomaDecisionToggleGroup;
    public TMP_InputField MessageBox;
    public ToggleGroup ConfidenceLevelToggleGroup;

    [Header("Game Manager")]
    public GameManager gameManager;


    [Header("Logger")]
    public AOIAugmentationFeedbackStateWritterController aOIAugmentationFeedbackStateWritterController;

    [Header("Buttons")]
    public Button SubmitResponseButton;
    public Button NextStateButton;

    [Header("SubmitResponseButton Clicked")]
    public AudioClip submitResponseButtonClickedAudio;


    [Header("Scene Group")]
    public GameObject TrailGUI;
    public GameObject ConfidenceLevelFeedbackGroup;

    [Header("Event Marker")]
    public EventMarkerLSLOutletController eventMarkerLSLOutletController;

    [Header("AOI Augmentation Cursor Overlay Controller")]
    public CursorOverlayController cursorOverlayController;

    void Start()
    {
        SubmitResponseButton.onClick.AddListener(SubmitResponseButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        if (TrailResponseAcceptable())
        {
            SubmitResponseButton.interactable = true;
        }
        else
        {
            SubmitResponseButton.interactable = false;
        }

        if (ConfidenceLevelResponseAcceptable())
        {
            NextStateButton.interactable = true;
        }
        else
        {
            NextStateButton.interactable = false;
        }
        
    }

    public void setImage(Texture2D imageTexture)
    {
        targetImageController.setImage(imageTexture);
    }


    public void SubmitResponseButtonClicked()
    {
        //GetIndexOfSelection();
        
        if (!TrailResponseAcceptable())
        {
            return;
        }
        else
        {
            SetAnswerConfidenceLevelGUI();
            // end AOIAugmentation Interaction
            cursorOverlayController.DeactivateCursorLoadingImage();

            eventMarkerLSLOutletController.sendAOIAugmentationInteractionEndMarker();

            AudioSource.PlayClipAtPoint(submitResponseButtonClickedAudio, Camera.main.transform.position);
        }

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



    public void activateResnetAOIAugmentationOverlayController()
    {
        resnetAOIAugmentationOverlayController.EnableSelf();
    }


    public void deactivateResnetAOIAugmentationOverlayController()
    {
        resnetAOIAugmentationOverlayController.DisableSelf();
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
        ClearConfidenceLevelToggleGroup();
        MessageBox.text = "";
        ClearGlaucomaDecisionToggleGroup();
    }


    public string GetGlaucomaDecision()
    {
        //int index = 0;
        //foreach (Toggle toggle in GlaucomaDecisionToggleGroup.ActiveToggles())
        //{
        //    index = GlaucomaDecisionToggleGroup.transform.GetSiblingIndex();
        //}
        //return index == 0 ? "S" : "G";


        // Get all toggles in the ToggleGroup
        Toggle[] toggles = GlaucomaDecisionToggleGroup.GetComponentsInChildren<Toggle>();

        // Iterate through the toggles to find the turned-on (selected) one
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn)
            {
                // Return the index of the turned-on Toggle
                return i == 0 ? "S" : "G";
            }
        }

        // If no Toggle is turned on, return -1 or handle it accordingly
        return null;
    }


    public void ClearGlaucomaDecisionToggleGroup()
    {
        Toggle[] toggles = GlaucomaDecisionToggleGroup.GetComponentsInChildren<Toggle>();

        // Iterate through the toggles to find the turned-on (selected) one
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn)
            {
                // Return the index of the turned-on Toggle
                toggles[i].isOn = false;
            }
        }
    }




    public string GetConfidenceLevelSelection()
    {
        Toggle[] toggles = ConfidenceLevelFeedbackGroup.GetComponentsInChildren<Toggle>();

        // Iterate through the toggles to find the turned-on (selected) one
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn)
            {
                // Return the index of the turned-on Toggle
                return i.ToString();
            }
        }

        return null;
    }


    public void ClearConfidenceLevelToggleGroup()
    {
        Toggle[] toggles = ConfidenceLevelFeedbackGroup.GetComponentsInChildren<Toggle>();

        // Iterate through the toggles to find the turned-on (selected) one
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn)
            {
                // Return the index of the turned-on Toggle
                toggles[i].isOn = false;
            }
        }
    }


    public bool TrailResponseAcceptable()
    {
        //GetGlaucomaDecision();
        if (GetGlaucomaDecision()!=null && MessageBox.text.Length>=3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ConfidenceLevelResponseAcceptable()
    {
        if (GetConfidenceLevelSelection()!=null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool AllResponseAcceptable()
    {
        if (TrailResponseAcceptable() && ConfidenceLevelResponseAcceptable())
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

        aOIAugmentationFeedbackStateWritterController.DecisionConfidenceLevel = GetConfidenceLevelSelection();

    }




    public override void EnableSelf()
    {
        base.EnableSelf();
        //Cursor.visible = false;
        SetTrailStartGUI();
        targetImageController.CleanUp();

    }

    public override void DisableSelf()
    {
        base.DisableSelf();
        //Cursor.visible = true;
        SetTrailEndGUI();
        targetImageController.CleanUp();
    }


    public void SetTrailStartGUI()
    {
        TrailGUI.SetActive(true);
        ConfidenceLevelFeedbackGroup.SetActive(false);
        NextStateButton.gameObject.SetActive(false);
    }

    public void SetTrailEndGUI()
    {
        TrailGUI.SetActive(false);
        ConfidenceLevelFeedbackGroup.SetActive(false);
        NextStateButton.gameObject.SetActive(true);
    }

    public void SetAnswerConfidenceLevelGUI()
    {
        TrailGUI.SetActive(false);
        ConfidenceLevelFeedbackGroup.SetActive(true);
        NextStateButton.gameObject.SetActive(true);
    }



}
