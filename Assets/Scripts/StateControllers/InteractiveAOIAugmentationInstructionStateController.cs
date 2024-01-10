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

        if (gameManager.currentBlock.experimentBlock == Presets.ExperimentBlock.PracticeBlock)
        {
            instructionStateGUIController.setInstructionTitle(Presets.PracticeInteractiveAOIAugmentationInstructionStateTitle);
            instructionStateGUIController.setInstructionContent(Presets.PracticeInteractiveAOIAugmentationInstructionStateContent);
        }
        else if (gameManager.currentBlock.experimentBlock == Presets.ExperimentBlock.TestBlock)
        {
            instructionStateGUIController.setInstructionTitle(Presets.TestInteractiveAOIAugmentationInstructionStateTitle);
            instructionStateGUIController.setInstructionContent(Presets.TestInteractiveAOIAugmentationInstructionStateContent);
        }

    }

    public override void exitState()
    {
        base.exitState();
        instructionStateGUIController.DisableSelf();
    }
}
