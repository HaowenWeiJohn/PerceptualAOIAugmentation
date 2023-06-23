using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStateController : StateController
{
    // Start is called before the first frame update
    public EndStateGUIController endStateGUIController;
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
        endStateGUIController.EnableSelf();
        base.enterState();

    }

    public override void exitState()
    {
        endStateGUIController.DisableSelf();
        base.exitState();

    }
}
