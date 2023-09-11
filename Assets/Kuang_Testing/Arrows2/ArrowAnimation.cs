using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAnimation : MonoBehaviour
{
    public GameObject objectToReplicate; // The object to replicate
    public Transform origin;
    public Transform targetObject;
    public int numberOfReplicas = 10; // Number of replicas to create
    public float spacing = 1.0f; // Spacing between replicas
    public float replicationDelay = 0.2f; // Time delay between each replication in seconds
    public float removalDelay = 0.2f; // Time delay between each removal in seconds
    public int removeAfterReplicas = 3; // Number of replicas after which removal should start
    public float offset = 0.5f;
    public bool finished = true;

    private List<GameObject> replicatedObjects = new List<GameObject>();


    void Start()
    {
        //StartCoroutine(ReplicateObjects(targetObject));
    }

    public IEnumerator ReplicateObjects(Transform target)
    {
        finished = false;
        // Get the direction of the object's Y-axis
        Vector3 direction = target.position - origin.transform.position;
        direction.Normalize();
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, -direction);

        for (int i = 1; i <= numberOfReplicas; i++)
        {
            // Calculate the position for the new replica
            Vector3 newPosition = origin.transform.position + (direction * i * spacing) + direction * offset;

            // Instantiate a new replica at the calculated position with the same rotation
            GameObject newObject = Instantiate(objectToReplicate, newPosition, rotation);

            // Optionally, you can set the new object as a child of this GameObject for organization purposes
            newObject.transform.SetParent(transform);

            // Add the new replica to the list of replicated objects
            replicatedObjects.Add(newObject);

            yield return new WaitForSeconds(replicationDelay);

            // Check if we have reached the threshold to start removing replicas
            if (replicatedObjects.Count >= removeAfterReplicas)
            {
                // Start the removal coroutine
                StartCoroutine(RemoveReplicates());
            }
        }
    }

    public IEnumerator RemoveReplicates()
    {
        while (replicatedObjects.Count > 0)
        {
            // Remove the earliest object in the list and destroy it
            GameObject objectToRemove = replicatedObjects[0];
            replicatedObjects.RemoveAt(0);
            Destroy(objectToRemove);

            yield return new WaitForSeconds(removalDelay);
        }
        finished = true;
        //if(replicatedObjects.Count == 0) StartCoroutine(ReplicateObjects(targetObject));
    }
}
