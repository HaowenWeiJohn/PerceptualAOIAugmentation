using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject prefabX; // The prefab to be instantiated
    public GameObject parentObject; // The object to which the generated prefab will be attached
    public float offset = 1.0f; // Offset distance from the origin
    public float moveSpeed = 3.0f; // Speed at which the prefabs move

    public Transform origin;
    public Transform targetA;
    public Transform targetB;
    public Transform targetC;

    void Start()
    {
        // Assuming you have these targets in your scene
        // targetA = GameObject.Find("TargetA").transform;
        // targetB = GameObject.Find("TargetB").transform;
        // targetC = GameObject.Find("TargetC").transform;

        GenerateAndMovePrefab(targetA);
        GenerateAndMovePrefab(targetB);
        GenerateAndMovePrefab(targetC);
    }

    void GenerateAndMovePrefab(Transform target)
    {
        // Instantiate the prefab at an offset from the origin
        Vector3 spawnPosition = origin.position + (target.position - origin.position).normalized;
        GameObject spawnedPrefab = Instantiate(prefabX, spawnPosition, Quaternion.identity);

        // Calculate the rotation angle around the Z-axis
        Vector2 direction = target.position - spawnPosition;
        float angle = Vector2.SignedAngle(origin.up, (target.position - origin.position).normalized);

        // Apply the rotation to the prefab
        spawnedPrefab.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // Set the parentObject as the parent of the spawned prefab
        spawnedPrefab.transform.parent = parentObject.transform;

        // Apply the destination offset
        Vector3 offsetTargetPosition = target.position - offset * (target.position - spawnPosition).normalized;


        StartCoroutine(MoveToTargetAndDestroy(spawnedPrefab.transform, offsetTargetPosition));
    }

    IEnumerator MoveToTargetAndDestroy(Transform prefab, Vector3 targetPosition)
    {
        // Get the TrailRenderer component from the prefab's children
        TrailRenderer trail = prefab.GetComponentInChildren<TrailRenderer>();

        while (Vector3.Distance(prefab.position, targetPosition) > offset)
        {
            prefab.position = Vector3.MoveTowards(prefab.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        //Wait until the trail is gone
        while (trail && trail.isVisible)
        {
            yield return null;
        }

        // Destroy the prefab once the trail is gone
        Destroy(prefab.gameObject);
    }
}
