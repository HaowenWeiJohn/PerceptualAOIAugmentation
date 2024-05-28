using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AOIHeatmapController : MonoBehaviour
{
    // Start is called before the first frame update

    public RawImage rawImage;
    public int[][] imagePosition;
    public TargetImageController targetImageController;
    public RectTransform heatmapRectTransform;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void setHeatmapTexture(Texture2D texture, List<int> imagePositionList)
    {
        
        rawImage.texture = texture;
        rawImage.SetNativeSize();
        // change this to reshape method in the future
        imagePosition = new int[][] {
            new int[] {imagePositionList[0], imagePositionList[1]},
            new int[] {imagePositionList[2], imagePositionList[3]},
            new int[] {imagePositionList[4], imagePositionList[5]},
            new int[] {imagePositionList[6], imagePositionList[7]},
        };

        // set position 
        float centerX = (imagePosition[0][0] + imagePosition[2][0]) / 2 - targetImageController.originalImageWidth / 2;
        float centerY =  - (imagePosition[0][1] + imagePosition[2][1]) / 2 + targetImageController.originalImageHeight / 2;
        
        heatmapRectTransform.localPosition = new Vector3(centerX, centerY, heatmapRectTransform.localPosition.z);


    }


}
