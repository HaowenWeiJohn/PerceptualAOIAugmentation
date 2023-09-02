using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PracticeBlockController : BlockController
{
    // Start is called before the first frame update

    [Header("Image Loader")]
    public ImageLoader practiceBlockImageLoader;
    public int imageIndex = 0;

    







    void Start()
    {
        experimentStates = ExperimentPreset.ConstructPracticeBlock();
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
        experimentStates = ExperimentPreset.ConstructPracticeBlock();
    }


    public override void onExperimentStateEntered()
    {
        base.onExperimentStateEntered();

        if (gameManager.currentState == gameManager.noAOIAugmentationStateController)
        {
            gameManager.noAOIAugmentationStateController.imageIndex = imageIndex;
            gameManager.noAOIAugmentationStateController.aOIAugmentationStateGUIController.setImage(practiceBlockImageLoader.imageTextures[imageIndex]);
            imageIndex += 1;   
        }
        else if (gameManager.currentState == gameManager.staticAOIAugmentationStateController)
        {
            gameManager.staticAOIAugmentationStateController.imageIndex = imageIndex;
            gameManager.staticAOIAugmentationStateController.aOIAugmentationStateGUIController.setImage(practiceBlockImageLoader.imageTextures[imageIndex]);
            imageIndex += 1;
        }
        else if (gameManager.currentState == gameManager.interactiveAOIAugmentationStateController)
        {
            gameManager.interactiveAOIAugmentationStateController.imageIndex = imageIndex;
            gameManager.interactiveAOIAugmentationStateController.aOIAugmentationStateGUIController.setImage(practiceBlockImageLoader.imageTextures[imageIndex]);
            imageIndex += 1;
        }
    }


    public void enterBlock()
    {
        imageIndex = 0;
        base.enterBlock();
    }


    public void exitBlock()
    {
        imageIndex = 0;
        base.exitBlock();

    }


}
