using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackStateGUIController : GUIController
{
    // Start is called before the first frame update

    public ToggleGroup ConfidenceLevelToggleGroup;


    [Header("Logger")]
    public AOIAugmentationFeedbackStateWritterController aOIAugmentationFeedbackStateWritterController;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ClearResponses()
    {
        ConfidenceLevelToggleGroup.SetAllTogglesOff();
    }

    public int GetIndexOfSelection()
    {
        int index = 0;
        foreach (Toggle toggle in ConfidenceLevelToggleGroup.ActiveToggles())
        {
            index = ConfidenceLevelToggleGroup.transform.GetSiblingIndex();
        }
        return index;
    }




    public bool ResponseAcceptable()
    {
        if (ConfidenceLevelToggleGroup.AnyTogglesOn())
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
        aOIAugmentationFeedbackStateWritterController.DecisionConfidenceLevel = GetIndexOfSelection().ToString();
    }

    public void LogResponse()
    {
        aOIAugmentationFeedbackStateWritterController.LogCurrentTrail();
    }

    public void EnableSelf()
    {

        base.EnableSelf();
    }

    public void DisableSelf()
    {

        base.DisableSelf();
    }


}
