using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveAOIAugmentationInstructionStateController : StateController
{
    // Start is called before the first frame update
    public InstructionStateGUIController instructionStateGUIController;
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
        instructionStateGUIController.EnableSelf();
        instructionStateGUIController.setInstructionTitle("I");
        instructionStateGUIController.setInstructionContent("Instruction Content");
    }

    public override void exitState()
    {
        base.exitState();
        instructionStateGUIController.DisableSelf();
    }
}
