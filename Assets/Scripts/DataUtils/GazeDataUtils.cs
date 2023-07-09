using System.Collections;
using System.Collections.Generic;
using Tobii.Research;
using Tobii.Research.Unity;
using UnityEngine;

public static class GazeDataUtils
{


    //public static float[] gazeDataArray = new float[51];

    public static void UnpackGazeData(IGazeData gazeData, float[] gazeDataArray)
    {

        // 7
        float CombinedGazeRayScreenDirectionX = gazeData.CombinedGazeRayScreen.direction.x;
        float CombinedGazeRayScreenDirectionY = gazeData.CombinedGazeRayScreen.direction.y;
        float CombinedGazeRayScreenDirectionZ = gazeData.CombinedGazeRayScreen.direction.z;


        float CombinedGazeRayScreenOriginX = gazeData.CombinedGazeRayScreen.origin.x;
        float CombinedGazeRayScreenOriginY = gazeData.CombinedGazeRayScreen.origin.y;
        float CombinedGazeRayScreenOriginZ = gazeData.CombinedGazeRayScreen.origin.z;

        bool CombinedGazeRayScreenOriginValid = gazeData.CombinedGazeRayScreenValid;


                //21
        float LeftGazeOriginInTrackBoxCoordinatesX = gazeData.Left.GazeOriginInTrackBoxCoordinates.x;
        float LeftGazeOriginInTrackBoxCoordinatesY = gazeData.Left.GazeOriginInTrackBoxCoordinates.y;
        float LeftGazeOriginInTrackBoxCoordinatesZ = gazeData.Left.GazeOriginInTrackBoxCoordinates.z;

        float LeftGazeOriginInUserCoordinatesX = gazeData.Left.GazeOriginInUserCoordinates.x;
        float LeftGazeOriginInUserCoordinatesY = gazeData.Left.GazeOriginInUserCoordinates.y;
        float LeftGazeOriginInUserCoordinatesZ = gazeData.Left.GazeOriginInUserCoordinates.z;

        bool LeftGazeOriginValid = gazeData.Left.GazeOriginValid;


        float LeftGazePointInUserCoordinatesX = gazeData.Left.GazePointInUserCoordinates.x;
        float LeftGazePointInUserCoordinatesY = gazeData.Left.GazePointInUserCoordinates.y;
        float LeftGazePointInUserCoordinatesZ = gazeData.Left.GazePointInUserCoordinates.z;


        float LeftGazePointOnDisplayAreaX = gazeData.Left.GazePointOnDisplayArea.x;
        float LeftGazePointOnDisplayAreaY = gazeData.Left.GazePointOnDisplayArea.y;

        bool LeftGazePointValid = gazeData.Left.GazePointValid;

        float LeftGazeRayScreenDirectionX = gazeData.Left.GazeRayScreen.direction.x;
        float LeftGazeRayScreenDirectionY = gazeData.Left.GazeRayScreen.direction.y;
        float LeftGazeRayScreenDirectionZ = gazeData.Left.GazeRayScreen.direction.z;

        float LeftGazeRayScreenOriginX = gazeData.Left.GazeRayScreen.origin.x;
        float LeftGazeRayScreenOriginY = gazeData.Left.GazeRayScreen.origin.y;
        float LeftGazeRayScreenOriginZ = gazeData.Left.GazeRayScreen.origin.z;

        float LeftPupileDiameter = gazeData.Left.PupilDiameter;
        bool LeftPupileDiameterValid = gazeData.Left.PupilDiameterValid;


                // 21
        float RightGazeOriginInTrackBoxCoordinatesX = gazeData.Right.GazeOriginInTrackBoxCoordinates.x;
        float RightGazeOriginInTrackBoxCoordinatesY = gazeData.Right.GazeOriginInTrackBoxCoordinates.y;
        float RightGazeOriginInTrackBoxCoordinatesZ = gazeData.Right.GazeOriginInTrackBoxCoordinates.z;

        float RightGazeOriginInUserCoordinatesX = gazeData.Right.GazeOriginInUserCoordinates.x;
        float RightGazeOriginInUserCoordinatesY = gazeData.Right.GazeOriginInUserCoordinates.y;
        float RightGazeOriginInUserCoordinatesZ = gazeData.Right.GazeOriginInUserCoordinates.z;

        bool RightGazeOriginValid = gazeData.Right.GazeOriginValid;

        float RightGazePointInUserCoordinatesX = gazeData.Right.GazePointInUserCoordinates.x;
        float RightGazePointInUserCoordinatesY = gazeData.Right.GazePointInUserCoordinates.y;
        float RightGazePointInUserCoordinatesZ = gazeData.Right.GazePointInUserCoordinates.z;

        float RightGazePointOnDisplayAreaX = gazeData.Right.GazePointOnDisplayArea.x;
        float RightGazePointOnDisplayAreaY = gazeData.Right.GazePointOnDisplayArea.y;

        bool RightGazePointValid = gazeData.Right.GazePointValid;

        float RightGazeRayScreenDirectionX = gazeData.Right.GazeRayScreen.direction.x;
        float RightGazeRayScreenDirectionY = gazeData.Right.GazeRayScreen.direction.y;
        float RightGazeRayScreenDirectionZ = gazeData.Right.GazeRayScreen.direction.z;

        float RightGazeRayScreenOriginX = gazeData.Right.GazeRayScreen.origin.x;
        float RightGazeRayScreenOriginY = gazeData.Right.GazeRayScreen.origin.y;
        float RightGazeRayScreenOriginZ = gazeData.Right.GazeRayScreen.origin.z;

        float RightPupilDiameter = gazeData.Right.PupilDiameter;
        bool RightPupilDiameterValid = gazeData.Right.PupilDiameterValid;



                // 2
        float OriginalGazeDeviceTimeStamp = gazeData.OriginalGaze.DeviceTimeStamp;
        float OriginalGazeSystemTimeStamp = gazeData.OriginalGaze.SystemTimeStamp;


        gazeDataArray[0] = CombinedGazeRayScreenDirectionX;
        gazeDataArray[1] = CombinedGazeRayScreenDirectionY;
        gazeDataArray[2] = CombinedGazeRayScreenDirectionZ;

        // CombinedGazeRayScreenOrigin
        gazeDataArray[3] = CombinedGazeRayScreenOriginX;
        gazeDataArray[4] = CombinedGazeRayScreenOriginY;
        gazeDataArray[5] = CombinedGazeRayScreenOriginZ;

        // CombinedGazeRayScreenOriginValid
        gazeDataArray[6] = CombinedGazeRayScreenOriginValid ? 1 : 0;

        // LeftGazeOriginInTrackBoxCoordinates
        gazeDataArray[7] = LeftGazeOriginInTrackBoxCoordinatesX;
        gazeDataArray[8] = LeftGazeOriginInTrackBoxCoordinatesY;
        gazeDataArray[9] = LeftGazeOriginInTrackBoxCoordinatesZ;

        // LeftGazeOriginInUserCoordinates
        gazeDataArray[10] = LeftGazeOriginInUserCoordinatesX;
        gazeDataArray[11] = LeftGazeOriginInUserCoordinatesY;
        gazeDataArray[12] = LeftGazeOriginInUserCoordinatesZ;

        // LeftGazeOriginValid
        gazeDataArray[13] = LeftGazeOriginValid ? 1 : 0;

        // LeftGazePointInUserCoordinates
        gazeDataArray[14] = LeftGazePointInUserCoordinatesX;
        gazeDataArray[15] = LeftGazePointInUserCoordinatesY;
        gazeDataArray[16] = LeftGazePointInUserCoordinatesZ;

        // LeftGazePointOnDisplayArea
        gazeDataArray[17] = LeftGazePointOnDisplayAreaX;
        gazeDataArray[18] = LeftGazePointOnDisplayAreaY;

        // LeftGazePointValid
        gazeDataArray[19] = LeftGazePointValid ? 1 : 0;

        // LeftGazeRayScreenDirection
        gazeDataArray[20] = LeftGazeRayScreenDirectionX;
        gazeDataArray[21] = LeftGazeRayScreenDirectionY;
        gazeDataArray[22] = LeftGazeRayScreenDirectionZ;

        // LeftGazeRayScreenOrigin
        gazeDataArray[23] = LeftGazeRayScreenOriginX;
        gazeDataArray[24] = LeftGazeRayScreenOriginY;
        gazeDataArray[25] = LeftGazeRayScreenOriginZ;

        // LeftPupilDiameter
        gazeDataArray[26] = LeftPupileDiameter;

        // LeftPupilDiameterValid
        gazeDataArray[27] = LeftPupileDiameterValid ? 1 : 0;

        // RightGazeOriginInTrackBoxCoordinates
        gazeDataArray[28] = RightGazeOriginInTrackBoxCoordinatesX;
        gazeDataArray[29] = RightGazeOriginInTrackBoxCoordinatesY;
        gazeDataArray[30] = RightGazeOriginInTrackBoxCoordinatesZ;

        // RightGazeOriginInUserCoordinates
        gazeDataArray[31] = RightGazeOriginInUserCoordinatesX;
        gazeDataArray[32] = RightGazeOriginInUserCoordinatesY;
        gazeDataArray[33] = RightGazeOriginInUserCoordinatesZ;

        // RightGazeOriginValid
        gazeDataArray[34] = RightGazeOriginValid ? 1 : 0;

        // RightGazePointInUserCoordinates
        gazeDataArray[35] = RightGazePointInUserCoordinatesX;
        gazeDataArray[36] = RightGazePointInUserCoordinatesY;
        gazeDataArray[37] = RightGazePointInUserCoordinatesZ;

        // RightGazePointOnDisplayArea
        gazeDataArray[38] = RightGazePointOnDisplayAreaX;
        gazeDataArray[39] = RightGazePointOnDisplayAreaY;

        // RightGazePointValid
        gazeDataArray[40] = RightGazePointValid ? 1 : 0;

        // RightGazeRayScreenDirection
        gazeDataArray[41] = RightGazeRayScreenDirectionX;
        gazeDataArray[42] = RightGazeRayScreenDirectionY;
        gazeDataArray[43] = RightGazeRayScreenDirectionZ;

        // RightGazeRayScreenOrigin
        gazeDataArray[44] = RightGazeRayScreenOriginX;
        gazeDataArray[45] = RightGazeRayScreenOriginY;
        gazeDataArray[46] = RightGazeRayScreenOriginZ;

        // RightPupilDiameter
        gazeDataArray[47] = RightPupilDiameter;

        // RightPupilDiameterValid
        gazeDataArray[48] = RightPupilDiameterValid ? 1 : 0;

        // OriginalGazeDeviceTimeStamp
        gazeDataArray[49] = OriginalGazeDeviceTimeStamp;

        // OriginalGazeSystemTimeStamp
        gazeDataArray[50] = OriginalGazeSystemTimeStamp;


        // convert gaze data to 0 if nan
        //for (int i = 0; i < gazeDataArray.Length; i++)
        //{
        //    if (float.IsNaN(gazeDataArray[i]))
        //    {
        //        gazeDataArray[i] = 0;
        //    }
        //}

    }
}


