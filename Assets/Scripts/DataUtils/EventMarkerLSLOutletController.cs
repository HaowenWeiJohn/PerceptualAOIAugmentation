using LSL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMarkerLSLOutletController : MonoBehaviour
{

    // event marker: [event state marker]

    public StreamOutlet eventMarkerLSLOutlet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        StreamInfo streamInfo = new StreamInfo(
                                        Presets.EventMarkerLSLOutletStreamName,
                                        Presets.EventMarkerLSLOutletStreamType,
                                        Presets.EventMarkerChannelNum,
                                        Presets.EventMarkerNominalSamplingRate,
                                        LSL.channel_format_t.cf_float32
                                        );

        eventMarkerLSLOutlet = new StreamOutlet(streamInfo);

    }



}
