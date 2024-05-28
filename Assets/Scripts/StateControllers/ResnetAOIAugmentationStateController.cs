using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Presets;

public class ResnetAOIAugmentationStateController : StateController
{
    // Start is called before the first frame update
    public AOIAugmentationStateGUIController aOIAugmentationStateGUIController;
    public int imageIndex = 0;

    // AOI Augmentation visualization overlay

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }



    public override void enterState()
    {

        //base.enterState();
        NextStateButton.onClick.AddListener(NextStateButtonClicked);
        Debug.Log("enterState: " + experimentState);
        EnableSelf();
        setCurrentState(Presets.State.RunningState);
        eventMarkerLSLOutletController.sendStateOnEnterMarker(experimentState, imageIndex);

        aOIAugmentationStateGUIController.EnableSelf();
        aOIAugmentationStateGUIController.activateResnetAOIAugmentationOverlayController();

    }

    public override void exitState()
    {

        if (!aOIAugmentationStateGUIController.AllResponseAcceptable())
        {
            return;
        }
        else
        {
            aOIAugmentationStateGUIController.SetAOIAugmentationFeedbackStateWritter();
            aOIAugmentationStateGUIController.aOIAugmentationFeedbackStateWritterController.LogCurrentTrail();
            aOIAugmentationStateGUIController.ClearResponse();
        }

        aOIAugmentationStateGUIController.deactivateResnetAOIAugmentationOverlayController();
        aOIAugmentationStateGUIController.DisableSelf();


        base.exitState();
    }
}
