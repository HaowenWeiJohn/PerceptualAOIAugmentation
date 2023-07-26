using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticAOIAugmentationOverlayController : MonoBehaviour
{

    public GameObject polygon;
    public DisplayCoordinateController displayCoordinateController;
    public TargetImageController targetImageController;

    public Vector2[,] polygonVector2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void constructPolygonGrid()
    {
        polygonVector2 = GeneralUtils.getPatchPositions(Presets.AttentionGridShape, targetImageController.targetImageShape, )
    }

    




}
