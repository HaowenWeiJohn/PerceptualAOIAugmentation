using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithCursor : MonoBehaviour
{
    void Update()
    {
        // Get the cursor position in screen coordinates
        Vector3 cursorScreenPosition = Input.mousePosition;

        // Convert screen coordinates to world coordinates
        Vector3 cursorWorldPosition = Camera.main.ScreenToWorldPoint(cursorScreenPosition);

        // Set the object's position to follow the cursor
        transform.position = new Vector3(cursorWorldPosition.x, cursorWorldPosition.y, transform.position.z);
    }
}
