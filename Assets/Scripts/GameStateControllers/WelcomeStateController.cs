using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeStateController : MonoBehaviour
{


    public GameManager gameManager;

    public GameObject WelcomeStateGUI;
    public Button StartGameButton;


    // Start is called before the first frame update
    void Start()
    {
        StartGameButton.onClick.AddListener(exitState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGameButtonOnClicked()
    {
        gameObject.SetActive(false);
    }


    public void enterState()
    {
        WelcomeStateGUI.SetActive(true);
    }

    public void exitState()
    {
        WelcomeStateGUI.SetActive(false);
    }



    public void OnEnable()
    {
        enterState();
    }


    public void OnDisable()
    {
        exitState();   
    }


    

}
