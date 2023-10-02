using LSL;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class StaticAOIAugmentationStateLSLInletController : LSLInletInterface
{




    // Start is called before the first frame update
    void Start()
    {
        //streamName = Presets.StaticAOIAugmentationStateLSLInletStreamName;
        StartContinousResolver();
    }

    // Update is called once per frame
    void Update()
    {
        //pullVisualizationSample();
    }


    //void pullVisualizationChunk()
    //{
    //    if (activated)
    //    {
    //        pullChunk();
    //        Debug.Log(chunkSampleNumber); // the number of samples in this update 
    //    }
    //}

    //void pullVisualizationSample()
    //{
    //    if (activated)
    //    {
    //        pullSample();
    //        clearBuffer();
    //    }
    //}

    

    //void updatePolygonVisualization()
    //{
    //    if ( chunkSampleNumber!= 0) {
    //        // update the visualization using the first colume
            
    //    }
    //}




}
