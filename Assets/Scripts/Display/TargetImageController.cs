using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetImageController : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform targetImageRectTransform;

    public Vector2 targetImageShape = new Vector2 (0, 0);
    public Vector2 targetImagePosition = new Vector2(0, 0);

    void Start()
    {
        updateTargetImageInfo();
    }

    // Update is called once per frame
    void Update()
    {
        updateTargetImageInfo();
    }

    public void updateTargetImageInfo()
    {
        targetImageShape[0] = targetImageRectTransform.rect.height;
        targetImageShape[1] = targetImageRectTransform.rect.width;
    }

}
