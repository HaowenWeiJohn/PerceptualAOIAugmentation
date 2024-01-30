using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalibrationStateGUIController : GUIController
{

    [Header("Buttons")]
    public Button NextStateButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    private void OnEnable()
    {
        NextStateButton.interactable = false;
    }

}
