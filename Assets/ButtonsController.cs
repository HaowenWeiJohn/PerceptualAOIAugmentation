using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsController : MonoBehaviour
{
    // Assign these in the Unity Inspector
    public GameObject[] objectsToDeactivate;

    // This method is called when the GameObject becomes active
    private void OnEnable()
    {
        DeactivateObjects();
    }

    private void OnDisable()
    {
        ActivateObjects();
    }

    // This method will deactivate the specified objects
    private void DeactivateObjects()
    {
        foreach (GameObject obj in objectsToDeactivate)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }

    private void ActivateObjects()
    {
        foreach (GameObject obj in objectsToDeactivate)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}
