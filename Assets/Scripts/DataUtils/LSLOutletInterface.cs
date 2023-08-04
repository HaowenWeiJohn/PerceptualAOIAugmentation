using LSL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSLOutletInterface : MonoBehaviour
{
    // Start is called before the first frame update
    public StreamOutlet streamOutlet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void initLSLStreamOutlet(string streamName, string streamType, int channelNum, float nominalSamplingRate, LSL.channel_format_t channelFormat)
    {
        StreamInfo streamInfo = new StreamInfo(

            streamName,
            streamType,
            channelNum,
            nominalSamplingRate,
            channelFormat

            );

        streamOutlet = new StreamOutlet(streamInfo);
    }

}
