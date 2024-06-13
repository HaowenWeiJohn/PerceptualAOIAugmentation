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


    public static string HeatmapOverlayImageInfoLSLOutletStreamName = "AOIAugmentationHeatmapOverlayImageInfoLSL";
    public static string HeatmapOverlayImageInfoLSLOutletStreamType = "HeatmapOverlayImageInfo";
    public static string HeatmapOverlayImageInfoLSLOutletStreamID = "1";
    public static int HeatmapOverlayImageInfoChannelNum = 4; // rgba
    public static float HeatmapOverlayImageInfoNominalSamplingRate = 100;







    public static string GazeDataLSLOutletStreamName = "TobiiProFusionUnityLSL";
    public static string GazeDataLSLOutletStreamType = "GazeData";
    public static string GazeDataLSLOutletStreamID = "2";
    public static int GazeDataChannelNum = 51;
    public static float GazeDataNominalSamplingRate = 250;

    // AOIAugmentationAttentionContourStream inlet stream name
    public static string AOIAugmentationAttentionContourStreamLSLInletStreamName = "AOIAugmentationAttentionContourStream";
    public static string AOIAugmentationAttentionHeatmapStreamLSLInletStreamName = "AOIAugmentationAttentionHeatmapStream";

    public static string GameManagerName = "GameManager";

    public static int MaxScore = 100;

    //public static KeyCode NextStateKey = KeyCode.F1;
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
    public static KeyCode ForceEnableSubmitResponseKey = KeyCode.F1;




    public enum UserInputTypes
    {
        AOIAugmentationInteractionStateUpdateCueKeyPressed = 1
    }

    public enum VisualCueMode
    {
        ChangeTargetImageTransparencyToggleVisualCue = 1,
        ChangeVisualCueTransparency = 2,
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
        InitState = 0, // only for the Unity

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

        ResnetAOIAugmentationInstructionState = 12,
        ResnetAOIAugmentationState = 13,

        NextPatchPredictionAOIAugmentationInstructionState = 14,
        NextPatchPredictionAOIAugmentationState = 15,

        FeedbackState = 16,

        EndState = 17 

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

    public static List<ExperimentState> ResnetAOIAugmentationBlock = new List<ExperimentState>
    {
        ExperimentState.CalibrationState,
        ExperimentState.ResnetAOIAugmentationState,
        //ExperimentState.FeedbackState
    };

    public static List<ExperimentState> NextPatchPredictionAOIAugmentationBlock = new List<ExperimentState>
    {
        ExperimentState.CalibrationState,
        ExperimentState.NextPatchPredictionAOIAugmentationState,
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

    public static List<ExperimentState> ResnetAOIAugmentationBlockWithInstructionBlock = new List<ExperimentState>
    {
        ExperimentState.ResnetAOIAugmentationInstructionState,
        ExperimentState.CalibrationState,
        ExperimentState.ResnetAOIAugmentationState,
        //ExperimentState.FeedbackState
    };

    public static List<ExperimentState> NextPatchPredictionAOIAugmentationBlockWithInstructionBlock = new List<ExperimentState>
    {
        ExperimentState.NextPatchPredictionAOIAugmentationInstructionState,
        ExperimentState.CalibrationState,
        ExperimentState.NextPatchPredictionAOIAugmentationState,
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
    /////////////////////////////////////////////////////////////
     "9025_OD_2021_widefield_report",
     "RLS_079_OD_TC",
     "RLS_036_OS_TC",
     "RLS_045_OD_TC",
     "RLS_060_OS_TC",
     "RLS_097_OD_TC",
     "9140_OD_2021_widefield_report",
     "RLS_092_OS_TC",
     "RLS_083_OD_TC",
     "RLS_086_OS_TC",


     /////////////////////////////////////////////////////////////
     "RLS_078_OS_TC",
     "RLS_064_OS_TC",
     "RLS_051_OS_TC",
     "RLS_081_OD_TC",
     "8962_OS_2021_widefield_report",
     "9005_OS_2021_widefield_report",
     "RLS_038_OD_TC",
     "RLS_053_OD_TC",
     "RLS_148_OD_TC",
     "RLS_148_OS_TC"
    };


    public enum UserStudy
    {
        UserStudy1 = 1,
        UserStudy2 = 2,
        UserStudyTest = 3
    }


    public static List<string> TestBlockImagesG = new List<string>
    {

    };

    public static List<string> TestBlockImagesS = new List<string>
    {

    };

    public static List<string> UserStudy1TestBlockImagesG = new List<string>
    {
     "9025_OD_2021_widefield_report",
     "RLS_079_OD_TC",
     "RLS_036_OS_TC",
     "RLS_045_OD_TC",
     "RLS_060_OS_TC",
     "RLS_097_OD_TC",
     "9140_OD_2021_widefield_report",
     "RLS_092_OS_TC",
     "RLS_083_OD_TC",
     //"RLS_086_OS_TC" // comment out when three conditions
    };

    public static List<string> UserStudy1TestBlockImagesS = new List<string>
    {
     "RLS_078_OS_TC",
     "RLS_064_OS_TC",
     "RLS_051_OS_TC",
     "RLS_081_OD_TC",
     "8962_OS_2021_widefield_report",
     "9005_OS_2021_widefield_report",
     "RLS_038_OD_TC",
     "RLS_053_OD_TC",
     "RLS_148_OD_TC",
     //"RLS_148_OS_TC" // comment out when three conditions
    };




    public static List<string> UserStudy2TestBlockImagesG = new List<string>
    {
     "9025_OD_2021_widefield_report",
     "RLS_079_OD_TC",
     "RLS_036_OS_TC",
     "RLS_045_OD_TC",
     "RLS_060_OS_TC",
     "RLS_097_OD_TC",
     "9140_OD_2021_widefield_report",
     "RLS_092_OS_TC",
     "RLS_083_OD_TC",
     "RLS_086_OS_TC" // comment out when three conditions
    };

    public static List<string> UserStudy2TestBlockImagesS = new List<string>
    {
     "RLS_078_OS_TC",
     "RLS_064_OS_TC",
     "RLS_051_OS_TC",
     "RLS_081_OD_TC",
     "8962_OS_2021_widefield_report",
     "9005_OS_2021_widefield_report",
     "RLS_038_OD_TC",
     "RLS_053_OD_TC",
     "RLS_148_OD_TC",
     "RLS_148_OS_TC" // comment out when three conditions
    };




    public static List<ExperimentState> Conditions = new List<ExperimentState>
    {
        //ExperimentState.NoAOIAugmentationState,
        //ExperimentState.StaticAOIAugmentationState,
        //ExperimentState.InteractiveAOIAugmentationState,
        //ExperimentState.ResnetAOIAugmentationState // cnn
    };




    public static List<ExperimentState> UserStudy1Conditions = new List<ExperimentState>
    {
        ExperimentState.NoAOIAugmentationState,
        ExperimentState.StaticAOIAugmentationState,
        //ExperimentState.InteractiveAOIAugmentationState,
        ExperimentState.ResnetAOIAugmentationState // cnn
    };

    public static List<ExperimentState> UserStudy2Conditions = new List<ExperimentState>
    {
        ExperimentState.StaticAOIAugmentationState,
        ExperimentState.InteractiveAOIAugmentationState,
    };

    public static List<ExperimentState> UserStudyTestConditions = new List<ExperimentState>
    {
        ExperimentState.NextPatchPredictionAOIAugmentationState,
        ExperimentState.StaticAOIAugmentationState,
    };




    public static string IntroductionInstructionStateTitle = "Welcome";
    public static string IntroductionInstructionStateContent = "You will be asked to screen Optical Coherence Tomography (OCT) reports for glaucoma. " +
        "\r\n\r\nIn some reports, you will receive guidance to help with your decision-making process: a “heatmap?overlay will be shown on the report, indicating parts of the report that are more important for detecting glaucoma." +
        "\r\n\r\nThe primary goal of this study is to understand how different types of AI-augmented guidance can assist clinicians like yourself in analyzing medical images. We really appreciate your participation and your feedback is invaluable to us." +
        "\r\n\r\nClick the <b>Next</b> button to contune.\r\n";



    public static string PracticeInstructionStateTitle = "Practice";
    public static string PracticeInstructionStateContent = "In the practice trials, we will get you familiarized with the interface. \r\n\r\nClick the Next to continue.\r\n ";
    


    public static string PracticeNoAOIAugmentationInstructionStateTitle = "[Practice] Condition: No Guidance";
    public static string PracticeNoAOIAugmentationInstructionStateContent = "You will not receive guidance in the next trial.\r\n";
    


    public static string TestNoAOIAugmentationInstructionStateTitle = "No Guidance";
    public static string TestNoAOIAugmentationInstructionStateContent = "You will NOT receive guidance in the coming trials.\r\n";
    


    public static string PracticeStaticAOIAugmentationInstructionStateTitle = "[Practice] Condition: Static Model A Guidance";
    public static string PracticeStaticAOIAugmentationInstructionStateContent = "An overlay generated from <b>Model A</b> will be shown on the report, indicating parts more informative for glaucoma detection." +
        "\r\n\r\nClick the <b>right mouse button</b> on the report to toggle hide/show the guidance overlay. Use the <b>mouse scroll wheel</b> to change the brightness of the report." +
        "\r\n\r\nWhen you are finished with screening the report and writing the response, click the Submit button to continue.\r\n";
    


    public static string TestStaticAOIAugmentationInstructionStateTitle = "Static Model A Guidance";
    public static string TestStaticAOIAugmentationInstructionStateContent = "You will receive guidance generated from <b>Model A</b> in the coming trials.";
    


    public static string PracticeInteractiveAOIAugmentationInstructionStateTitle = "[Practice] Condition: Perceptual Guidance";
    public static string PracticeInteractiveAOIAugmentationInstructionStateContent = "An overlay will be shown on the report, indicating parts more informative for glaucoma detection. " +
        "\r\n\r\nIn addition, you can request guidance to update based on how you are reading the report. The updated guidance will show you <b>where to look next, based on where you just looked at.</b>" +
        "\r\n\r\nClick the <b>left mouse button</b> on the report to update the guidance. Click the <b>right mouse button</b> on the report to toggle hide/show the guidance overlay. " +
        "\r\n\r\nYou can access <b>the history</b> of the guidance and go back to them any time.\r\n";
    


    public static string TestInteractiveAOIAugmentationInstructionStateTitle = "Perceptual Guidance";
    public static string TestInteractiveAOIAugmentationInstructionStateContent = "In the coming trials, you will receive guidance, and you <b>may update the guidance based on where you just looked at</b>";
    


    public static string PracticeResnetAOIAugmentationInstructionStateTitle = "[Practice] Condition: Static Model B Guidance";
    public static string PracticeResnetAOIAugmentationInstructionStateContent = "An overlay generated from <b>Model B</b> will be shown on the report, indicating parts more informative for glaucoma detection. " +
        "\r\n\r\nClick the <b>right mouse button</b> on the report to toggle hide/show the guidance overlay. Use the <b>mouse scroll wheel</b> to change the brightness of the report." +
        "\r\n\r\nWhen you are finished with reading the report, click the Submit button to continue.\r\n";
    
    

    public static string TestResnetAOIAugmentationInstructionStateTitle = "Static Model B Guidance";
    public static string TestResnetAOIAugmentationInstructionStateContent = "You will receive guidance generated from <b>Model B</b> in the coming trials.";

    public static string PracticeNextPatchPredictionAOIAugmentationInstructionStateTitle = "[Practice] Condition: Static NextPatchPrediction Model Guidance";
    public static string PracticeNextPatchPredictionAOIAugmentationInstructionStateContent = "An overlay generated from <b>NextPatchPrediction Model</b> will be shown on the report, indicating parts more informative for glaucoma detection. " +
        "\r\n\r\nClick the <b>right mouse button</b> on the report to toggle hide/show the guidance overlay. Use the <b>mouse scroll wheel</b> to change the brightness of the report." +
        "\r\n\r\nWhen you are finished with reading the report, click the Submit button to continue.\r\n";

    public static string TestNextPatchPredictionAOIAugmentationInstructionStateTitle = "Static Next-Patch-Prediction Guidance";
    public static string TestNextPatchPredictionAOIAugmentationInstructionStateContent = "You will receive guidance generated from <b>Next-Patch-Prediction Model</b> in the coming trials.";

    public static string TestInstructionStateTitle = "End of practice"; // starting of test block
    public static string TestInstructionStateContent = "That was the end of the practice session. \r\n\r\nClick the <b>Next</b> button to continue the experiment. \r\n";




}
