using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    public static List<List<Presets.ExperimentState>> ExperimentBlock = new List<List<Presets.ExperimentState>>
    {

    };


}
