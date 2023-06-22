using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartStateController : StateController
{




    public StartStateGUIController startStateGUIController;


    // Start is called before the first frame update
    void Start()
    {

        startStateGUIController.startButton.onClick.AddListener(startButtonOnClicked);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }


    public override void enterState()
    {
        base.enterState();
        startStateGUIController.EnableSelf();
    }

    public override void exitState()
    {
        base.exitState();
        startStateGUIController.DisableSelf();
    }

    void startButtonOnClicked()
    {
        exitState();
    }


}
