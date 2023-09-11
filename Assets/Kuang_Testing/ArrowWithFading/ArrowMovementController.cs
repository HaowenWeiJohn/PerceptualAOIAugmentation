using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovementController : MonoBehaviour
{
    public Transform positionA;  // Starting position
    public Transform positionB;  // Destination position
    public float offset = 2.0f;  // Distance offset
    public float moveSpeed = 5.0f;

    private Color initialColor;
    private bool moving = false;
    private Vector3 directionAB;

    private void Start()
    {
        // Calculate the direction vector from A to B and set the initial position
        directionAB = (positionB.position - positionA.position).normalized;
        initialColor = transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color;

        // Start moving towards B
        moving = true;
    }

    private void Update()
    {
        if(gameObject.tag != "Checked")
        {
            if(gameObject.tag == "Starting")
            {
                gameObject.tag = "Moving";
                transform.position = positionA.position + directionAB * offset;
                transform.rotation = Quaternion.LookRotation(Vector3.forward, -directionAB);
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = initialColor;
            }
            if(gameObject.tag == "Moving")
            {
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, positionB.position, step);

                // Check distance and deactivate if necessary
                if (Vector3.Distance(transform.position, positionB.position) < offset)
                {
                    moving = false;
                    transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = new Color(initialColor.r, initialColor.g, initialColor.b, 0f);
                    gameObject.tag = "Waiting";
                }
            }
        }
    }
}
