using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class StateController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
    public Presets.ExperimentState experimentState;

    Presets.State currentState = Presets.State.IdleState;

    public EventMarkerLSLOutletController eventMarkerLSLOutletController;

    [Header("Next State Button")]
    public Button NextStateButton;

    void Start()
    {
        //eventMarkerLSLOutletController = GameObject.Find("Game").compopen;
    }

    // Update is called once per frame
    protected virtual void Update() 
    {
        //stateShift(); // we only use button now
    }

    public virtual void enterState()
    {
        NextStateButton.onClick.AddListener(NextStateButtonClicked);

        Debug.Log("enterState: "+ experimentState);
        EnableSelf();
        setCurrentState(Presets.State.RunningState);

        eventMarkerLSLOutletController.sendStateOnEnterMarker(experimentState);

    }

    public virtual void exitState()
    {
        NextStateButton.onClick.RemoveListener(NextStateButtonClicked);

        Debug.Log("exitState: " + experimentState);
        DisableSelf();
        setCurrentState(Presets.State.EndingState);

        eventMarkerLSLOutletController.sendStateOnExitMarker(experimentState);
    }


    public virtual void interruptState()
    {
        DisableSelf();
        setCurrentState(Presets.State.InterruptState);

        //eventMarkerLSLOutletController.sendStateOnInterruptMarker();
    }


    //public virtual void OnEnable()
    //{
    //    enterState();
    //}


    //public virtual void OnDisable()
    //{
    //    exitState();
    //}

    public void EnableSelf()
    {
        gameObject.SetActive(true);
    }

    public void DisableSelf()
    {
        gameObject.SetActive(false); 
    }

    public Presets.State getCurrentState()
    {
        return currentState;
    }

    public void setCurrentState(Presets.State newState)
    {
        currentState = newState;
    }

    //public void stateShift()
    //{
    //    // check the key press and do state shfit
    //    if (Input.GetKeyDown(Presets.NextStateKey))
    //    {
    //        exitState();
    //    }
    //    if (Input.GetKeyDown(Presets.InterruptKey))
    //    {
    //        currentState = Presets.State.InterruptState;
    //    }
    //}

    public void NextStateButtonClicked()
    {
        // set to not selected
        NextStateButton.interactable = false;
        NextStateButton.interactable = true;
        exitState();
    }

}
