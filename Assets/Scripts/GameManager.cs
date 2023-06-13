using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Presets.ProcessState processState;
    public Presets.ExperimentState experimentState;

    void Start()
    {
        processState = Presets.ProcessState.WelcomeState;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void WelcomeStateToInstructionState()

}
