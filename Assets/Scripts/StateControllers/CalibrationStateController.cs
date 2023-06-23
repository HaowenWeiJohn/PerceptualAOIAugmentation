using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationStateController : StateController
{
    public CalibrationStateGUIController calibrationStateGUIController;
    // Start is called before the first frame update
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
    }

    public override void exitState()
    {
        base.exitState();
        calibrationStateGUIController.DisableSelf();
    }


}