//// CombinedGazeRayScreenDirection
//gazeDataArray[0] = gazeData.CombinedGazeRayScreen.direction.x;
//gazeDataArray[1] = gazeData.CombinedGazeRayScreen.direction.y;
//gazeDataArray[2] = gazeData.CombinedGazeRayScreen.direction.z;

//// CombinedGazeRayScreenOrigin
//gazeDataArray[3] = gazeData.CombinedGazeRayScreen.origin.x;
//gazeDataArray[4] = gazeData.CombinedGazeRayScreen.origin.y;
//gazeDataArray[5] = gazeData.CombinedGazeRayScreen.origin.z;

//// CombinedGazeRayScreenOriginValid
//gazeDataArray[6] = gazeData.CombinedGazeRayScreenValid ? 1 : 0;

//// LeftGazeOriginInTrackBoxCoordinates
//gazeDataArray[7] = gazeData.Left.GazeOriginInTrackBoxCoordinates.x;
//gazeDataArray[8] = gazeData.Left.GazeOriginInTrackBoxCoordinates.y;
//gazeDataArray[9] = gazeData.Left.GazeOriginInTrackBoxCoordinates.z;

//// LeftGazeOriginInUserCoordinates
//gazeDataArray[10] = gazeData.Left.GazeOriginInUserCoordinates.x;
//gazeDataArray[11] = gazeData.Left.GazeOriginInUserCoordinates.y;
//gazeDataArray[12] = gazeData.Left.GazeOriginInUserCoordinates.z;

