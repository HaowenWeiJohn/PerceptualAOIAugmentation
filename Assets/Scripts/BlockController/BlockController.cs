using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    // Start is called before the first frame update

    public List<Presets.ExperimentState> experimentStates = new List<Presets.ExperimentState>();
    public Presets.ExperimentBlock experimentBlock;
    public GameManager gameManager;
    public Presets.BlockState blockState;

    int experimentStateIndex = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(gameManager.currentState.getCurrentState() == Presets.State.EndingState)
        {
            gameManager.currentState.setCurrentState(Presets.State.IdleState);
            experimentStateIndex += 1;

            if (experimentStateIndex < experimentStates.Count)
            {
                stateSelector(experimentStates[experimentStateIndex]);
                gameManager.currentState.enterState();
                onExperimentStateEntered();
            }
            else
            {
                exitBlock();
            }
        
        }
    }


    public virtual void onExperimentStateEntered()
    {

    }



    public virtual void initExperimentBlockStates()
    {
        
    }


    public void enterBlock()
    {

        // send event marker
        Debug.Log("enterBlock: " + experimentBlock);
        EnableSelf();
        gameManager.eventMarkerLSLOutletController.sendBlockOnEnterMarker(experimentBlock);
        experimentStateIndex = 0;
        stateSelector(experimentStates[experimentStateIndex]);
        gameManager.currentState.enterState();
        onExperimentStateEntered();

    }

    public void exitBlock()
    {
        // send event marker
        Debug.Log("existBlock: " + experimentBlock);
        experimentStateIndex = 0;
        gameManager.currentGameState = Presets.GameState.IdleState;
        gameManager.eventMarkerLSLOutletController.sendBlockOnExitMarker(experimentBlock);
        DisableSelf();

    }




    public void stateSelector(Presets.ExperimentState nextState)
    {
        switch (nextState)
        {
            case Presets.ExperimentState.StartState:
                gameManager.currentState = gameManager.startStateController;
                break;
            case Presets.ExperimentState.IntroductionInstructionState:
                gameManager.currentState = gameManager.introductionInstructionStateController;
                break;
            case Presets.ExperimentState.PracticeInstructionState:
                gameManager.currentState = gameManager.practiceInstructionStateController;
                break;
            case Presets.ExperimentState.TestInstructionState:
                gameManager.currentState = gameManager.testInstructionStateController;
                break;
            case Presets.ExperimentState.CalibrationState:
                gameManager.currentState = gameManager.calibrationStateController;
                break;

            /////////////////////////////////////
            case Presets.ExperimentState.NoAOIAugmentationInstructionState:
                gameManager.currentState = gameManager.noAOIAugmentationInstructionStateController;
                break;

            case Presets.ExperimentState.StaticAOIAugmentationInstructionState:
                gameManager.currentState = gameManager.staticAOIAugmentationInstructionStateController;
                break;

            case Presets.ExperimentState.InteractiveAOIAugmentationInstructionState:
                gameManager.currentState = gameManager.interactiveAOIAugmentationInstructionStateController;
                break;
            /////////////////////////////////////

            case Presets.ExperimentState.NoAOIAugmentationState:
                gameManager.currentState = gameManager.noAOIAugmentationStateController;
                break;

            case Presets.ExperimentState.StaticAOIAugmentationState:
                gameManager.currentState = gameManager.staticAOIAugmentationStateController;
                break;

            case Presets.ExperimentState.InteractiveAOIAugmentationState:
                gameManager.currentState = gameManager.interactiveAOIAugmentationStateController;
                break;

            case Presets.ExperimentState.FeedbackState:
                gameManager.currentState = gameManager.feedbackStateController;
                break;

            case Presets.ExperimentState.EndState:
                gameManager.currentState = gameManager.endStateController;
                break;

        }


    }

    public void EnableSelf()
    {
        gameObject.SetActive(true);
    }

    public void DisableSelf()
    {
        gameObject.SetActive(false);
    }

}
