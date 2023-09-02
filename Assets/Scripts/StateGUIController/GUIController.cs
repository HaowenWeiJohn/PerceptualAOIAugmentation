using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }


    public virtual void EnableSelf()
    {
        gameObject.SetActive(true);
    }

    public virtual void DisableSelf()
    {
        gameObject.SetActive(false);
    }
}
