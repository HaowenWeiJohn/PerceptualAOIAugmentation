using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;


public class TestBlockController : BlockController
{
    // Start is called before the first frame update

    [Header("Image Loader")]
    public ImageLoader testBlockImageLoader;
    public int experimentImageIndex = 0;
    public List<string> experimentImages = new List<string>();



    void Start()
    {
        Debug.Log("Test Block Controller Start");
        //experimentStates = ExperimentPreset.ConstructTestBlock();
        initExperimentBlockStates();
        DisableSelf();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }


    public override void initExperimentBlockStates()
    {
        base.initExperimentBlockStates();
        ConstructTestBlock();
        //experimentStates = ExperimentPreset.ConstructTestBlock();
    }


    public void ConstructTestBlock()
    {

        experimentStates = new List<Presets.ExperimentState>();
        experimentStates.Add(Presets.ExperimentState.TestInstructionState);

        List<Presets.ExperimentState> Conditions = new List<Presets.ExperimentState>(Presets.Conditions);
        List<string> TestBlockImages = new List<string>(Presets.TestBlockImages);
        List<string> TestBlockImagesG = new List<string>(Presets.TestBlockImagesG);
        List<string> TestBlockImagesS = new List<string>(Presets.TestBlockImagesS);


        // shuffle condition
        GeneralUtils.ShuffleList(Conditions);
        // shuffle the G and S images Sequence
        GeneralUtils.ShuffleList(TestBlockImagesG);
        GeneralUtils.ShuffleList(TestBlockImagesS);


        List<List<string>> ConditionImages = new List<List<string>>();


        // images per condition = len(TestBlockImages) / len(Conditions)
        int imagesPerCondition = TestBlockImages.Count / Conditions.Count;


        for (int i = 0; i < Conditions.Count; i++)
        {
            Presets.ExperimentState condition = Conditions[i];
            List<Presets.ExperimentState> thisConditionStates = new List<Presets.ExperimentState>();
            List<string> thisConditionImages = new List<string>();



            if (condition == Presets.ExperimentState.NoAOIAugmentationState)
            {
                thisConditionStates.Add(Presets.ExperimentState.NoAOIAugmentationInstructionState);
                for (int j = 0; j < imagesPerCondition / 2; j++)
                {
                    thisConditionStates = thisConditionStates.Concat(Presets.NoAOIAugmentationBlock).ToList();
                    thisConditionStates = thisConditionStates.Concat(Presets.NoAOIAugmentationBlock).ToList();

                    thisConditionImages.Add(TestBlockImagesG[0]);
                    TestBlockImagesG.RemoveAt(0);
                    thisConditionImages.Add(TestBlockImagesS[0]);
                    TestBlockImagesS.RemoveAt(0);
                }

            }
            else if (condition == Presets.ExperimentState.StaticAOIAugmentationState)
            {
                thisConditionStates.Add(Presets.ExperimentState.StaticAOIAugmentationInstructionState);
                for (int j = 0; j < imagesPerCondition / 2; j++)
                {
                    thisConditionStates = thisConditionStates.Concat(Presets.StaticAOIAugmentationBlock).ToList();
                    thisConditionStates = thisConditionStates.Concat(Presets.StaticAOIAugmentationBlock).ToList();

                    thisConditionImages.Add(TestBlockImagesG[0]);
                    TestBlockImagesG.RemoveAt(0);
                    thisConditionImages.Add(TestBlockImagesS[0]);
                    TestBlockImagesS.RemoveAt(0);
                }

            }
            else if (condition == Presets.ExperimentState.InteractiveAOIAugmentationState)
            {
                thisConditionStates.Add(Presets.ExperimentState.InteractiveAOIAugmentationInstructionState);
                for (int j = 0; j < imagesPerCondition / 2; j++)
                {
                    thisConditionStates = thisConditionStates.Concat(Presets.InteractiveAOIAugmentationBlock).ToList();
                    thisConditionStates = thisConditionStates.Concat(Presets.InteractiveAOIAugmentationBlock).ToList();

                    thisConditionImages.Add(TestBlockImagesG[0]);
                    TestBlockImagesG.RemoveAt(0);
                    thisConditionImages.Add(TestBlockImagesS[0]);
                    TestBlockImagesS.RemoveAt(0);
                }

            }

            GeneralUtils.ShuffleList(thisConditionImages);

            experimentStates = experimentStates.Concat(thisConditionStates).ToList();
            experimentImages = experimentImages.Concat(thisConditionImages).ToList();

        }

        int a = 0;

        Debug.Log("John");






    }



    public override void onExperimentStateEntered()
    {
        base.onExperimentStateEntered();

        if (Presets.Conditions.Contains(gameManager.currentState.experimentState))
        {
            string imageName = experimentImages[experimentImageIndex];
            int imageIndex = Presets.TestBlockImages.IndexOf(imageName);

            if (gameManager.currentState == gameManager.noAOIAugmentationStateController)
            {
                gameManager.noAOIAugmentationStateController.imageIndex = imageIndex;
                gameManager.noAOIAugmentationStateController.aOIAugmentationStateGUIController.setImage(testBlockImageLoader.imageTextureDict[imageName]);

            }
            else if (gameManager.currentState == gameManager.staticAOIAugmentationStateController)
            {
                gameManager.staticAOIAugmentationStateController.imageIndex = imageIndex;
                gameManager.staticAOIAugmentationStateController.aOIAugmentationStateGUIController.setImage(testBlockImageLoader.imageTextureDict[imageName]);

            }
            else if (gameManager.currentState == gameManager.interactiveAOIAugmentationStateController)
            {
                gameManager.interactiveAOIAugmentationStateController.imageIndex = imageIndex;
                gameManager.interactiveAOIAugmentationStateController.aOIAugmentationStateGUIController.setImage(testBlockImageLoader.imageTextureDict[imageName]);

            }
            experimentImageIndex += 1;
        }


        //if (gameManager.currentState == gameManager.noAOIAugmentationStateController)
        //{
        //    gameManager.noAOIAugmentationStateController.imageIndex = experimentImageIndex;
        //    gameManager.noAOIAugmentationStateController.aOIAugmentationStateGUIController.setImage(testBlockImageLoader.imageTextureDict[Presets.TestBlockImages[experimentImageIndex]]);
        //    experimentImageIndex += 1;
        //}
        //else if (gameManager.currentState == gameManager.staticAOIAugmentationStateController)
        //{
        //    gameManager.staticAOIAugmentationStateController.imageIndex = experimentImageIndex;
        //    gameManager.staticAOIAugmentationStateController.aOIAugmentationStateGUIController.setImage(testBlockImageLoader.imageTextureDict[Presets.TestBlockImages[experimentImageIndex]]);
        //    experimentImageIndex += 1;
        //}
        //else if (gameManager.currentState == gameManager.interactiveAOIAugmentationStateController)
        //{
        //    gameManager.interactiveAOIAugmentationStateController.imageIndex = experimentImageIndex;
        //    gameManager.interactiveAOIAugmentationStateController.aOIAugmentationStateGUIController.setImage(testBlockImageLoader.imageTextureDict[Presets.TestBlockImages[experimentImageIndex]]);
        //    experimentImageIndex += 1;
        //}
    }


    public void enterBlock()
    {
        experimentImageIndex = 0;
        base.enterBlock();
    }


    public void exitBlock()
    {
        experimentImageIndex = 0;
        base.exitBlock();

    }




}
