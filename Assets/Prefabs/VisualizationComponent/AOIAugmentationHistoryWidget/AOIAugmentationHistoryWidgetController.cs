using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static FullscreenEditor.FullscreenUtility;

public class AOIAugmentationHistoryWidgetController : MonoBehaviour
{
    // Start is called before the first frame update

    public Toggle visualizationToggleSelection;
    public ScrollRect interactiveAOIAugmentationHistoryScrollViewScrollRect;


    public int historyWidgetIndex;

    public Image aoiBackgroundImage;
    public Image aoiBackgroundImageHeatmapOverlayImage;

    public Image gazeAttentionBackgroundImage;
    public Image gazeAttentionBackgroundImageHeatmapOverlayImage;

    public TargetImageController targetImageController;
    public AOIHeatmapOverlayController aoiHeatmapOverlayController;

    [Header("Event Marker")]
    public EventMarkerLSLOutletController eventMarkerLSLOutletController;

    void Start()
    {

        visualizationToggleSelection.onValueChanged.AddListener(OnAOIAugmentationHistoryWidgetSelected);
        // set scroll rect to bottom

    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void SetAOIBackgroundImageTexture(Texture2D texture)
    {
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        aoiBackgroundImage.sprite = sprite;
        // keep aspect ratio
        aoiBackgroundImage.preserveAspect = true;
    }

    public void SetAOIBackgroundImageHeatmapOverlayImageTexture(Texture2D texture)
    {
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        aoiBackgroundImageHeatmapOverlayImage.sprite = sprite;
        // keep aspect ratio
        aoiBackgroundImageHeatmapOverlayImage.preserveAspect = true;
    }

    public void SetGazeAttentionBackgroundImageTexture(Texture2D texture)
    {
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        gazeAttentionBackgroundImage.sprite = sprite;
        // keep aspect ratio
        gazeAttentionBackgroundImage.preserveAspect = true;
    }

    public void SetGazeAttentionBackgroundImageHeatmapOverlayImageTexture(Texture2D texture)
    {
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        gazeAttentionBackgroundImageHeatmapOverlayImage.sprite = sprite;
        // keep aspect ratio
        gazeAttentionBackgroundImageHeatmapOverlayImage.preserveAspect = true;
    }

    public void OnAOIAugmentationHistoryWidgetSelected(bool isOn)
    {
        if (isOn)
        {
            aoiHeatmapOverlayController.SetHeatmapTexture(aoiBackgroundImageHeatmapOverlayImage.sprite.texture);
            visualizationToggleSelection.image.color = Color.gray;

            // send history selected event
            eventMarkerLSLOutletController.sendVisualCueHistorySelectedMarker(historyWidgetIndex);

        }
        else
        {
            visualizationToggleSelection.image.color = Color.white;
        }
    }


    public void InitAOIAugmentationHistoryWidgetSelected()
    {
        aoiHeatmapOverlayController.SetHeatmapTexture(aoiBackgroundImageHeatmapOverlayImage.sprite.texture);
        visualizationToggleSelection.image.color = Color.gray;
    }


}