//// LeftGazeOriginValid
//gazeDataArray[13] = gazeData.Left.GazeOriginValid ? 1 : 0;

//// LeftGazePointInUserCoordinates
//gazeDataArray[14] = gazeData.Left.GazePointInUserCoordinates.x;
//gazeDataArray[15] = gazeData.Left.GazePointInUserCoordinates.y;
//gazeDataArray[16] = gazeData.Left.GazePointInUserCoordinates.z;

//// LeftGazePointOnDisplayArea
//gazeDataArray[17] = gazeData.Left.GazePointOnDisplayArea.x;
//gazeDataArray[18] = gazeData.Left.GazePointOnDisplayArea.y;

//// LeftGazePointValid
//gazeDataArray[19] = gazeData.Left.GazePointValid ? 1 : 0;

//// LeftGazeRayScreenDirection
//gazeDataArray[20] = gazeData.Left.GazeRayScreen.direction.x;
//gazeDataArray[21] = gazeData.Left.GazeRayScreen.direction.y;
//gazeDataArray[22] = gazeData.Left.GazeRayScreen.direction.z;

//// LeftGazeRayScreenOrigin
//gazeDataArray[23] = gazeData.Left.GazeRayScreen.origin.x;
//gazeDataArray[24] = gazeData.Left.GazeRayScreen.origin.y;
//gazeDataArray[25] = gazeData.Left.GazeRayScreen.origin.z;

