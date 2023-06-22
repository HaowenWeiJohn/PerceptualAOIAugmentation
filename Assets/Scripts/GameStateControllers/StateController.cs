using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
    Presets.State currentState = Presets.State.IdleState;
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update() 
    {
        stateShift();
    }

    public virtual void enterState()
    {
        EnableSelf();
        setCurrentState(Presets.State.RunningState);
    }

    public virtual void exitState()
    {
        DisableSelf();
        setCurrentState(Presets.State.EndingState);
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
        gameObject.SetActive(true);
    }

    public Presets.State getCurrentState()
    {
        return currentState;
    }

    public void setCurrentState(Presets.State newState)
    {
        currentState = newState;
    }

    public void stateShift()
    {
        // check the key press and do state shfit
        if (Input.GetKeyDown(Presets.NextStateKey))
        {
            currentState = Presets.State.EndingState;
        }
        if (Input.GetKeyDown(Presets.InterruptKey))
        {
            currentState = Presets.State.InterruptState;
        }
    }

}
