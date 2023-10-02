using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerArchive : MonoBehaviour
{

    public StateController currentGameState;
    public List<Presets.ExperimentState> expermentProcedure = new List<Presets.ExperimentState>();

    /// <summary>
    ///  avaliable states
    /// </summary>
    /// 
    [Header("Start State")]
    public StartStateController startStateController;

    [Header("Introduction State")]
    public IntroductionInstructionStateController introductionInstructionStateController;

    [Header("Practice Instruction State")]
    public PracticeInstructionStateController practiceInstructionStateController;

    [Header("Calibration State")]
    public CalibrationStateController calibrationStateController ;

    [Header("NoAOIAugmentationState")]
    public NoAOIAugmentationInstructionStateController noAOIAugmentationInstructionStateController;
    public NoAOIAugmentationStateController noAOIAugmentationStateController;

    [Header("StaticAOIAugmentationState")]
    public StaticAOIAugmentationInstructionStateController staticAOIAugmentationInstructionStateController;
    public StaticAOIAugmentationStateController staticAOIAugmentationStateController;

    [Header("InteractiveAOIAugmentationState")]
    public InteractiveAOIAugmentationInstructionStateController interactiveAOIAugmentationInstructionStateController;
    public InteractiveAOIAugmentationStateController interactiveAOIAugmentationStateController;

    [Header("FeedbackState")]
    public FeedbackStateController feedbackStateController;

    [Header("EndState")]
    public EndStateController endStateController;



    [Header("Network Controllers")]
    public EventMarkerLSLOutletController eventMarkerLSLOutletController;
    public TobiiProGazeDataLSLOutletController tobiiProGazeDataOutletLSLController;

    

    int experimentStateIndex = 0;

    void Start()
    {
        experimentStateIndex = 0;
        //expermentProcedure.Add(Presets.ExperimentState.StartState);
        //expermentProcedure.Add(Presets.ExperimentState.NoAOIAugmentationInstructionState);
        //expermentProcedure.Add(Presets.ExperimentState.StaticAOIAugmentationInstructionState);
        //expermentProcedure.Add(Presets.ExperimentState.InteractiveAOIAugmentationInstructionState);
        //expermentProcedure.Add(Presets.ExperimentState.IntroductionInstructionState);
        //expermentProcedure.Add(Presets.ExperimentState.PracticeInstructionState);
        //expermentProcedure.Add(Presets.ExperimentState.CalibrationState);
        //expermentProcedure.Add(Presets.ExperimentState.NoAOIAugmentationState);
        //expermentProcedure.Add(Presets.ExperimentState.PracticeInstructionState);
        //expermentProcedure.Add(Presets.ExperimentState.NoAOIAugmentationState);
        //expermentProcedure.Add(Presets.ExperimentState.PracticeInstructionState);
        //expermentProcedure.Add(Presets.ExperimentState.StaticAOIAugmentationState);
        //expermentProcedure.Add(Presets.ExperimentState.IntroductionInstructionState);
        //expermentProcedure.Add(Presets.ExperimentState.InteractiveAOIAugmentationState);
        //expermentProcedure.Add(Presets.ExperimentState.EndState);

        expermentProcedure = ExperimentPreset.ConstructExperimentStates();

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

            /////////////////////////////////////
            case Presets.ExperimentState.NoAOIAugmentationInstructionState:
                currentGameState = noAOIAugmentationInstructionStateController;
                break;

            case Presets.ExperimentState.StaticAOIAugmentationInstructionState:
                currentGameState = staticAOIAugmentationInstructionStateController;
                break;

            case Presets.ExperimentState.InteractiveAOIAugmentationInstructionState:
                currentGameState = interactiveAOIAugmentationInstructionStateController;
                break;
            /////////////////////////////////////

            case Presets.ExperimentState.NoAOIAugmentationState:
                currentGameState = noAOIAugmentationStateController;
                break;

            case Presets.ExperimentState.StaticAOIAugmentationState:
                currentGameState = staticAOIAugmentationStateController;
                break;

            case Presets.ExperimentState.InteractiveAOIAugmentationState:
                currentGameState = interactiveAOIAugmentationStateController;
                break;

            case Presets.ExperimentState.FeedbackState:
                currentGameState = feedbackStateController;
                break;

            case Presets.ExperimentState.EndState:
                currentGameState = endStateController;
                break;


        }


    }

    //void WelcomeStateToInstructionState()

}
