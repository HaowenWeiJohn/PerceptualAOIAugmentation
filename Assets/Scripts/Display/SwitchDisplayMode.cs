using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDisplayMode : MonoBehaviour
{
    public bool fullScreenOn = false;

    [SerializeField]
    private KeyCode _switchKey = KeyCode.None;

    private void Start()
    {
        //Screen.SetResolution(1920, 1080, false);
        //Screen.fullScreenMode = FullScreenMode.Windowed;
        Screen.fullScreen = fullScreenOn;
    }

    private void Update() 
    {
        if(Input.GetKeyDown(_switchKey)) 
        {
            Debug.Log(_switchKey + " key pressed");
            switchDisplayMode(!fullScreenOn);
            fullScreenOn = !fullScreenOn;
            Debug.Log("Full screen mode: " + fullScreenOn);

        }
    }

    public void switchDisplayMode (bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }

}
