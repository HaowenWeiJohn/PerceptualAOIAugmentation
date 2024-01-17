using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class Presets
{
    public static float imageMaxWidth = 1400.0f;
    public static float imageMaxHeight = 750.0f;



    public static string EventMarkerLSLOutletStreamName = "AOIAugmentationEventMarkerLSL";
    public static string EventMarkerLSLOutletStreamType = "EventMarker";
    public static string EventMarkerLSLOutletStreamID = "1";
    public static int EventMarkerChannelNum = 7; // block marker index 0
    public static float EventMarkerNominalSamplingRate = 1;


    public enum EventMarkerChannelInfo
    {
        BlockChannelIndex = 0,
        ExperimentStateChannelIndex = 1,
        ImageIndexChannelIndex = 2,
        AOIAugmentationInteractionStartEndMarker = 3,
        ToggleVisualCueVisibilityMarker = 4,
        UpdateVisualCueMarker = 5, // the 0-5 is row, 7-11 is column
        VisualCueHistorySelectedMarker = 6
    }


    public static string TargetImageInfoLSLOutletStreamName = "AOIAugmentationTargetImageInfoLSL";
    public static string TargetImageInfoLSLOutletStreamType = "TargetImageInfo";
    public static string TargetImageInfoLSLOutletStreamID = "1";
    public static int TargetImageInfoChannelNum = 4; // rgba
    public static float TargetImageInfoNominalSamplingRate = 100;







    public static string GazeDataLSLOutletStreamName = "TobiiProFusionUnityLSL";
    public static string GazeDataLSLOutletStreamType = "GazeData";
    public static string GazeDataLSLOutletStreamID = "2";
    public static int GazeDataChannelNum = 51;
    public static float GazeDataNominalSamplingRate = 250;

    // AOIAugmentationAttentionContourStream inlet stream name
    public static string AOIAugmentationAttentionContourStreamLSLInletStreamName = "AOIAugmentationAttentionContourStream";
    public static string AOIAugmentationAttentionHeatmapStreamLSLInletStreamName = "AOIAugmentationAttentionHeatmapStream";





    //public static Vector2Int AttentionGridShape = new Vector2Int(32, 32);
    //public static Vector2Int OriginalImageShape = new Vector2Int(512, 1024);

    //public static string StaticAOIAugmentationStateLSLInletStreamName = "StaticAOIAugmentationStateLSLInlet";
    //public static string StaticAOIAugmentationStateLSLInletStreamType = "AOIAugmentationInlet";
    //public static string StaticAOIAugmentationStateLSLInletStreamID = "3";
    //public static int StaticAOIAugmentationStateLSLInletChannelNum = AttentionGridShape[0] * AttentionGridShape[1];
    //public static float StaticAOIAugmentationStateLSLInletNominalSamplingRate = 10;






    public static string GameManagerName = "GameManager";

    public static int MaxScore = 100;

    public static KeyCode NextStateKey = KeyCode.F1;
    public static KeyCode InterruptKey = KeyCode.Escape;

    /// <summary>
    /// ///////////////////////////////////////////////// Not in use /////////////////////////////////////////////////////
    /// </summary>
    public static KeyCode AOIAugmentationInteractionStateUpdateCueKey = KeyCode.U;
    public static KeyCode AOIAugmentationEnableDisableContoursPressKey = KeyCode.RightAlt;
    public static KeyCode AOIAugmentationEnableDisableContoursHoldKey = KeyCode.H;
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// 



    public static KeyCode AOIAugmentationToggleVisualCueVisibilityCueKey = KeyCode.Mouse1; // right mouse button
    public static KeyCode AOIAugmentationUpdateVisualCueKey = KeyCode.Mouse0; // left mouse button




    public enum UserInputTypes
    {
        AOIAugmentationInteractionStateUpdateCueKeyPressed = 1
    }




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
        InitState = 0,

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

    public static List<ExperimentState> Conditions = new List<ExperimentState>
    {
        ExperimentState.NoAOIAugmentationState,
        ExperimentState.StaticAOIAugmentationState,
        ExperimentState.InteractiveAOIAugmentationState
    };



    public enum ExperimentBlock
    {
        InitBlock = 0,
        StartBlock = 1,
        IntroductionBlock = 2,
        PracticeBlock = 3,
        TestBlock = 4,
        EndBlock = 5,
    }


    public static List<ExperimentState> InitBlock = new List<ExperimentState> {
        ExperimentState.InitState,
        //ExperimentState.IntroductionInstructionState
    };



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
        //ExperimentState.FeedbackState
    };


    public static List<ExperimentState> StaticAOIAugmentationBlock = new List<ExperimentState> {
        ExperimentState.CalibrationState,
        ExperimentState.StaticAOIAugmentationState,
        //ExperimentState.FeedbackState
    };

    public static List<ExperimentState> InteractiveAOIAugmentationBlock = new List<ExperimentState> {
        ExperimentState.CalibrationState,
        ExperimentState.InteractiveAOIAugmentationState,
        //ExperimentState.FeedbackState
    };

    public static List<ExperimentState> NoAOIAugmentationBlockWithInstructionBlock = new List<ExperimentState> {
        ExperimentState.NoAOIAugmentationInstructionState,
        ExperimentState.CalibrationState,
        ExperimentState.NoAOIAugmentationState,
        //ExperimentState.FeedbackState
    };

    public static List<ExperimentState> StaticAOIAugmentationBlockWithInstructionBlock = new List<ExperimentState> {
        ExperimentState.StaticAOIAugmentationInstructionState,
        ExperimentState.CalibrationState,
        ExperimentState.StaticAOIAugmentationState,
        //ExperimentState.FeedbackState
    };

    public static List<ExperimentState> InteractiveAOIAugmentationBlockWithInstructionBlock = new List<ExperimentState> {
        ExperimentState.InteractiveAOIAugmentationInstructionState,
        ExperimentState.CalibrationState,
        ExperimentState.InteractiveAOIAugmentationState,
        //ExperimentState.FeedbackState
    };

    //public static string ProjectDirectoryPath = Directory.GetCurrentDirectory();
    //public static string PracticeBlockImageDirectoryPath = Path.Combine(ProjectDirectoryPath, "Assets", "Prefabs", "ExperimentImages", "Practice"); //"D:\\HaowenWei\\Rena\\illumiRead\\AOIAugmentation\\experiment_report\\practice";
    //public static string TestBlockImageDirectoryPath = Path.Combine(ProjectDirectoryPath, "Assets", "Prefabs", "ExperimentImages", "Test");//"D:\\HaowenWei\\Rena\\illumiRead\\AOIAugmentation\\experiment_report\\test";

    //public static string ExperimentImageDir = "D://HaowenWei//PycharmProjects//PhysioLabXR//physiolabxr//scripting//AOIAugmentationScript//data//experiment_images";
    public static string ExperimentImageDir = "D:\\HaowenWei\\PycharmProjects\\PhysioLabXR\\physiolabxr\\scripting\\illumiRead\\AOIAugmentationScript\\data\\experiment_images";


    public static string PracticeBlockImageDirectoryPath = Path.Combine(ExperimentImageDir, "practice"); //"D:\\HaowenWei\\Rena\\illumiRead\\AOIAugmentation\\experiment_report\\practice";
    public static string TestBlockImageDirectoryPath = Path.Combine(ExperimentImageDir, "test");//"D:\\HaowenWei\\Rena\\illumiRead\\AOIAugmentation\\experiment_report\\test";

    //public static string ImageFileFormat = "*.png";

    public static List<string> PracticeBlockImages = new List<string>
    {   "9071_OD_2021_widefield_report"
    };


    public static List<string> TestBlockImages = new List<string>
    {
        "RLS_097_OD_TC",
        "RLS_006_OD_TC",
        "RLS_043_OD_TC",
        //"RLS_083_OD_TC",
        //"8918_OS_2021_widefield_report",
        //"RLS_073_OD_TC",
        //"RLS_033_OS_TC",
        //"RLS_096_OS_TC",
        //"8981_OS_2021_widefield_report",
        //"RLS_073_OS_TC",
        //"RLS_086_OS_TC",
        //"RLS_060_OS_TC",
        //"RLS_085_OS_TC",
        //"RLS_079_OD_TC",
        //"RLS_082_OD_TC",
        //"9025_OD_2021_widefield_report",



        "RLS_083_OD_TC",
        "RLS_086_OS_TC",
        "RLS_045_OD_TC",
        //"RLS_006_OD_TC",
        //"RLS_092_OS_TC",
        //"8918_OS_2021_widefield_report",
        //"RLS_079_OD_TC",
        //"RLS_097_OD_TC",
        //"RLS_085_OS_TC",
        //"RLS_082_OD_TC",
        //"RLS_023_OD_TC",
        //"RLS_092_OS_TC",
        //"RLS_036_OS_TC",
        //"RLS_006_OD_TC",
        //"RLS_073_OD_TC",
        //"9025_OD_2021_widefield_report"
    };


    public static List<string> TestBlockImagesG = new List<string>
    {
        "RLS_097_OD_TC",
        "RLS_006_OD_TC",
        "RLS_043_OD_TC",
        //"RLS_083_OD_TC",
        //"8918_OS_2021_widefield_report",
        //"RLS_073_OD_TC",
        //"RLS_033_OS_TC",
        //"RLS_096_OS_TC",
        //"8981_OS_2021_widefield_report",
        //"RLS_073_OS_TC",
        //"RLS_086_OS_TC",
        //"RLS_060_OS_TC",
        //"RLS_085_OS_TC",
        //"RLS_079_OD_TC",
        //"RLS_082_OD_TC",
        //"9025_OD_2021_widefield_report"
    };

    public static List<string> TestBlockImagesS = new List<string>
    {
        "RLS_083_OD_TC",
        "RLS_086_OS_TC",
        "RLS_045_OD_TC",
        //"RLS_006_OD_TC",
        //"RLS_092_OS_TC",
        //"8918_OS_2021_widefield_report",
        //"RLS_079_OD_TC",
        //"RLS_097_OD_TC",
        //"RLS_085_OS_TC",
        //"RLS_082_OD_TC",
        //"RLS_023_OD_TC",
        //"RLS_092_OS_TC",
        //"RLS_036_OS_TC",
        //"RLS_006_OD_TC",
        //"RLS_073_OD_TC",
        //"9025_OD_2021_widefield_report"
    };





    public static string IntroductionInstructionStateTitle = "Welcome";
    public static string IntroductionInstructionStateContent = "Welcome, in this experiment, you will be asked to screen Optical Coherence Tomography (OCT) reports for glaucoma. " +
        "\r\n\r\nWith some of the reports, you will receive assistance with your decision-making process: a “heatmap” overlay is shown on the report, indicating parts of the report that are more informative for glaucoma detection." +
        "\r\n\r\nThe primary goal of this study is to understand how different types of AI-augmented guidance can assist clinicians like yourself in analyzing medical images. Your feedback and experience are invaluable to us." +
        "\r\n\r\nClick the Enter key on the number pad to continue.\r\n";




    public static string PracticeInstructionStateTitle = "Practice";
    public static string PracticeInstructionStateContent = "In the next three practice trials, we will get you familiarized with the three different conditions. \r\n\r\nClick the Enter key on the number pad to continue.\r\n ";








    public static string PracticeNoAOIAugmentationInstructionStateTitle = "[Practice] Condition: No Guidance";
    public static string PracticeNoAOIAugmentationInstructionStateContent = "You will not receive ROI guidance assistance in the next trial.\r\n";

    public static string TestNoAOIAugmentationInstructionStateTitle = "No Guidance";
    public static string TestNoAOIAugmentationInstructionStateContent = "You will NOT receive guidance in the next trial.\r\n";




    public static string PracticeStaticAOIAugmentationInstructionStateTitle = "[Practice] Condition: Static Guidance";
    public static string PracticeStaticAOIAugmentationInstructionStateContent = "An overlay will be shown on the report indicating parts more informative for glaucoma detection. " +
        "Click the right mouse button to toggle hide/show the guidance overlay. Use the mouse scroll wheel to change the brightness of the report." +
        "\r\n\r\nWhen you are finished with reading the report, click the Enter key on the number pad to continue.\r\n";

    public static string TestStaticAOIAugmentationInstructionStateTitle = "Static Guidance";
    public static string TestStaticAOIAugmentationInstructionStateContent = "You will receive guidance in the next trial, BUT you cannot update the guidance.";





    public static string PracticeInteractiveAOIAugmentationInstructionStateTitle = "[Practice] Condition: Dynamic Guidance";
    public static string PracticeInteractiveAOIAugmentationInstructionStateContent = "An overlay will be shown on the report indicating parts more informative for glaucoma detection. " +
        "In addition, you can request guidance to update based on how you are reading the report. Click the left mouse button to update the guidance.\r\n";

    public static string TestInteractiveAOIAugmentationInstructionStateTitle = "Dynamic Guidance";
    public static string TestInteractiveAOIAugmentationInstructionStateContent = "You will receive guidance in the next trial, AND you may update the guidance.";






    public static string TestInstructionStateTitle = "End of practice"; // starting of test block
    public static string TestInstructionStateContent = "That was the end of the practice session. \r\n\r\nClick the Enter key on the number pad to continue the experiment. \r\n";





}
