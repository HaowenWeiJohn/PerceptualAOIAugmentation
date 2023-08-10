using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;  // Import the LINQ library
using static Presets;

public static class ExperimentPreset
{
    // welcome --> practice --> 3 interaction blocks --> experiment start block



    public static List<List<Presets.ExperimentState>> GameStartBlock = new List<List<Presets.ExperimentState>> {
        Presets.StartBlock
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
        ExperimentStates = ExperimentStates.Concat(Presets.StartBlock).ToList();
        
        ExperimentStates = ExperimentStates.Concat(Presets.PracticeStartBlock).ToList();
        ExperimentStates = ExperimentStates.Concat(Presets.NoAOIAugmentationBlockWithInstructionBlock).ToList();
        ExperimentStates = ExperimentStates.Concat(Presets.StaticAOIAugmentationBlockWithInstructionBlock).ToList();
        ExperimentStates = ExperimentStates.Concat(Presets.InteractiveAOIAugmentationBlockWithInstructionBlock).ToList();


        // start game block





        ExperimentStates = ExperimentStates.Concat(Presets.EndBlock).ToList();

        return ExperimentStates;

    }

    public static List<Presets.ExperimentState> ConstructStartBlock()
    {
        List<Presets.ExperimentState> ExperimentStates = new List<Presets.ExperimentState> { };
        ExperimentStates = ExperimentStates.Concat(Presets.StartBlock).ToList();
        return ExperimentStates;

    }



    public static List<Presets.ExperimentState> ConstructIntroductionBlock()
    {
        List<Presets.ExperimentState> ExperimentStates = new List<Presets.ExperimentState> { };
        ExperimentStates = ExperimentStates.Concat(Presets.IntroductionBlock).ToList();
        return ExperimentStates;

    }




    public static List<Presets.ExperimentState> ConstructPracticeBlock()
    {
        List<Presets.ExperimentState> ExperimentStates = new List<Presets.ExperimentState> { };

        ExperimentStates = ExperimentStates.Concat(Presets.PracticeStartBlock).ToList();
        ExperimentStates = ExperimentStates.Concat(Presets.NoAOIAugmentationBlockWithInstructionBlock).ToList();
        ExperimentStates = ExperimentStates.Concat(Presets.StaticAOIAugmentationBlockWithInstructionBlock).ToList();
        ExperimentStates = ExperimentStates.Concat(Presets.InteractiveAOIAugmentationBlockWithInstructionBlock).ToList();

        return ExperimentStates;
    }

    public static List<Presets.ExperimentState> ConstructTestBlock()
    {
        List<Presets.ExperimentState> ExperimentStates = new List<Presets.ExperimentState> { };

        ExperimentStates = ExperimentStates.Concat(Presets.TestStartBlock).ToList();

        ExperimentStates = ExperimentStates.Concat(Presets.NoAOIAugmentationBlock).ToList();
        ExperimentStates = ExperimentStates.Concat(Presets.StaticAOIAugmentationBlock).ToList();
        ExperimentStates = ExperimentStates.Concat(Presets.InteractiveAOIAugmentationBlock).ToList();
        ExperimentStates = ExperimentStates.Concat(Presets.NoAOIAugmentationBlock).ToList();
        ExperimentStates = ExperimentStates.Concat(Presets.StaticAOIAugmentationBlock).ToList();
        ExperimentStates = ExperimentStates.Concat(Presets.InteractiveAOIAugmentationBlock).ToList();

        return ExperimentStates;
    }



    public static List<Presets.ExperimentState> ConstructEndBlock()
    {
        List<Presets.ExperimentState> ExperimentStates = new List<Presets.ExperimentState> { };
        ExperimentStates = ExperimentStates.Concat(Presets.EndBlock).ToList();

        return ExperimentStates;
    }




    public static List<Presets.ExperimentBlock> ConstructExperimentBlocks()
    {
        List<Presets.ExperimentBlock> ExperimentBlock = new List<Presets.ExperimentBlock> {

            Presets.ExperimentBlock.StartBlock,
            Presets.ExperimentBlock.IntroductionBlock,
            Presets.ExperimentBlock.PracticeBlock,
            Presets.ExperimentBlock.TestBlock,
            Presets.ExperimentBlock.EndBlock
        
        };

        return ExperimentBlock;
        }


    //public static void createPracticeBlock() //List<Presets.ExperimentState>
    //{

    //}



}
