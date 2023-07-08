using LSL;
using System.Collections;
using System.Collections.Generic;
using Tobii.Research.Unity;
using UnityEngine;

public class LSLTobiiProGazeDataOutlet : MonoBehaviour
{
    // Start is called before the first frame update


    private EyeTracker _eyeTracker;
    private StreamOutlet gazeDataOutlet;

    void Start()
    {
        _eyeTracker = EyeTracker.Instance;
        initLSLTobiiProGazeDataOutlet();
    }

    // Update is called once per frame
    void Update()
    {

        var data = _eyeTracker.NextData;
        while (data != default(IGazeData))
        {
            float[] gazeDataArray = new float[51];
            GazeDataUtils.UnpackGazeData(data, gazeDataArray);
            float timestamp = gazeDataArray[50] / 1000000;
            gazeDataOutlet.push_sample(gazeDataArray, timestamp);

            data = _eyeTracker.NextData;
            
        }
    }

    // unpack data
    void initLSLTobiiProGazeDataOutlet()
    {
        // TODO: init gaze data outlet LSL
        StreamInfo streamInfo = new StreamInfo(
                                                Presets.GazeDataLSLOutletStreamName,
                                                Presets.GazeDataLSLOutletStreamType,
                                                Presets.GazeDataChannelNum,
                                                Presets.GazeDataNominalSamplingRate,
                                                LSL.channel_format_t.cf_float32
                                                );

        gazeDataOutlet = new StreamOutlet(streamInfo);

    }
    


}
