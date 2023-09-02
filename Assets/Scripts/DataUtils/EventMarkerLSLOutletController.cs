using LSL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMarkerLSLOutletController : LSLOutletInterface
{

    // event marker: [event state marker]



    // Start is called before the first frame update
    void Start()
    {
        initLSLStreamOutlet(

            Presets.EventMarkerLSLOutletStreamName,
            Presets.EventMarkerLSLOutletStreamType,
            Presets.EventMarkerChannelNum,
            Presets.EventMarkerNominalSamplingRate,
            LSL.channel_format_t.cf_float32

            );

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    //void initLSLEventMarkerOutlet()
    //{
    //    StreamInfo streamInfo = new StreamInfo(
    //                            Presets.EventMarkerLSLOutletStreamName,
    //                            Presets.EventMarkerLSLOutletStreamType,
    //                            Presets.EventMarkerChannelNum,
    //                            Presets.EventMarkerNominalSamplingRate,
    //                            LSL.channel_format_t.cf_float32
    //                            );

    //    streamOutlet = new StreamOutlet(streamInfo);

    //}

    public void sendBlockOnEnterMarker(Presets.ExperimentBlock currentExperimentBlock)
    {
        float[] currentStateMarker = new float[] { (float)currentExperimentBlock,0,0, 0};
        streamOutlet.push_sample(currentStateMarker);
    }

    public void sendBlockOnExitMarker(Presets.ExperimentBlock currentExperimentBlock)
    {
        float[] currentStateMarker = new float[] { -(float)currentExperimentBlock,0,0, 0};
        streamOutlet.push_sample(currentStateMarker);
    }

    



    public void sendStateOnEnterMarker(Presets.ExperimentState currentExperimentState, int reportIndex=0)
    {
        float[] currentStateMarker = new float[] {0, (float)currentExperimentState, 0, 0};
        streamOutlet.push_sample(currentStateMarker);
    }


    public void sendStateOnExitMarker(Presets.ExperimentState currentExperimentState)
    {
        float[] currentStateMarker = new float[] {0, -(float)currentExperimentState,0, 0};
        streamOutlet.push_sample(currentStateMarker);
    }


    //public void sendInteractionStateOnEnterMarker(Presets.ExperimentState currentExperimentState, int reportIndex=-1)
    //{
    //    float[] currentStateMarker = new float[] { 0, (float)currentExperimentState, 0 };
    //    streamOutlet.push_sample(currentStateMarker);
    //}


    //public void sendInteractionStateOnExitMarker(Presets.ExperimentState currentExperimentState, int reportIndex=-1)
    //{
    //    float[] currentStateMarker = new float[] { 0, -(float)currentExperimentState, 0 };
    //    streamOutlet.push_sample(currentStateMarker);
    //}




}
