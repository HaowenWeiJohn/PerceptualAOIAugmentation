using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveAOIAugmentationStateController : StateController
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
        aOIAugmentationStateGUIController.activateInteractiveAOIAugmentationOverlayController();
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

        aOIAugmentationStateGUIController.deactivateInteractiveAOIAugmentationOverlayController();
        aOIAugmentationStateGUIController.DisableSelf();


        base.exitState();
    }


}
