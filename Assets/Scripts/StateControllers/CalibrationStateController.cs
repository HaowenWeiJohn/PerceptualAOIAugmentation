using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationStateController : StateController
{
    public CalibrationStateGUIController calibrationStateGUIController;
    // Start is called before the first frame update

    public TobiiGazeOverlayController tobiiGazeOverlayController;
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

        base.enterState();
        calibrationStateGUIController.EnableSelf();
        tobiiGazeOverlayController.EnableGazeOverlay();
    }

    public override void exitState()
    {
        base.exitState();
        calibrationStateGUIController.DisableSelf();
        tobiiGazeOverlayController.DisableGazeOverlay();
    }


}
