using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow2sController : MonoBehaviour
{
    public ArrowAnimation controller1;
    public ArrowAnimation controller2;
    public ArrowAnimation controller3;
    public Transform cursor;


    public List<ArrowAnimation> targets = new List<ArrowAnimation>();
    public float waitTime = 1.0f;

    private float startTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        targets.Add(controller1);
        targets.Add(controller2);
        targets.Add(controller3);

        startTime = Time.time;
        StartCoroutine(controller1.ReplicateObjects(controller1.targetObject));
        StartCoroutine(controller2.ReplicateObjects(controller2.targetObject));
        StartCoroutine(controller3.ReplicateObjects(controller3.targetObject));
    }

    // Update is called once per frame
    void Update()
    {
        if(controller1.finished && controller2.finished && controller3.finished)
        {
            foreach(ArrowAnimation AA in targets)
            {
                StartCoroutine(AA.ReplicateObjects(AA.targetObject));
            }
        }
        foreach(ArrowAnimation AA in targets)
        {
            if(Vector3.Distance(cursor.position, AA.targetObject.position) < 0.5f)
            targets.Remove(AA);
        }
    }

    public IEnumerator Wait(float x)
    {
        yield return new WaitForSeconds(waitTime);
    }
}
