using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;  // Import the LINQ library

public static class ExperimentPreset
{
    // welcome --> practice --> 3 interaction blocks --> experiment start block

    public static List<List<Presets.ExperimentState>> GameStartBlock = new List<List<Presets.ExperimentState>> {
        Presets.WelcomeBlock
    };

    public static List<List<Presets.ExperimentState>> PracticeBlock = new List<List<Presets.ExperimentState>>
    {
        Presets.PracticeStartBlock,
        Presets.NoAOIAugmentationBlockWithInstructionBlock,
        Presets.StaticAOIAugmentationBlockWithInstructionBlock,
        Presets.InteractiveAOIAugmentationBlockWithInstructionBlock,
    };

    //public static List<List<Presets.ExperimentState>> GameStartBlock = new List<List<Presets.ExperimentState>> {
    //    Presets.WelcomeBlock
    //};


    public static List<Presets.ExperimentState> ConstructExperimentStates()
    {
        List<Presets.ExperimentState> ExperimentStates = new List<Presets.ExperimentState> { };
        ExperimentStates = ExperimentStates.Concat(Presets.WelcomeBlock).ToList();
        ExperimentStates = ExperimentStates.Concat(Presets.PracticeStartBlock).ToList();
        ExperimentStates = ExperimentStates.Concat(Presets.NoAOIAugmentationBlockWithInstructionBlock).ToList();
        ExperimentStates = ExperimentStates.Concat(Presets.StaticAOIAugmentationBlockWithInstructionBlock).ToList();
        ExperimentStates = ExperimentStates.Concat(Presets.InteractiveAOIAugmentationBlockWithInstructionBlock).ToList();

        return ExperimentStates;

    }


    //public static void createPracticeBlock() //List<Presets.ExperimentState>
    //{

    //}



}
