using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBlockController : BlockController
{

    // Start is called before the first frame update
    void Start()
    {
        experimentStates = ExperimentPreset.ConstructEndBlock();
        DisableSelf();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
