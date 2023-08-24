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

    [Header("Blink")]
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float triggerDistance = 5f;
    [SerializeField] private bool blinkEffect = false;
    [SerializeField] private float blinkFrequency = 1f;
    private bool isBlinking = false;

    [Header("Disappear")]
    [SerializeField] private bool disappear = false;
    [SerializeField] private float disappearDistance = 0.25f;
    [SerializeField] private float reappearDistance = 2f;
    [SerializeField] private float staringTime = 2f;
    [SerializeField] private float reappearingTime = 3f;
    private float timeStamp = 0f;
    private bool isTiming = false;

    private Renderer objectRenderer;
    
    

    // Start is called before the first frame update
    void Start()
    {
        materialCopy = Instantiate(polygonMaterial);
        materialCopy.name = polygonMaterial.name;
        objectRenderer = GetComponent<Renderer>();
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
        if(materialCopy.name != polygonMaterial.name) 
        {
            Destroy(materialCopy);
            materialCopy = Instantiate(polygonMaterial);
            materialCopy.name = polygonMaterial.name;
            //Renderer objectRenderer = GetComponent<Renderer>();
            objectRenderer.material = materialCopy;
        }

        if (materialChangingEffect)
        {
            color.r = compareRGB(color1.r, color2.r);
            color.g = compareRGB(color1.g, color2.g);
            color.b = compareRGB(color1.b, color2.b);
            color.a = minAlpha + (maxAlpha - minAlpha) * (Mathf.Sin((Time.time * 2 * Mathf.PI + 1f) / alphaPeriod)) * 0.5f;
            materialCopy.color = color;
        }
        if (!materialChangingEffect)
        {
            Color tempColor = materialCopy.color;
            tempColor.a = 1f;
            materialCopy.color = tempColor;
        } 

        //Blink
        //============================================================================
        if(Vector3.Distance(transform.position, targetTransform.position) < triggerDistance) blinkEffect = false;
        if(Vector3.Distance(transform.position, targetTransform.position) >= triggerDistance) blinkEffect = true;

        if(blinkEffect)
        {
            rotatingEffect = false;
            materialChangingEffect = false;
            radiusChangingEffect = false;
            meshRenderer.polygonRadius = maxOuterRadius;
            meshRenderer.polygonCenterRadius = 0f;
            transform.rotation = Quaternion.identity;
            StartBlinking();
        }
        if(!blinkEffect && !disappear)
        {
            StopBlinking();
            rotatingEffect = true;
            materialChangingEffect = true;
            radiusChangingEffect = true;
        }

        //Disappear when staring
        //================================================================================
        if(Vector3.Distance(transform.position, targetTransform.position) < disappearDistance)
        {
            if(!isTiming)
            {
                timeStamp = Time.time;
                isTiming = true;
            }
            materialChangingEffect = false;
            
            if((Time.time - timeStamp) < staringTime)
            {
                color.a = maxAlpha - maxAlpha * (Time.time - timeStamp) / staringTime;
            }
            else 
            {
                color.a = 0f;
                disappear = true;
            }

            materialCopy.color = color;
        }
        if(Vector3.Distance(transform.position, targetTransform.position) >= reappearDistance)
        {
            //objectRenderer.enabled = true; 
            isTiming = false;
            disappear = false;
        }


        if(Vector3.Distance(transform.position, targetTransform.position) >= disappearDistance) blinkEffect = true;

    }

    private float compareRGB(float color1, float color2)
    {
        if (color1 > color2) return color1 - 0.5f * (Mathf.Sin((Time.time * 2 * Mathf.PI) + 1f) / colorPeriod) * (color1 - color2);
        else return color1 + 0.5f * (Mathf.Sin((Time.time * 2 * Mathf.PI) + 1f) / colorPeriod) * (color2 - color1);
    }

    public void ResetColor(Color newColor)
    {
        color1 = newColor;
        color2 = newColor;
    }

    public void SetColor1(Color newColor)
    {
        color1 = newColor;
    }

    public void SetMaterial(Material newMaterial)
    {
        polygonMaterial = newMaterial;
    }

    //Blink helper functions
    private void StartBlinking()
    {
        if(Time.time % ( 1f / blinkFrequency) > (0.5f * ( 1f / blinkFrequency))) objectRenderer.enabled = true;
        else objectRenderer.enabled = false;
    }

    private void StopBlinking()
    {
        objectRenderer.enabled = true;
    }

}