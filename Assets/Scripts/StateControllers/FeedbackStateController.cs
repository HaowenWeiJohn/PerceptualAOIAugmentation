using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackStateController : StateController
{
    // Start is called before the first frame update

    public FeedbackStateGUIController feedbackStateGUIController;

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
        feedbackStateGUIController.EnableSelf();
        base.enterState();

    }

    public override void exitState()
    {
        feedbackStateGUIController.DisableSelf();
        base.exitState();

    }




}
