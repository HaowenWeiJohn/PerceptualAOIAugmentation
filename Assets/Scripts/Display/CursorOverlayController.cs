using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorOverlayController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cursorOverlay;
    public float planeDisatance;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // Get the mouse position in world coordinates4

        Vector3 mouseInputPos = Input.mousePosition;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = planeDisatance;
        // Ensure the object stays on the 2D plane
        // Move the object to the mouse position
        cursorOverlay.transform.position = mousePosition;

        
        Debug.Log("Start");
        Debug.Log(mouseInputPos);
        Debug.Log(mousePosition);

    }
}
