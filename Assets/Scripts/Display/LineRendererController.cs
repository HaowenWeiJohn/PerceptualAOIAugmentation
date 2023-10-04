using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public List<Vector2> points = new List<Vector2>();

    void Start()
    {
        if (lineRenderer == null || points.Count == 0)
        {
            Debug.LogError("Line Renderer or points are not set.");
            return;
        }

        // Set the number of positions in the Line Renderer
        lineRenderer.positionCount = points.Count;

        // Set the positions of the Line Renderer to match your points
        for (int i = 0; i < points.Count; i++)
        {
            lineRenderer.SetPosition(i, points[i]);
        }
    }
}
