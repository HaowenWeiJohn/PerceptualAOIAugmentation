using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalibrationStateGUIController : GUIController
{

    [Header("Game Manager")]
    public GameManager gameManager;

    [Header("Buttons")]
    public Button NextStateButton;
    public Button CalibrationNextButton;

    [Header("UI Element")]
    public GameObject buttonCover;
    public GameObject text;

    [Header("GazeOverlay")]
    public GameObject GazeOverlay;

    [Header("Calibration Dots")]
    public List<GameObject> dots = new List<GameObject>();

    private int calibrationDotIndex = -1;
    private CalibrationDotController calibrationDotController = null;
    private bool calibrationDone = false;
    private bool showCalibration = false;

    // Start is called before the first frame update
    void Start()
    {
        CalibrationNextButton.onClick.AddListener(Calibrate);
    }

    private void OnEnable()
    {
        Reset();
        if(gameManager.skipCalibration == true)
        {
            NextStateButton.interactable = true;
            NextStateButton.onClick.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (showCalibration)
        {

            if (calibrationDotIndex == -1)
            {
                calibrationDotIndex++;
                Debug.Log("index++: " + calibrationDotIndex);
                dots[calibrationDotIndex].SetActive(true);
                calibrationDotController = dots[calibrationDotIndex].GetComponent<CalibrationDotController>();
            }

            if (calibrationDotIndex < dots.Count)
            {
                if (calibrationDotController.isComplete())
                {
                    calibrationDotController.Hide();
                    Debug.Log("dot #" + calibrationDotIndex + " complete");
                    calibrationDotIndex++;
                    if (calibrationDotIndex < dots.Count)
                    {
                        calibrationDotController = dots[calibrationDotIndex].GetComponent<CalibrationDotController>();
                        calibrationDotController.Show();
                    }
                }
            }

            if (calibrationDotIndex == dots.Count)
            {
                foreach (GameObject dot in dots)
                {
                    calibrationDotController = dot.GetComponent<CalibrationDotController>();
                    calibrationDotController.Show();
                }
                calibrationDotController = null;
                CalibrationNextButton.gameObject.SetActive(false);
                buttonCover.SetActive(false);
            }
        }

        if (Input.GetKeyDown(Presets.ForceEnableSubmitResponseKey))
        {
            NextStateButton.interactable = true;
        }


        base.Update();
    }

    private void Calibrate()
    {
        text.SetActive(false);
        buttonCover.SetActive(true);
        showCalibration = true;


    }

    private void Reset()
    {
        GazeOverlay.GetComponent<Renderer>().enabled = false;
        showCalibration = false;
        text.SetActive(true);
        CalibrationNextButton.gameObject.SetActive(true);
        NextStateButton.interactable = false;
        showCalibration = false;

        calibrationDotIndex = -1;
        GameObject[] resultDots = GameObject.FindGameObjectsWithTag("resultDot");
        foreach (GameObject dot in resultDots)
        {
            Destroy(dot);
        }
        foreach (GameObject dot in dots)
        {
            calibrationDotController = dot.GetComponent<CalibrationDotController>();
            calibrationDotController.Reset();
        }
    }

}
