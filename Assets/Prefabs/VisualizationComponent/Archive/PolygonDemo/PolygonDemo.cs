using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonDemo : MonoBehaviour
{
    public int vertexCount = 40; // Number of vertices in the circle
    public float radius = 1f; // Radius of the circle
    public LineRenderer circleRenderer;

    private void Start()
    {
        DrawCircle(3, 1);
    }

    private void Update()
    {
        
    }


    void DrawCircle(int steps, float radius) {
        circleRenderer.positionCount = steps;

        for(int currentStep = 0; currentStep<steps; currentStep++)
        {
            float circumferenceProgress = (float)currentStep / steps;

            float currentRadian = circumferenceProgress * 2 * Mathf.PI;
            
            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);

            float x = xScaled * radius;
            float y = yScaled * radius;

            Vector3 currentPosition = new Vector3(x, y, 0);
            circleRenderer.SetPosition(currentStep, currentPosition);
        }
    
    
    }



}