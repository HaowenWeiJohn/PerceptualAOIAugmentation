using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBlockController : BlockController
{
    // Start is called before the first frame update
    void Start()
    {
        //experimentStates = ExperimentPreset.ConstructExperimentBlock();
        DisableSelf();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }


    public override void initExperimentBlockStates()
    {
        //base.initExperimentBlockStates();
        //experimentStates = ExperimentPreset.();
    }

}
