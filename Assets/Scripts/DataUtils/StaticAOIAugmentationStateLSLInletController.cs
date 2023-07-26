using LSL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticAOIAugmentationStateLSLInletController : LSLInletInterface
{




    // Start is called before the first frame update
    void Start()
    {
        streamName = Presets.StaticAOIAugmentationStateLSLInletStreamName;
        StartContinousResolver();
    }

    // Update is called once per frame
    void Update()
    {
        //if (activated)
        //{
        //    int a = pullChunk();
        //    Debug.Log(a);
        //}
    }








}
