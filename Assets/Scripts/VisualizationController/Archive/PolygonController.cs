using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonController : MonoBehaviour
{

    //public Material polygonMaterial;
    //public PolygonMeshRendererController polygonMeshRendererController;



    public PolygonMeshRendererController polygonMeshRendererController;


    public int polygonSides = 0;
    public float polygonRadius = 0;
    public float polygonCenterRadius = 0;


    public Material polygonMaterial;





    //public float centerRadius
    // Start is called before the first frame update
    void Start()
    {

        setPolygonSides(polygonSides);
        setPolygonRadius(polygonRadius);
        setPolygonCenterRadius(polygonCenterRadius);
        //polygonMaterial = polygonMeshRendererController.meshRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {

        setPolygonSides(polygonSides);
        setPolygonRadius(polygonRadius);
        setPolygonCenterRadius(polygonCenterRadius);
    }

    public void setPolygonSides(int polygonSides)
    {
        polygonMeshRendererController.polygonSides = polygonSides;
    }

    public void setPolygonRadius(float polygonRadius)
    {
        polygonMeshRendererController.polygonRadius = polygonRadius;
    }

    public void setPolygonCenterRadius(float polygonCenterRadius)
    {
        polygonMeshRendererController.polygonCenterRadius = polygonCenterRadius;
    }



}
