using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Presets
{
    public static string GazeDataLSLOutletStreamName = "TobiiProFusion";
    public static string GazeDataLSLOutletStreamType = "GazeData";
    public static string GazeDataLSLOutletStreamID = "0";
    public static int GazeDataChannelNum = 51;
    public static float GazeDataNominalSamplingRate = 250;

    public static string GameManagerName = "GameManager";

    public static int MaxScore = 100;

    public static KeyCode NextStateKey = KeyCode.Space;
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
    public enum ExperimentState
    {
        StartState = 0,

        IntroductionInstructionState = 1,
        PracticeInstructionState = 2,


        CalibrationState = 3,

        NoAOIAugmentationInstructionState = 4,
        NoAOIAugmentationState = 5,

        StaticAOIAugmentationInstructionState = 6,
        StaticAOIAugmentationState = 7,

        InteractiveAOIAugmentationInstructionState = 8,
        InteractiveAOIAugmentationState = 9,

        FeedbackState = 10,

        EndState = 11

    }

    public static List<ExperimentState> StartBlock = new List<ExperimentState> {
        ExperimentState.StartState,
        ExperimentState.IntroductionInstructionState
    };

    public static List<ExperimentState> EndBlock = new List<ExperimentState> {
        ExperimentState.EndState
    };


    public static List<ExperimentState> PracticeStartBlock = new List<ExperimentState>
    {
        ExperimentState.PracticeInstructionState,
    };

    public static List<ExperimentState> NoAOIAugmentationBlock = new List<ExperimentState> {
        ExperimentState.CalibrationState,
        ExperimentState.StaticAOIAugmentationState,
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
        ExperimentState.StaticAOIAugmentationState,
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


}
