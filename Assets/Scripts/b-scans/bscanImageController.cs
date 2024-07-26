using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel.Channels;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class bscanImageController : MonoBehaviour
{
    public TargetImageController targetImageController;
    public AOIHeatmapOverlayController aoiHeatmapOverlayController;

    public Button button1, button2, button3, button4, button5;
    public Texture2D image1, image2, image3, image4, image5;
    public Texture2D heatmap1, heatmap2, heatmap3, heatmap4, heatmap5;

    // Start is called before the first frame update
    void Start()
    {
        
}

    // Update is called once per frame
    void Update()
    {
        button1.onClick.AddListener(delegate {setImage(image1); });
        button1.onClick.AddListener(delegate { SetHeatmapTexture(heatmap1); });

        button2.onClick.AddListener(delegate {setImage(image2); });
        button2.onClick.AddListener(delegate { SetHeatmapTexture(heatmap2); });

        button3.onClick.AddListener(delegate { setImage(image3); });
        button3.onClick.AddListener(delegate { SetHeatmapTexture(heatmap3); });

        button4.onClick.AddListener(delegate { setImage(image4); });
        button4.onClick.AddListener(delegate { SetHeatmapTexture(heatmap4); });

        button5.onClick.AddListener(delegate { setImage(image5); });
        button5.onClick.AddListener(delegate { SetHeatmapTexture(heatmap5); });
    }

    /*
    void setImage(Texture2D image)
    {
        targetImageController.setImage(image);
    }
    */

    void SetHeatmapTexture(Texture2D heatmap)
    {
        aoiHeatmapOverlayController.SetHeatmapTexture(heatmap);
    }
    

    void setImage(Texture2D image)
    {
        targetImageController.setImage(image);
    }
}
