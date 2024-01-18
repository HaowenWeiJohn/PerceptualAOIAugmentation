using LSL;
using System.Collections;
using System.Collections.Generic;
using Tobii.Research.Unity;
using UnityEngine;

public class TobiiProGazeDataLSLOutletController : LSLOutletInterface
{


    public TobiiGazeOverlayController tobiiGazeOverlayController;

    // Start is called before the first frame update


    private EyeTracker _eyeTracker;
    //public StreamOutlet streamOutlet;

    void Start()
    {
        _eyeTracker = EyeTracker.Instance;
        initLSLStreamOutlet(                                               
                    Presets.GazeDataLSLOutletStreamName,
                    Presets.GazeDataLSLOutletStreamType,
                    Presets.GazeDataChannelNum,
                    Presets.GazeDataNominalSamplingRate,
                    LSL.channel_format_t.cf_float32
                    );
        

        //initLSLTobiiProGazeDataOutlet();
    }

    // Update is called once per frame
    void Update()
    {

        var data = _eyeTracker.NextData;
        while (data != default(IGazeData))
        {
            float startTime = Time.time;
            float[] gazeDataArray = new float[51];
            GazeDataUtils.UnpackGazeData(data, gazeDataArray);
            float timestamp = gazeDataArray[50] / 1000000;
            streamOutlet.push_sample(gazeDataArray, timestamp);
            float endTime = Time.time;
            //Debug.Log(startTime-endTime);

            // set gaze data overlay
            SetOnScreenGazePoint(data);


            data = _eyeTracker.NextData;
            

        }
    }


    void SetOnScreenGazePoint(IGazeData gazeData)
    {
        if (gazeData.Left.GazeOriginValid && gazeData.Left.GazePointValid && gazeData.Right.GazeOriginValid && gazeData.Right.GazePointValid) 
        {
            tobiiGazeOverlayController.tobiiGazePointOnScreenLocation = new Vector2 (
                (gazeData.Left.GazePointOnDisplayArea.x + gazeData.Right.GazePointOnDisplayArea.x) / 2,
                (gazeData.Left.GazePointOnDisplayArea.y + gazeData.Right.GazePointOnDisplayArea.y) / 2
                );

        }

    }

    // unpack data
    //void initLSLTobiiProGazeDataOutlet()
    //{
    //    // TODO: init gaze data outlet LSL
    //    StreamInfo streamInfo = new StreamInfo(
    //                                            Presets.GazeDataLSLOutletStreamName,
    //                                            Presets.GazeDataLSLOutletStreamType,
    //                                            Presets.GazeDataChannelNum,
    //                                            Presets.GazeDataNominalSamplingRate,
    //                                            LSL.channel_format_t.cf_float32
    //                                            );

    //    streamOutlet = new StreamOutlet(streamInfo);

    //}
    


}
