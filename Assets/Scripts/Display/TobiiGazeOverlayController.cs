using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class TobiiGazeOverlayController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject gazeOverlay;
    public DisplayCoordinateController displayCoordinateController;


    public Vector2 tobiiGazePointOnScreenLocation;
    public Vector2 gazePointOnScreenPixelLocation;
    public Vector2 gazePointOnCanvasLocation;

    //public int screenWidth;
    //public int screenHeight;
    

    void Start()
    {
        DisableGazeOverlay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        gazePointOnScreenPixelLocation = GazeDataUtils.tobiiGazePointOnScreenLocationToScreenPixelCoordinte(
            tobiiGazePointOnScreenLocation[0],
            tobiiGazePointOnScreenLocation[1],
            displayCoordinateController.screenWidth,
            displayCoordinateController.screenHeight);


        gazePointOnCanvasLocation = GazeDataUtils.tobiiGazePointOnScreenLocationToScreenCanvasCoordinate(
            tobiiGazePointOnScreenLocation[0],
            tobiiGazePointOnScreenLocation[1],
            displayCoordinateController.screenWidth,
            displayCoordinateController.screenHeight);


        //Vector3 gazePointOverlayPosition = Camera.main.ScreenToWorldPoint(gazePointOnScreenPixelLocation);

        //gazePointOverlayPosition.z = displayCoordinateController.canvas.planeDistance;

        Vector3 gazePointOverlayPosition = new Vector3(gazePointOnCanvasLocation[0], gazePointOnCanvasLocation[1], 0);
        gazeOverlay.transform.localPosition = gazePointOverlayPosition;

    }

    public void EnableGazeOverlay()
    {
        gazeOverlay.SetActive(true);
    }

    public void DisableGazeOverlay()
    {
        gazeOverlay.SetActive(false);
    }




}
