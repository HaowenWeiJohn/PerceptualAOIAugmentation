using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    [Header("Polygon Rotation")]
    [SerializeField] private Transform polygonTransform;
    [SerializeField] private float angularSpeed = 45f;

    public enum Direction
    {
        Clockwise,
        CounterClockwise
    }

    public Direction direction = Direction.Clockwise;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == Direction.Clockwise) angularSpeed = Mathf.Abs(angularSpeed);
        else angularSpeed = -Mathf.Abs(angularSpeed);

        Quaternion currentRotation = polygonTransform.rotation;

        // Calculate the rotation amount for this frame based on angular speed and time
        float rotationAmount = -angularSpeed * Time.deltaTime;

        // Apply the rotation around the object's center
        polygonTransform.Rotate(Vector3.forward, rotationAmount, Space.Self);

        // Ensure the object keeps its original rotation in other axes (optional)
        //Vector3 currentEulerAngles = polygonTransform.rotation.eulerAngles;
        //currentEulerAngles.x = currentRotation.eulerAngles.x;
        //currentEulerAngles.y = currentRotation.eulerAngles.y;
        //polygonTransform.rotation = Quaternion.Euler(currentEulerAngles);
    }
}
