using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class Presets
{




    public static string EventMarkerLSLOutletStreamName = "AOIAugmentationEventMarkerLSLOutlet";
    public static string EventMarkerLSLOutletStreamType = "EventMarker";
    public static string EventMarkerLSLOutletStreamID = "1";
    public static int EventMarkerChannelNum = 4; // block marker index 0
    public static float EventMarkerNominalSamplingRate = 1;


    public enum EventMarkerChannelInfo
    {
        BlockChannelIndex = 0,
        ExperimentStateChannelIndex = 1,
        ImageIndexChannelIndex = 2,
        InterruptLabelChannelIndex = 3, // the 0-5 is row, 7-11 is column
    }


    public static string GazeDataLSLOutletStreamName = "TobiiProFusionUnityLSLOutlet";
    public static string GazeDataLSLOutletStreamType = "GazeData";
    public static string GazeDataLSLOutletStreamID = "2";
    public static int GazeDataChannelNum = 51;
    public static float GazeDataNominalSamplingRate = 250;

    // AOIAugmentationAttentionContourStream inlet stream name
    public static string AOIAugmentationAttentionContourStreamLSLInletStreamName = "AOIAugmentationAttentionContourStream";





    //public static Vector2Int AttentionGridShape = new Vector2Int(32, 32);
    //public static Vector2Int OriginalImageShape = new Vector2Int(512, 1024);

    //public static string StaticAOIAugmentationStateLSLInletStreamName = "StaticAOIAugmentationStateLSLInlet";
    //public static string StaticAOIAugmentationStateLSLInletStreamType = "AOIAugmentationInlet";
    //public static string StaticAOIAugmentationStateLSLInletStreamID = "3";
    //public static int StaticAOIAugmentationStateLSLInletChannelNum = AttentionGridShape[0] * AttentionGridShape[1];
    //public static float StaticAOIAugmentationStateLSLInletNominalSamplingRate = 10;






    public static string GameManagerName = "GameManager";

    public static int MaxScore = 100;

    public static KeyCode NextStateKey = KeyCode.KeypadEnter;
    public static KeyCode InterruptKey = KeyCode.Escape;


    public enum DisplayState
    {
        Hide = 1,
        Show = 2,
        ShowToHide = 3,
        HideToShow = 4
    }

    public enum ShowStateAlphaVisualizaton
    {
        Static = 1,
        DynamicOnOff = 2,
    }

    public enum ShowStateColorVisualization
    {
        Static = 1,
        DynamicTransfer = 2,
    }

    public enum ShowStateGeometryVisualization
    {
        Static = 1,
        DynmicCenterRadius = 2,
    }



    public enum ShowToHideStateVisualization
    {
        Static = 1,
        Fade = 2,
        Explode = 3,
        Shrink = 4,
    }



    public enum State
    {
        IdleState = 0,
        RunningState = 1,
        EndingState = 2,
        InterruptState = 3
    }





    public enum GameState
    {
        InitState = 0,
        IdleState = 1,
        RunningState = 2,
        EndingState = 3,
        InterruptState = 4
    }


    public enum BlockState
    {
        IdleState = 0,
        RunningState = 1,
        EndingState = 2,
        InterruptState = 3
    }


    public enum ExperimentState
    {
        CalibrationState = 1,
        StartState = 2,

        IntroductionInstructionState = 3,
        
        PracticeInstructionState = 4,

        TestInstructionState = 5,

        NoAOIAugmentationInstructionState = 6,
        NoAOIAugmentationState = 7,

        StaticAOIAugmentationInstructionState = 8,
        StaticAOIAugmentationState = 9,

        InteractiveAOIAugmentationInstructionState = 10,
        InteractiveAOIAugmentationState = 11,

        FeedbackState = 12,

        EndState = 13


    }
    
    public enum ExperimentBlock
    {
        InitBlock = 0,
        StartBlock = 1,
        IntroductionBlock = 2,
        PracticeBlock = 3,
        TestBlock = 4,
        EndBlock = 5,
    }

    public static List<ExperimentState> StartBlock = new List<ExperimentState> {
        ExperimentState.StartState,
        //ExperimentState.IntroductionInstructionState
    };


    public static List<ExperimentState> IntroductionBlock = new List<ExperimentState> {
        //ExperimentState.StartState,
        ExperimentState.IntroductionInstructionState
    };



    public static List<ExperimentState> EndBlock = new List<ExperimentState> {
        ExperimentState.EndState
    };

    public static List<ExperimentState> PracticeStartBlock = new List<ExperimentState>
    {
        ExperimentState.PracticeInstructionState,
    };

    public static List<ExperimentState> TestStartBlock = new List<ExperimentState>
    {
        ExperimentState.TestInstructionState,
    };

    //public static List<ExperimentState> TestBlock = new List<ExperimentState>
    //{
    //    ExperimentState.
    //}

    public static List<ExperimentState> NoAOIAugmentationBlock = new List<ExperimentState> {
        ExperimentState.CalibrationState,
        ExperimentState.NoAOIAugmentationState,
        ExperimentState.FeedbackState
    };


    public static List<ExperimentState> StaticAOIAugmentationBlock = new List<ExperimentState> {
        ExperimentState.CalibrationState,
        ExperimentState.StaticAOIAugmentationState,
        ExperimentState.FeedbackState
    };

    public static List<ExperimentState> InteractiveAOIAugmentationBlock = new List<ExperimentState> {
        ExperimentState.CalibrationState,
        ExperimentState.InteractiveAOIAugmentationState,
        ExperimentState.FeedbackState
    };

    public static List<ExperimentState> NoAOIAugmentationBlockWithInstructionBlock = new List<ExperimentState> {
        ExperimentState.NoAOIAugmentationInstructionState,
        ExperimentState.CalibrationState,
        ExperimentState.NoAOIAugmentationState,
        ExperimentState.FeedbackState
    };

    public static List<ExperimentState> StaticAOIAugmentationBlockWithInstructionBlock = new List<ExperimentState> {
        ExperimentState.StaticAOIAugmentationInstructionState,
        ExperimentState.CalibrationState,
        ExperimentState.StaticAOIAugmentationState,
        ExperimentState.FeedbackState
    };

    public static List<ExperimentState> InteractiveAOIAugmentationBlockWithInstructionBlock = new List<ExperimentState> {
        ExperimentState.InteractiveAOIAugmentationInstructionState,
        ExperimentState.CalibrationState,
        ExperimentState.InteractiveAOIAugmentationState,
        ExperimentState.FeedbackState
    };

    //public static string ProjectDirectoryPath = Directory.GetCurrentDirectory();
    //public static string PracticeBlockImageDirectoryPath = Path.Combine(ProjectDirectoryPath, "Assets", "Prefabs", "ExperimentImages", "Practice"); //"D:\\HaowenWei\\Rena\\illumiRead\\AOIAugmentation\\experiment_report\\practice";
    //public static string TestBlockImageDirectoryPath = Path.Combine(ProjectDirectoryPath, "Assets", "Prefabs", "ExperimentImages", "Test");//"D:\\HaowenWei\\Rena\\illumiRead\\AOIAugmentation\\experiment_report\\test";

    public static string ExperimentImageDir = "D://HaowenWei//PycharmProjects//PhysioLabXR//physiolabxr//scripting//AOIAugmentationScript//data//experiment_images";
    public static string PracticeBlockImageDirectoryPath = Path.Combine(ExperimentImageDir, "practice"); //"D:\\HaowenWei\\Rena\\illumiRead\\AOIAugmentation\\experiment_report\\practice";
    public static string TestBlockImageDirectoryPath = Path.Combine(ExperimentImageDir, "test");//"D:\\HaowenWei\\Rena\\illumiRead\\AOIAugmentation\\experiment_report\\test";


    //public static string ImageFileFormat = "*.png";

    public static List<string> PracticeBlockImages = new List<string>
    {   "9175_OS_2021_widefield_report.png",
        "9172_OD_2021_widefield_report.png",
        "RLS_023_OS_TC.jpg"
    };


    public static List<string> TestBlockImages = new List<string>
    {
        "9061_OS_2021_widefield_report.png",
        "RLS_064_OS_TC.jpg",
        "RLS_078_OS_TC.jpg"
    };

}
