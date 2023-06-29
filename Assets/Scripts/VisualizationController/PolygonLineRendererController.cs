using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonLineRendererController : MonoBehaviour
{
    // Start is called before the first frame update
    public LineRenderer polygonRenderer;

    public int polygonSides = 5;
    public float polygonRadius = 3;
    public float polygonLineWidth = 1;

    //public float startWidth = 1;
    //public float endWidth = 1;
    //public bool uniformWidth = true;
    public bool drawOverlapped = true;
    public int extraSteps = 2;

    void Start()
    {
        if (drawOverlapped)
        {
            DrawOverlapped();
        }
        else
        {
            DrawLooped();
        }


        polygonRenderer.startWidth = polygonLineWidth;
        polygonRenderer.endWidth = polygonLineWidth;
    }

    // Update is called once per frame
    void Update()
    {
        if (drawOverlapped)
        {
            DrawOverlapped();
        }
        else {
            DrawLooped();
        }


        polygonRenderer.startWidth = polygonLineWidth;
        polygonRenderer.endWidth = polygonLineWidth;
    }

    void DrawLooped()
    {
        polygonRenderer.positionCount = polygonSides;
        float TAU = 2 * Mathf.PI;
        for (int currentPoint = 0; currentPoint < polygonSides; currentPoint++)
        {
            float currentRadian = ((float)currentPoint / polygonSides) * TAU;
            float x = Mathf.Cos(currentRadian) * polygonRadius;
            float y = Mathf.Sin(currentRadian) * polygonRadius;
            polygonRenderer.SetPosition(currentPoint, new Vector3(x, y, 0));

        }
        polygonRenderer.loop = true;
    }

    void DrawOverlapped()
    {
        DrawLooped();
        polygonRenderer.loop = false;
        polygonRenderer.positionCount += extraSteps;
        int positionCount = polygonRenderer.positionCount;
        for (int i = 0; i < extraSteps; i++) {
            polygonRenderer.SetPosition((positionCount - extraSteps + i), polygonRenderer.GetPosition(i));
        }
    }





}
