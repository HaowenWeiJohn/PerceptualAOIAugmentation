using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Presets.ProcessState currentState;
    //public Presets.ExperimentState experimentState;
    public  

    void Start()
    {
        currentState = Presets.ProcessState.WelcomeState;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void WelcomeStateToInstructionState()

}
