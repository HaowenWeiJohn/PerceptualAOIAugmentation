using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetImageInfoLSLOutletController : LSLOutletInterface
{
    // Start is called before the first frame update
    void Start()
    {
        initLSLStreamOutlet(

            Presets.TargetImageInfoLSLOutletStreamName,
            Presets.TargetImageInfoLSLOutletStreamType,
            Presets.TargetImageInfoChannelNum,
            Presets.TargetImageInfoNominalSamplingRate,
            LSL.channel_format_t.cf_float32

            );


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sendImageInfo(Image targetImage)
    {

        Color currentColor = targetImage.color;
        float[] eventMarkerArray = createEventMarkerArrayFloat();
        eventMarkerArray[0] = currentColor.r;
        eventMarkerArray[1] = currentColor.g;
        eventMarkerArray[2] = currentColor.b;
        eventMarkerArray[3] = currentColor.a;

        streamOutlet.push_sample(eventMarkerArray);

    }


}
