using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContourController : MonoBehaviour
{
    // Start is called before the first frame update

    public float contourIndex = 0;
    public int[] hierarchy = new int[] { };
    public Vector2[] contourVertices = new Vector2[] { };

    public LineRenderer lineRenderer; // for contour visualization
    public Color lineRendererStartColor = Color.blue;
    public Color lineRendererEndColor = Color.blue;

    public float lineRendererStartWidth = 0.01f;
    public float lineRendererEndWidth = 0.01f;


    void Start()
    {


    }


    public void drawContour()
    {
        lineRenderer.useWorldSpace = false;
        lineRenderer.positionCount = contourVertices.Length; // to close the loop


        for (int i = 0; i < contourVertices.Length; i++)
        {
            Vector3 contourVertex = new Vector3(contourVertices[i].x, contourVertices[i].y, 0);
            lineRenderer.SetPosition(i, contourVertex);
        }

        lineRenderer.loop = true;

        // set initial color and width
        lineRenderer.startColor = lineRendererStartColor;
        lineRenderer.endColor = lineRendererEndColor;
        lineRenderer.startWidth = lineRendererStartWidth;
        lineRenderer.endWidth = lineRendererEndWidth;

    }




    // Update is called once per frame
    void Update()
    {
        int i = 0;
    }
}
