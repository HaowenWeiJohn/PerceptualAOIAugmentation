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
        //float[] currentStateMarker = new float[] { (float)currentExperimentBlock,0,0, 0};
        //streamOutlet.push_sample(currentStateMarker);
        float[] eventMarkerArray = createEventMarkerArrayFloat();
        eventMarkerArray[(int)Presets.EventMarkerChannelInfo.BlockChannelIndex] = (float)currentExperimentBlock;
        streamOutlet.push_sample(eventMarkerArray);

    }

    public void sendBlockOnExitMarker(Presets.ExperimentBlock currentExperimentBlock)
    {

        float[] eventMarkerArray = createEventMarkerArrayFloat();
        eventMarkerArray[(int)Presets.EventMarkerChannelInfo.BlockChannelIndex] = (float)currentExperimentBlock * -1.0f;
        streamOutlet.push_sample(eventMarkerArray);
    }

    



    public void sendStateOnEnterMarker(Presets.ExperimentState currentExperimentState, int imageIndex=0)
    {

        float[] eventMarkerArray = createEventMarkerArrayFloat();
        eventMarkerArray[(int)Presets.EventMarkerChannelInfo.ExperimentStateChannelIndex] = (float)currentExperimentState;
        eventMarkerArray[(int)Presets.EventMarkerChannelInfo.ImageIndexChannelIndex] = (float)imageIndex;
        streamOutlet.push_sample(eventMarkerArray);

    }


    public void sendStateOnExitMarker(Presets.ExperimentState currentExperimentState)
    {

        float[] eventMarkerArray = createEventMarkerArrayFloat();
        eventMarkerArray[(int)Presets.EventMarkerChannelInfo.ExperimentStateChannelIndex] = (float)currentExperimentState * -1.0f;
        streamOutlet.push_sample(eventMarkerArray);

    }



}
