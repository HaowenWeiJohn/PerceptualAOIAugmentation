using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralUtils
{

    //public static Vector2 GetImageCenter(Vector2 canvasShape, Vector2 imageShape,Vector2 imageLocation) // the center of canvas is 0,0. the center of image is also 0,0
    //{


    //    return new Vector2();
    //}
    
    //public static void screenPixelLocationToCanvasLocation()
    //{

    //}


    public static Vector2[,] getPatchPositions(Vector2Int patchGridShape, Vector2 imageShape, Vector2 imageCenterLocation) // the 0,0 of the image is at the center
    {

        

        Vector2 patchOnScreenDimension = new Vector2(imageShape[0] / patchGridShape[0], imageShape[1] / patchGridShape[1]);
        Vector2 topLeftConorPosition = new Vector2(imageCenterLocation[0] / 2, imageCenterLocation[1] / 2);

        Vector2[,] patchCenters = new Vector2[(int)patchGridShape[0], (int)patchGridShape[1]];


        for (int i = 0; i < (int)patchGridShape[0]; i++) // row
        {
            for (int j = 0; j < (int)patchGridShape[1]; i++)
            {
                patchCenters[i,j] = new Vector2(topLeftConorPosition[0] +patchOnScreenDimension[0]*i, topLeftConorPosition[1] + patchOnScreenDimension[1] * j);
            }
        }


        return patchCenters;
    }





}
