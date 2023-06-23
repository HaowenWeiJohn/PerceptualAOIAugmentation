using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public StateController currentGameState;
    public List<Presets.ExperimentState> expermentProcedure = new List<Presets.ExperimentState>();

    /// <summary>
    ///  avaliable states
    /// </summary>
    /// 

    public StartStateController startStateController;
    public IntroductionInstructionStateController introductionInstructionStateController;
    public PracticeInstructionStateController practiceInstructionStateController;
    public CalibrationStateController calibrationStateController ;

    public NoAOIAugmentationStateController noAOIAugmentationStateController;
    public StaticAOIAugmentationStateController staticAOIAugmentationStateController;
    public InteractiveAOIAugmentationStateController interactiveAOIAugmentationStateController;

    public EndStateController endStateController;


    int experimentStateIndex = 0;

    void Start()
    {
        experimentStateIndex = 0;
        expermentProcedure.Add(Presets.ExperimentState.StartState);
        expermentProcedure.Add(Presets.ExperimentState.IntroductionInstructionState);
        expermentProcedure.Add(Presets.ExperimentState.PracticeInstructionState);
        expermentProcedure.Add(Presets.ExperimentState.CalibrationState);
        expermentProcedure.Add(Presets.ExperimentState.NoAOIAugmentationState);
        expermentProcedure.Add(Presets.ExperimentState.PracticeInstructionState);
        expermentProcedure.Add(Presets.ExperimentState.NoAOIAugmentationState);
        expermentProcedure.Add(Presets.ExperimentState.PracticeInstructionState);
        expermentProcedure.Add(Presets.ExperimentState.StaticAOIAugmentationState);
        expermentProcedure.Add(Presets.ExperimentState.IntroductionInstructionState);
        expermentProcedure.Add(Presets.ExperimentState.InteractiveAOIAugmentationState);
        expermentProcedure.Add(Presets.ExperimentState.EndState);


        stateSelector(expermentProcedure[experimentStateIndex]);
        currentGameState.enterState();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentGameState.getCurrentState()==Presets.State.EndingState && currentGameState!=endStateController)
        {
            // reset previous state
            currentGameState.setCurrentState(Presets.State.IdleState);
            experimentStateIndex += 1;
            // get new current state
            stateSelector(expermentProcedure[experimentStateIndex]);
            // activate current state
            currentGameState.enterState();
            Debug.Log("State Updated");
        }
    }


    public void stateSelector(Presets.ExperimentState nextState)
    {
        switch (nextState)
        {
            case Presets.ExperimentState.StartState:
                currentGameState = startStateController;
                break;
            case Presets.ExperimentState.IntroductionInstructionState:
                currentGameState = introductionInstructionStateController;
                break;
            case Presets.ExperimentState.PracticeInstructionState:
                currentGameState = practiceInstructionStateController;
                break;
            case Presets.ExperimentState.CalibrationState:
                currentGameState = calibrationStateController;
                break;


            case Presets.ExperimentState.NoAOIAugmentationState:
                currentGameState = noAOIAugmentationStateController;
                break;

            case Presets.ExperimentState.StaticAOIAugmentationState:
                currentGameState = staticAOIAugmentationStateController;
                break;

            case Presets.ExperimentState.InteractiveAOIAugmentationState:
                currentGameState = interactiveAOIAugmentationStateController;
                break;

            case Presets.ExperimentState.EndState:
                currentGameState = endStateController;
                break;


        }


    }

    //void WelcomeStateToInstructionState()

}
