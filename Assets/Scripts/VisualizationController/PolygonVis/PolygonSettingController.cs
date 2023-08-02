using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonSettingController : MonoBehaviour
{

    [SerializeField]
    private KeyCode _switchKey = KeyCode.None;
    [SerializeField]
    private GameObject SettingWindow;

    private bool settingOn = false; 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(_switchKey)) 
        {
            settingOn = !settingOn;
            SettingWindow.SetActive(settingOn);
        }
    }
}
