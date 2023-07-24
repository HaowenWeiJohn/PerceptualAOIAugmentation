using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonVisualizationController : MonoBehaviour
{
    // Start is called before the first frame update
    public PolygonMeshRendererController polygonMeshRendererController;

    public Presets.DisplayState currentDisplayState = Presets.DisplayState.Show;

    public Presets.ShowStateAlphaVisualizaton showStateAlphaVisualizaton = Presets.ShowStateAlphaVisualizaton.Static;
    public Presets.ShowStateColorVisualization showStateColorVisualizaton = Presets.ShowStateColorVisualization.Static;
    public Presets.ShowStateGeometryVisualization showStateGeometryVisualizaton = Presets.ShowStateGeometryVisualization.Static;

    public Presets.ShowToHideStateVisualization showToHideStateVisualization = Presets.ShowToHideStateVisualization.Static;

    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        switch (currentDisplayState)
        {
            case Presets.DisplayState.Show:
                showState(); // display animation
                break;
            case Presets.DisplayState.ShowToHide:
                showToHideState();
                break;
            case Presets.DisplayState.Hide:
                hideState();
                break;
            case Presets.DisplayState.HideToShow:
                hideToShowState();
                break;
        }
    }

    //void ShowStateToShowToHideState()
    //{
    //    polygonMeshRendererController.setInitialGeometryMaterial();
    //    currentDisplayState = Presets.DisplayState.ShowToHide;
    //}






    
    // update show visualization
    void showState()
    {
        // alpha transfer
        switch (showStateAlphaVisualizaton)
        {
            case Presets.ShowStateAlphaVisualizaton.Static:
                showStateAlphaVisualizatonStatic();
                break;
            case Presets.ShowStateAlphaVisualizaton.DynamicOnOff: // TODO add this visualization
                break;
        }


        switch (showStateColorVisualizaton)
        {
            case Presets.ShowStateColorVisualization.Static:
                showStateColorVisualizatonStatic();
                break;
            case Presets.ShowStateColorVisualization.DynamicTransfer: // TODO add this visualization
                break;
        }


    }

    void hideState()
    {
        // switch.... Nothing
    }


    void showToHideState()
    {
        // always reset to oritinal before transfer
        switch (showToHideStateVisualization)
        {
            case Presets.ShowToHideStateVisualization.Static:
                showToHideStateVisualizationStatic();
                break;
            case Presets.ShowToHideStateVisualization.Fade:
                break;
            case Presets.ShowToHideStateVisualization.Explode:
                break;
            case Presets.ShowToHideStateVisualization.Shrink:
                break;
        }
    }

    void hideToShowState()
    {
        // set master clock

        enableRenderer();
        currentDisplayState = Presets.DisplayState.Show;
    }


    void showStateAlphaVisualizatonStatic()
    {
        // do nothing
    }

    void showStateColorVisualizatonStatic()
    {
        // do nothing
    }


    void showToHideStateVisualizationStatic()
    {
        disableRenderer();
        currentDisplayState = Presets.DisplayState.Hide;
    }



    void enableRenderer()
    {
        polygonMeshRendererController.meshRenderer.enabled = true;
    }

    void disableRenderer()
    {
        polygonMeshRendererController.meshRenderer.enabled = false;

    }

    void enablSelf()
    {
        gameObject.SetActive(true);
    }


    void disableSelf()
    {
        gameObject.SetActive(false);
    }


}
