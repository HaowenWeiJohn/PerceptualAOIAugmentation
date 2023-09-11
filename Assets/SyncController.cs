using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncController : MonoBehaviour
{
    private int arrowCount;
    // Start is called before the first frame update
    void Start()
    {
        arrowCount = GameObject.FindGameObjectsWithTag("Arrow").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Waiting").Length == arrowCount)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Waiting");
            foreach (GameObject i in objects)
            {
                i.tag = "Starting";
            }
        }
    }
}
