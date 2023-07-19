using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCoordinateController : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas canvas;

    public float screenWidth;
    public float screenHeight;

    public float canvasPlaneDistance;

    void Start()
    {
        canvas.planeDistance = canvasPlaneDistance;
    }

    // Update is called once per frame
    void Update()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }
}
