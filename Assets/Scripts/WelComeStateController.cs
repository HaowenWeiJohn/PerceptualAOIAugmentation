using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelComeStateController : MonoBehaviour
{


    public GameManager gameManager;

    public GameObject WelcomeStateGUI;
    public Button StartGameButton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnEnable()
    {
        WelcomeStateGUI.SetActive(true);
    }


    public void OnDisable()
    {
        WelcomeStateGUI.SetActive(false);
    }


    

}
