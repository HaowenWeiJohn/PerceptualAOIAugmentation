using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Presets;

public class IntroductionBlockController : BlockController
{
    void Start()
    {
        experimentStates = ExperimentPreset.ConstructIntroductionBlock();
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
        experimentStates = ExperimentPreset.ConstructIntroductionBlock();
    }


}
