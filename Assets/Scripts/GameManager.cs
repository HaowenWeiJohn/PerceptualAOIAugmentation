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
    public IntroductionStateController introductionStateController;

    int experimentStateIndex = 0;

    void Start()
    {
        experimentStateIndex = 0;
        expermentProcedure.Add(Presets.ExperimentState.StartState);
        expermentProcedure.Add(Presets.ExperimentState.IntroductionInstructionState);

        stateSelector(expermentProcedure[experimentStateIndex]);
        currentGameState.enterState();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentGameState.getCurrentState()==Presets.State.EndingState)
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
                currentGameState = introductionStateController;
                break;
        }


    }

    //void WelcomeStateToInstructionState()

}
