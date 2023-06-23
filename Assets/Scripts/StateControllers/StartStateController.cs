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
        startStateGUIController.EnableSelf();
        base.enterState();

    }

    public override void exitState()
    {
        startStateGUIController.DisableSelf();
        base.exitState();

    }

    void startButtonOnClicked()
    {
        exitState();
    }


}
