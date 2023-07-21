using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    [SerializeField] private Material polygonMaterial;
    [SerializeField] private float maxAlpha = 1f;
    [SerializeField] private float minAlpha = 0f;
    [SerializeField] private float alphaPeriod = 1f;
    [SerializeField] private float colorPeriod = 1f;
    [SerializeField] private Color color1 = new Color(1f, 1f, 1f, 1f);
    [SerializeField] private Color color2 = new Color(0.5f, 0.5f, 0.5f, 1f);

    private Color color;

    // Start is called before the first frame update
    void Start()
    {
        color = color1;
        polygonMaterial.color = color;
        color = polygonMaterial.color;   
    }

    // Update is called once per frame
    void Update()
    {
        color.r = compareRGB(color1.r, color2.r);
        color.g = compareRGB(color1.g, color2.g);
        color.b = compareRGB(color1.b, color2.b);
        color.a = minAlpha + 0.5f * (Mathf.Sin(Time.time * alphaPeriod) + 1f) * (maxAlpha - minAlpha);
        polygonMaterial.color = color;
    }

    private float compareRGB(float color1, float color2)
    {
        if(color1 > color2) return color1 - 0.5f * (Mathf.Sin(Time.time * colorPeriod) + 1f) * (color1 - color2);
        else return color1 + 0.5f * (Mathf.Sin(Time.time * colorPeriod) + 1f) * (color2 - color1);
    }
}
