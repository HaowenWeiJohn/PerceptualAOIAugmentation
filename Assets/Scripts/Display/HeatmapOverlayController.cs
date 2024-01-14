using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatmapOverlayController : MonoBehaviour
{
    // Start is called before the first frame update

    public RawImage heatmapOverlay;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHeatmapTexture(Texture2D texture, bool setNativeSize = true)
    {
        heatmapOverlay.texture = texture;

        if (setNativeSize)
        {
            heatmapOverlay.SetNativeSize();
        }

    }

    public bool HeatmapOverlayEnabled()
    {
        return heatmapOverlay.enabled;
    }

    public void SetHeatmapVisibility(bool enabled)
    {
        heatmapOverlay.enabled = enabled;
    }

    public void CleanUp()
    {
        heatmapOverlay.texture = null;
        heatmapOverlay.enabled = false;
    }


}
