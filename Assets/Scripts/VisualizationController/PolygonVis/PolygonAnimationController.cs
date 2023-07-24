using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonAnimationController : MonoBehaviour
{
    [Header("Polygon Rotation")]
    [SerializeField] private bool rotatingEffect = false;
    [SerializeField] private Transform polygonTransform;
    [SerializeField] private float angularSpeed = 45f;
    private float directedAngularSpeed;
    public enum Direction
    {
        Clockwise,
        CounterClockwise
    }

    public Direction direction = Direction.Clockwise;

    [Header("Polygon Radius")]
    [SerializeField] private bool radiusChangingEffect = false;
    [SerializeField] private float maxInnerRadius;
    [SerializeField] private float minInnerRadius;
    [SerializeField] private float innerRadiusChangingPeriod;
    [SerializeField] private float maxOuterRadius;
    [SerializeField] private float minOuterRadius;
    [SerializeField] private float outerRadiusChangingPeriod;
    [SerializeField] PolygonMeshRendererController meshRenderer;
    private float innerRadius;
    private float outerRadius;

    [Header("Material")]
    [SerializeField] private bool materialChangingEffect = false;
    [SerializeField] private Material polygonMaterial;
    [SerializeField] private float maxAlpha = 1f;
    [SerializeField] private float minAlpha = 0f;
    [SerializeField] private float alphaPeriod = 1f;
    [SerializeField] private float colorPeriod = 1f;
    [SerializeField] private Color color1 = new Color(1f, 1f, 1f, 1f);
    [SerializeField] private Color color2 = new Color(0.5f, 0.5f, 0.5f, 1f);

    private Color color;
    private Material materialCopy;

    // Start is called before the first frame update
    void Start()
    {
        materialCopy = Instantiate(polygonMaterial);
        Renderer objectRenderer = GetComponent<Renderer>();
        objectRenderer.material = materialCopy;

        color = color1;
        polygonMaterial.color = color;
        color = polygonMaterial.color;

        if (radiusChangingEffect == true)
        {
            meshRenderer.polygonRadius = maxOuterRadius;
            meshRenderer.polygonCenterRadius = maxInnerRadius;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Rotation
        if (rotatingEffect)
        {
            angularSpeed = Mathf.Abs(angularSpeed);
            if (direction == Direction.Clockwise) directedAngularSpeed = angularSpeed;
            else directedAngularSpeed = -angularSpeed;

            Quaternion currentRotation = polygonTransform.rotation;
            float rotationAmount = -directedAngularSpeed * Time.deltaTime;
            polygonTransform.Rotate(Vector3.forward, rotationAmount, Space.Self);
        }

        //Radius
        if (radiusChangingEffect)
        {
            meshRenderer.polygonRadius = maxOuterRadius - (maxOuterRadius - minOuterRadius) * Mathf.Sin((Time.time * 2 * Mathf.PI + 1f) / outerRadiusChangingPeriod) * 0.5f;
            meshRenderer.polygonCenterRadius = maxInnerRadius - (maxInnerRadius - minInnerRadius) * Mathf.Sin((Time.time * 2 * Mathf.PI + 1f) / innerRadiusChangingPeriod) * 0.5f;
        }
        if (!radiusChangingEffect)
        {
            meshRenderer.polygonRadius = meshRenderer.initialPolygonRadius;
            meshRenderer.polygonCenterRadius = meshRenderer.initialPolygonCenterRadius;
        }

        //Material
        if (materialChangingEffect)
        {
            color.r = compareRGB(color1.r, color2.r);
            color.g = compareRGB(color1.g, color2.g);
            color.b = compareRGB(color1.b, color2.b);
            color.a = minAlpha + (maxAlpha - minAlpha) * (Mathf.Sin((Time.time * 2 * Mathf.PI + 1f) / alphaPeriod)) * 0.5f;
            materialCopy.color = color;
        }
        if (!materialChangingEffect) materialCopy.color = new Color(1f, 1f, 1f, 1f);
    }

    private float compareRGB(float color1, float color2)
    {
        if (color1 > color2) return color1 - 0.5f * (Mathf.Sin((Time.time * 2 * Mathf.PI) + 1f) / colorPeriod) * (color1 - color2);
        else return color1 + 0.5f * (Mathf.Sin((Time.time * 2 * Mathf.PI) + 1f) / colorPeriod) * (color2 - color1);
    }
}
