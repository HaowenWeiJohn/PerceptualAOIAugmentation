using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StaticAOIAugmentationOverlayController : GUIController
{


    public DisplayCoordinateController displayCoordinateController;
    public TargetImageController targetImageController;


    public StaticAOIAugmentationStateLSLInletController staticAOIAugmentationStateLSLInletController;


    // Start is called before the first frame update
    void Start()
    {
        targetImageController.updateTargetImageInfo();
    }

    // Update is called once per frame
    void Update()
    {
        float updateFrequency = 1.0f / Time.deltaTime;
        //Debug.Log("Update Frequency: " + updateFrequency + " FPS");
    }







    public override void EnableSelf()
    {
        base.EnableSelf();
    }

    public override void DisableSelf()
    {
        base.DisableSelf();
    }
    // we cannot enable all polygons, this will kill the process!!!!

}
