using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionStateController : StateController
{

    public InstructionStateGUI instructionStateGUI;
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
        instructionStateGUI.SetEnabled();
        instructionStateGUI.setInstructionTitle("Instructions");
        instructionStateGUI.setInstructionContent("Instruction Content");
    }

    public override void exitState()
    {
        base.exitState();
        instructionStateGUI.SetDisabled();
    }


}
