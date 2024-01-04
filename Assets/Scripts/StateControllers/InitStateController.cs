using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitStateController : StateController
{




    public InitStateGUIController initStateGUIController;


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
        initStateGUIController.EnableSelf();
        base.enterState();

    }

    public override void exitState()
    {
        initStateGUIController.DisableSelf();
        base.exitState();

    }




}
