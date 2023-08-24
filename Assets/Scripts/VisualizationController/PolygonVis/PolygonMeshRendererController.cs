using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonMeshRendererController : MonoBehaviour
{
    #region setup
    //mesh properties
    Mesh mesh;

    //public Material materialPrefab;
    public MeshRenderer meshRenderer;

    public Vector3[] polygonPoints;
    public int[] polygonTriangles;

    //polygon properties
    public bool isFilled;

    [Header("Initial Prameters")]
    public int initialPolygonSides;
    public float initialPolygonRadius;
    public float initialPolygonCenterRadius;
    public Material initialPolygonMaterial;

    [Header ("Dynamic Prameters")]
    public int polygonSides;
    public float polygonRadius;
    public float polygonCenterRadius;
    public Material polygonMaterial;


    void Start()
    {
        mesh = new Mesh();
        this.GetComponent<MeshFilter>().mesh = mesh;
        // set initial geometry
        setInitialGeometry();
        setInitialMaterial();
        // set initial material

    }


    void Update()
    {
        draw();
        //if (isFilled)
        //{
        //    DrawFilled(polygonSides, polygonRadius);
        //}
        //else
        //{
        //    DrawHollow(polygonSides, polygonRadius, polygonCenterRadius);
        //}
        Vector3[] vertices = mesh.vertices;
        Vector2[] uv = new Vector2[vertices.Length];
        //Color[] colors = new Color[mesh.vertices.Length];
        for (int i = 0; i < uv.Length; i++)
        {
            
            uv[i] = new Vector2(0.8f* (vertices[i].x / polygonRadius) * 0.5f + 0.5f, 0.8f * (vertices[i].y / polygonRadius) * 0.5f + 0.5f);
            //Debug.Log("i: " + i + " (" + vertices[i].x + ", " + vertices[i].y + ")");
        }
        mesh.uv = uv;
    }

    public void setInitialGeometryMaterial()
    {
        setInitialGeometry();
        setInitialMaterial();
    }


    void setInitialGeometry()
    {
        polygonSides = initialPolygonSides;
        polygonRadius = initialPolygonRadius;
        polygonCenterRadius = initialPolygonCenterRadius;

        draw();
    }

    void setInitialMaterial()
    {
        //polygonMaterial = Instantiate(materialPrefab);
        //meshRenderer.material = polygonMaterial;
    }


    void draw()
    {
        if (isFilled)
        {
            DrawFilled(polygonSides, polygonRadius);
        }
        else
        {
            DrawHollow(polygonSides, polygonRadius, polygonCenterRadius);
        }
    }



    #endregion

    void DrawFilled(int sides, float radius)
    {
        polygonPoints = GetCircumferencePoints(sides, radius).ToArray();
        polygonTriangles = DrawFilledTriangles(polygonPoints);
        mesh.Clear();
        mesh.vertices = polygonPoints;
        mesh.triangles = polygonTriangles;
    }

    void DrawHollow(int sides, float outerRadius, float innerRadius)
    {
        List<Vector3> pointsList = new List<Vector3>();
        List<Vector3> outerPoints = GetCircumferencePoints(sides, outerRadius);
        pointsList.AddRange(outerPoints);
        List<Vector3> innerPoints = GetCircumferencePoints(sides, innerRadius);
        pointsList.AddRange(innerPoints);

        polygonPoints = pointsList.ToArray();

        polygonTriangles = DrawHollowTriangles(polygonPoints);
        mesh.Clear();
        mesh.vertices = polygonPoints;
        mesh.triangles = polygonTriangles;
    }

    int[] DrawHollowTriangles(Vector3[] points)
    {
        int sides = points.Length / 2;
        int triangleAmount = sides * 2;

        List<int> newTriangles = new List<int>();
        for (int i = 0; i < sides; i++)
        {
            int outerIndex = i;
            int innerIndex = i + sides;

            //first triangle starting at outer edge i
            newTriangles.Add(outerIndex);
            newTriangles.Add(innerIndex);
            newTriangles.Add((i + 1) % sides);

            //second triangle starting at outer edge i
            newTriangles.Add(outerIndex);
            newTriangles.Add(sides + ((sides + i - 1) % sides));
            newTriangles.Add(outerIndex + sides);
        }
        return newTriangles.ToArray();
    }

    List<Vector3> GetCircumferencePoints(int sides, float radius)
    {
        List<Vector3> points = new List<Vector3>();
        float circumferenceProgressPerStep = (float)1 / sides;
        float TAU = 2 * Mathf.PI;
        float radianProgressPerStep = circumferenceProgressPerStep * TAU;

        for (int i = 0; i < sides; i++)
        {
            float currentRadian = radianProgressPerStep * i;
            points.Add(new Vector3(Mathf.Cos(currentRadian) * radius, Mathf.Sin(currentRadian) * radius, 0));
        }
        return points;
    }

    int[] DrawFilledTriangles(Vector3[] points)
    {
        int triangleAmount = points.Length - 2;
        List<int> newTriangles = new List<int>();
        for (int i = 0; i < triangleAmount; i++)
        {
            newTriangles.Add(0);
            newTriangles.Add(i + 2);
            newTriangles.Add(i + 1);
        }
        return newTriangles.ToArray();
    }
}

