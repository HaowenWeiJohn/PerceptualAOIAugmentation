using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Runtime.InteropServices;
using System.Linq;

public class GeneralUtils
{


    public static Vector3[,] getPatchCenterPositions(float imageWidth, float imageHeight, Vector3 imagePosition,Vector2Int patchGridShape, Vector2 originalImageShape)
    {

        float topLeftConorX = imagePosition.x - imageWidth/2;
        float topLeftConorY = imagePosition.y + imageHeight/2;

        float patchOnScreenWidth = imageWidth / patchGridShape[1];
        float patchOnScreenHeight = imageHeight / patchGridShape[0];
        
        Vector3[,] patchCenters = new Vector3[patchGridShape[0], patchGridShape[1]];



         for (int i = 0; i < (int)patchGridShape[0]; i++) // row
        {
            for (int j = 0; j < (int)patchGridShape[1]; j++)
            {
                patchCenters[i, j] = new Vector3(
                    topLeftConorX + patchOnScreenWidth * j + patchOnScreenWidth / 2, 
                    topLeftConorY - patchOnScreenHeight* i - patchOnScreenHeight/ 2,
                    0);
            }
        }


        return patchCenters;
    }


    public static Texture2D LoadTextureFromFile(string filePath)
    {
        byte[] imageData = File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D(5375, 2670); // You might need to adjust the size
        if (texture.LoadImage(imageData))
            return texture;
        else
            return null;
    }



    public static List<T> ToListOf<T>(byte[] array, Func<byte[], int, T> bitConverter)
    {
        var size = Marshal.SizeOf(typeof(T));
        return Enumerable.Range(0, array.Length / size)
                         .Select(i => bitConverter(array, i * size))
                         .ToList();
    }






}
