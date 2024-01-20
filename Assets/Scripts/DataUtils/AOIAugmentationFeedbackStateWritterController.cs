using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


public class AOIAugmentationFeedbackStateWritterController : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Logging")]
    public bool logging = false;


    [Header("Experiment Info")]
    //public string ParticipantID = "0";

    private static readonly string[] ColumnNames = {"CurrentBlock", "InteractionMode", "ImageName", "GlaucomaGroundTruth", "GlaucomaDecision", "Message", "DecisionConfidenceLevel"};
    public string FileName; 
    public bool useCustomLogPath = false;
    public string customLogPath = "";


    public GameManager gameManager;

    public string Block = "";
    public string InteractionMode = "";
    public string ImageName = "";
    public string GlaucomaGroundTruth = "";

    public string GlaucomaDecision = "";
    public string Message = "";
    public string DecisionConfidenceLevel = "";


    private StreamWriter writer = null;


    string ExperimentName = "";
    string ParticipantID = "";

    void Start()
    {

        //if gameManager.userStudy =
        if (gameManager.userStudy == Presets.UserStudy.UserStudy1)
        {
            ExperimentName = "ROIAugmentationUserSutyd1";
        }
        else if (gameManager.userStudy == Presets.UserStudy.UserStudy2)
        {
            ExperimentName = "ROIAugmentationUserStudy2";
        }

        ParticipantID = gameManager.participantID;

        string logPath = useCustomLogPath ? customLogPath : Application.dataPath + "/Logs/";
        Directory.CreateDirectory(logPath);


        DateTime now = DateTime.Now;
        string timeString = string.Format("{0}-{1:00}-{2:00}-{3:00}-{4:00}-{5:00}", now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
        string fileName = timeString + "_" + ExperimentName + "_" + ParticipantID + ".csv";

        string path = logPath + fileName;

        if (logging)
        {
            writer = new StreamWriter(path, true);
            Log(ColumnNames);
            Debug.Log("Logging to: " + path);
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Log(string[] values)
    {
        if (!logging || writer == null)
            return;

        string line = "";
        for (int i = 0; i < values.Length; ++i)
        {
            values[i] = values[i].Replace("\r", "").Replace("\n", ""); // Remove new lines so they don't break csv
            line += values[i] + (i == (values.Length - 1) ? "" : ","); // Do not add semicolon to last data string
        }
        writer.WriteLine(line);
    }

    public void LogCurrentTrail()
    {
        if (!logging || writer == null)
            return;

        Message = "\"" + Message + "\"";
        string[] values = { Block, InteractionMode, ImageName, GlaucomaGroundTruth, GlaucomaDecision, Message, DecisionConfidenceLevel };
        //string[] values = { Block, InteractionMode, ImageName, GlaucomaDecision, Message, DecisionConfidenceLevel };
        Debug.Log("Logging: " + values);
        Log(values);
    }


    void StopLogging()
    {
        if (!logging)
            return;

        if (writer != null)
        {
            writer.Flush();
            writer.Close();
            writer = null;
        }
        logging = false;
        Debug.Log("Logging ended");
    }

    void OnApplicationQuit()
    {
        StopLogging();
    }

}
