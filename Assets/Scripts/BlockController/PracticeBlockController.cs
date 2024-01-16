using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PracticeBlockController : BlockController
{
    // Start is called before the first frame update

    [Header("Image Loader")]
    public ImageLoader practiceBlockImageLoader;
    public int experimentImageIndex = 0;
    public List<string> experimentImages = new List<string>();








    void Start()
    {
        //experimentStates = ExperimentPreset.ConstructPracticeBlock();
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
        //experimentStates = ExperimentPreset.ConstructPracticeBlock();
        ConstructPracticeBlock();
    }


    public void ConstructPracticeBlock()
    {

        experimentStates = new List<Presets.ExperimentState>();
        experimentStates.Add(Presets.ExperimentState.PracticeInstructionState);


        // we only have one image in practice block
        List<Presets.ExperimentState> Conditions = new List<Presets.ExperimentState>(Presets.Conditions);

        for (int i = 0; i < Presets.Conditions.Count; i++)
        {
            Presets.ExperimentState condition = Conditions[i];

            if (condition == Presets.ExperimentState.NoAOIAugmentationState)
            {
                experimentStates = experimentStates.Concat(Presets.NoAOIAugmentationBlockWithInstructionBlock).ToList();
                experimentImages.Add(Presets.PracticeBlockImages[0]);
            }
            else if (condition == Presets.ExperimentState.StaticAOIAugmentationState)
            {
                experimentStates = experimentStates.Concat(Presets.StaticAOIAugmentationBlockWithInstructionBlock).ToList();
                experimentImages.Add(Presets.PracticeBlockImages[0]);
            }
            else if (condition == Presets.ExperimentState.InteractiveAOIAugmentationState)
            {
                experimentStates = experimentStates.Concat(Presets.InteractiveAOIAugmentationBlockWithInstructionBlock).ToList();
                experimentImages.Add(Presets.PracticeBlockImages[0]);
            }
        }






    }



    public override void onExperimentStateEntered()
    {
        base.onExperimentStateEntered();

        if (Presets.Conditions.Contains(gameManager.currentState.experimentState))
        {
            string imageName = experimentImages[experimentImageIndex];
            int imageIndex = Presets.PracticeBlockImages.IndexOf(imageName);

            if (gameManager.currentState == gameManager.noAOIAugmentationStateController)
            {
                gameManager.noAOIAugmentationStateController.imageIndex = imageIndex;
                gameManager.noAOIAugmentationStateController.aOIAugmentationStateGUIController.setImage(practiceBlockImageLoader.imageTextureDict[imageName]);
                experimentImageIndex += 1;
            }
            else if (gameManager.currentState == gameManager.staticAOIAugmentationStateController)
            {
                gameManager.staticAOIAugmentationStateController.imageIndex = imageIndex;
                gameManager.staticAOIAugmentationStateController.aOIAugmentationStateGUIController.setImage(practiceBlockImageLoader.imageTextureDict[imageName]);
                experimentImageIndex += 1;
            }
            else if (gameManager.currentState == gameManager.interactiveAOIAugmentationStateController)
            {
                gameManager.interactiveAOIAugmentationStateController.imageIndex = imageIndex;
                gameManager.interactiveAOIAugmentationStateController.aOIAugmentationStateGUIController.setImage(practiceBlockImageLoader.imageTextureDict[imageName]);
                experimentImageIndex += 1;

            }

        }



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