//// LeftPupilDiameter
//gazeDataArray[26] = gazeData.Left.PupilDiameter;

//// LeftPupilDiameterValid
//gazeDataArray[27] = gazeData.Left.PupilDiameterValid ? 1 : 0;

//// RightGazeOriginInTrackBoxCoordinates
//gazeDataArray[28] = gazeData.Right.GazeOriginInTrackBoxCoordinates.x;
//gazeDataArray[29] = gazeData.Right.GazeOriginInTrackBoxCoordinates.y;
//gazeDataArray[30] = gazeData.Right.GazeOriginInTrackBoxCoordinates.z;

//// RightGazeOriginInUserCoordinates
//gazeDataArray[31] = gazeData.Right.GazeOriginInUserCoordinates.x;
//gazeDataArray[32] = gazeData.Right.GazeOriginInUserCoordinates.y;
//gazeDataArray[33] = gazeData.Right.GazeOriginInUserCoordinates.z;

//// RightGazeOriginValid
//gazeDataArray[34] = gazeData.Right.GazeOriginValid ? 1 : 0;

//// RightGazePointInUserCoordinates
//gazeDataArray[35] = gazeData.Right.GazePointInUserCoordinates.x;
//gazeDataArray[36] = gazeData.Right.GazePointInUserCoordinates.y;
//gazeDataArray[37] = gazeData.Right.GazePointInUserCoordinates.z;

//// RightGazePointOnDisplayArea
//gazeDataArray[38] = gazeData.Right.GazePointOnDisplayArea.x;
//gazeDataArray[39] = gazeData.Right.GazePointOnDisplayArea.y;

//// RightGazePointValid
//gazeDataArray[40] = gazeData.Right.GazePointValid ? 1 : 0;

//// RightGazeRayScreenDirection
//gazeDataArray[41] = gazeData.Right.GazeRayScreen.direction.x;
//gazeDataArray[42] = gazeData.Right.GazeRayScreen.direction.y;
//gazeDataArray[43] = gazeData.Right.GazeRayScreen.direction.z;

//// RightGazeRayScreenOrigin
//gazeDataArray[44] = gazeData.Right.GazeRayScreen.origin.x;
//gazeDataArray[45] = gazeData.Right.GazeRayScreen.origin.y;
//gazeDataArray[46] = gazeData.Right.GazeRayScreen.origin.z;

//// RightPupilDiameter
//gazeDataArray[47] = gazeData.Right.PupilDiameter;

//// RightPupilDiameterValid
//gazeDataArray[48] = gazeData.Right.PupilDiameterValid ? 1 : 0;

//// OriginalGazeDeviceTimeStamp
//gazeDataArray[49] = gazeData.OriginalGaze.DeviceTimeStamp;

//// OriginalGazeSystemTimeStamp
//gazeDataArray[50] = gazeData.OriginalGaze.SystemTimeStamp;