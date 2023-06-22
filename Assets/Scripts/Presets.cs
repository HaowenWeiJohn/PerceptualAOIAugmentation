using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Presets
{
    //public static int ExperimentMode = 1;
    //public static int PracticeMode = 2;

    //// game state
    //public static int WelcomeState = 1;
    //public static int PracticeInstructionState = 2;
    //public static int ExperimentInstructionState = 3;
    //public static int EndStateGUI = 4;

    //public static int ExperimentStateCalibrationState = 1;
    //public static int ExperimentNoAOIAugmentationState = 2;
    //public static int ExperimentStaticAOIAugmentationState = 3;
    //public static int ExperimentPerceptiveAOIAugmentationState = 4;
    //public static int ExperimentStateSurveyState = 5;

    ////public static int PracticeState = 3;


    ////public static int ExperimentState = 5;





    ////public static int ExperimentStateInteractionState = 8;

    //public static List<int> ExperimentNoAOIAugmentationBlock = new List<int> {
    //Presets.ExperimentStateCalibrationState,
    //Presets.ExperimentNoAOIAugmentationState,
    //Presets.ExperimentStateSurveyState
    //};

    //public static List<int> ExperimentStaticAOIAugmentationBlock = new List<int> {
    //Presets.ExperimentStateCalibrationState,
    //Presets.ExperimentStaticAOIAugmentationState,
    //Presets.ExperimentStateSurveyState
    //};


    //public static List<int> ExperimentPerceptiveAOIAugmentationStateBlock = new List<int> {
    //Presets.ExperimentStateCalibrationState,
    //Presets.ExperimentPerceptiveAOIAugmentationState,
    //Presets.ExperimentStateSurveyState
    //};

    //public static int ExperimentNoAOIAugmentationState = 2;
    //public static int ExperimentStaticAOIAugmentationState = 3;
    //public static int ExperimentPerceptiveAOIAugmentationState = 4;


    //public enum ProcessState
    //{
    //    WelcomeState = 1,
    //    InstructionState = 2,
    //    ExperimentState = 3,
    //    PracticeState = 4,
    //    EndState = 5
    //}

    public enum ExperimentState
    {
        WelcomeState = 1,
        PracticeInstructionState = 2,


        CalibrationState = 3,

        NoAOIAugmentationInstructionState = 4,
        NoAOIAugmentationState = 5,

        StaticAOIAugmentationInstructionState = 6,
        StaticAOIAugmentationState = 7,

        PerceptiveAOIAugmentationInstructionState = 8,
        PerceptiveAOIAugmentationState = 9,

        SurveyState = 10,

        EndState = 11

    }

    public static List<ExperimentState> NoAOIAugmentationBlock = new List<ExperimentState> {
        ExperimentState.CalibrationState, 
        ExperimentState.StaticAOIAugmentationState,
        ExperimentState.SurveyState
    };


    public static List<ExperimentState> StaticAOIAugmentationBlock = new List<ExperimentState> {
        ExperimentState.CalibrationState,
        ExperimentState.StaticAOIAugmentationState,
        ExperimentState.SurveyState
    };

    public static List<ExperimentState> PerceptiveAOIAugmentationBlock = new List<ExperimentState> {
        ExperimentState.CalibrationState,
        ExperimentState.PerceptiveAOIAugmentationState,
        ExperimentState.SurveyState
    };


}
