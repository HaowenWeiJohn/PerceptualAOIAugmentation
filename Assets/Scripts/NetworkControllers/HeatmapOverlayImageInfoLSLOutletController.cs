using LSL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatmapOverlayImageInfoLSLOutletController : LSLOutletInterface
{

    //public static string HeatmapOverlayImageInfoLSLOutletStreamName = "AOIAugmentationHeatmapOverlayImageInfoLSL";
    //public static string HeatmapOverlayImageInfoLSLOutletStreamType = "HeatmapOverlayImageInfo";
    //public static string HeatmapOverlayImageInfoLSLOutletStreamID = "1";
    //public static int HeatmapOverlayImageInfoChannelNum = 4; // rgba
    //public static float HeatmapOverlayImageInfoNominalSamplingRate = 100;

    // Start is called before the first frame update
    void Start()
    {
        initLSLStreamOutlet(
            Presets.HeatmapOverlayImageInfoLSLOutletStreamName,
            Presets.HeatmapOverlayImageInfoLSLOutletStreamType,
            Presets.HeatmapOverlayImageInfoChannelNum,
            Presets.HeatmapOverlayImageInfoNominalSamplingRate,
            LSL.channel_format_t.cf_float32
            );

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void sendImageInfo(RawImage targetImage)
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
