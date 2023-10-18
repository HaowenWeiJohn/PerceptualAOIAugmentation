using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerContour : MonoBehaviour
{
    public GameObject originalContour;
    public float period = 1f;

    private LineRenderer innerLineRenderer;
    private LineRenderer originalLineRenderer;
    private ContourController contourController;

    private float offsetDistance = 2f;
    private Gradient gradient;
    private GradientColorKey[] colorKey;
    private GradientAlphaKey[] alphaKey;

    void Start()
    {
        innerLineRenderer = GetComponent<LineRenderer>();
        originalLineRenderer = originalContour.GetComponent<LineRenderer>();
        contourController = originalContour.GetComponent<ContourController>();

        int pointCount = originalLineRenderer.positionCount;

        offsetDistance = 0.5f * (contourController.lineRendererStartWidth + contourController.lineRendererEndWidth) * 2.1f / 0.025f;

        Vector3[] oldPoints = new Vector3[pointCount];
        originalLineRenderer.GetPositions(oldPoints);
        Vector3[] newPoints = new Vector3[pointCount];
        for (int i = 0; i < pointCount; i++)
        {
            if (i == 0) newPoints[i] = oldPoints[i] + new Vector3(1f, -1f, 0) * offsetDistance;
            else if( i > 0 && i < pointCount - 1)
            {
                if (oldPoints[i - 1].x > oldPoints[i + 1].x && oldPoints[i - 1].y > oldPoints[i + 1].y) newPoints[i] = oldPoints[i] + new Vector3(1f, -1f, 0) * offsetDistance;
                if (oldPoints[i - 1].x < oldPoints[i + 1].x && oldPoints[i - 1].y > oldPoints[i + 1].y) newPoints[i] = oldPoints[i] + new Vector3(1f, 1f, 0) * offsetDistance;
                if (oldPoints[i - 1].x < oldPoints[i + 1].x && oldPoints[i - 1].y < oldPoints[i + 1].y) newPoints[i] = oldPoints[i] + new Vector3(-1f, 1f, 0) * offsetDistance;
                if (oldPoints[i - 1].x > oldPoints[i + 1].x && oldPoints[i - 1].y < oldPoints[i + 1].y) newPoints[i] = oldPoints[i] + new Vector3(-1f, -1f, 0) * offsetDistance;
            }
            else newPoints[i] = oldPoints[i] + new Vector3(-1f, -1f, 0) * offsetDistance;
        }

        // Set new points to the smaller contour
        innerLineRenderer.positionCount = pointCount;
        for (int i = 0; i < pointCount; i++)
        {
            innerLineRenderer.SetPosition(i, newPoints[i]);
        }
        innerLineRenderer.startColor = Color.white;
        innerLineRenderer.endColor = Color.white;
        innerLineRenderer.startWidth = contourController.lineRendererStartWidth;
        innerLineRenderer.endWidth = contourController.lineRendererEndWidth;
        

    }
    void Update()
    {
        ChangeAlpha(period);
    }

    void ChangeAlpha(float period)
    {
        float alpha = Mathf.Cos(Time.time * Mathf.PI / period);
        gradient = new Gradient();
        gradient.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f) },new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f)});
        innerLineRenderer.colorGradient = gradient;
    }

    void RotatingAlpha(float period)
    {
        if (Time.time % period == 0) alphaKey[1].time = 0.01f;
        else
        {
            alphaKey[1].time = (Time.time % period) / period;
            gradient.SetKeys(colorKey, alphaKey);
            innerLineRenderer.colorGradient = gradient;
        }
    }
}