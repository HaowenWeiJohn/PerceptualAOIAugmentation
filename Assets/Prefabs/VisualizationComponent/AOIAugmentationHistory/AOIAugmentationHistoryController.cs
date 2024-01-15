using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AOIAugmentationHistoryController : MonoBehaviour
{
    // Start is called before the first frame update

    public Toggle VisualizationToggleSelection;

    public Image AOIBackgroundImage;
    public Image AOIBackgroundImageHeatmapOverlayImage;

    public Image GazeAttentionBackgroundImage;
    public Image GazeAttentionBackgroundImageHeatmapOverlayImage;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void SetAOIBackgroundImageTexture(Texture2D texture)
    {
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        AOIBackgroundImage.sprite = sprite;
        // keep aspect ratio
        AOIBackgroundImage.preserveAspect = true;
    }

    public void SetAOIBackgroundImageHeatmapOverlayImageTexture(Texture2D texture)
    {
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        AOIBackgroundImageHeatmapOverlayImage.sprite = sprite;
        // keep aspect ratio
        AOIBackgroundImageHeatmapOverlayImage.preserveAspect = true;
    }

    public void SetGazeAttentionBackgroundImageTexture(Texture2D texture)
    {
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        GazeAttentionBackgroundImage.sprite = sprite;
        // keep aspect ratio
        GazeAttentionBackgroundImage.preserveAspect = true;
    }

    public void SetGazeAttentionBackgroundImageHeatmapOverlayImageTexture(Texture2D texture)
    {
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        GazeAttentionBackgroundImageHeatmapOverlayImage.sprite = sprite;
        // keep aspect ratio
        GazeAttentionBackgroundImageHeatmapOverlayImage.preserveAspect = true;
    }

    public Texture2D GetHeatmapOverlayImageTexture()
    {
        return AOIBackgroundImageHeatmapOverlayImage.sprite.texture;
    }


}
