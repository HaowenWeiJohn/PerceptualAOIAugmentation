using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOIAugmentationAttentionContourStreamLSLInletController : LSLInletInterface
{

    // Start is called before the first frame update
    void Start()
    {
        streamName = Presets.AOIAugmentationAttentionContourStreamLSLInletStreamName;
        StartContinousResolver();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pullContoursLVTInfo()
    {
        if (streamActivated)
        {
            pullSample();
            clearBuffer();
        }
    }

}
