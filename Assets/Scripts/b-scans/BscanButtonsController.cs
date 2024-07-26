using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BscanButtonsController : MonoBehaviour
{

    [Header("Buttons")]
    public GameObject noAOIButtons;
    public GameObject staticAOIButtons;
    public GameObject resnetAOIButtons;

    void OnEnable()
    {
        noAOIButtons.SetActive(false);
        staticAOIButtons.SetActive(false);
        resnetAOIButtons.SetActive(false);
    }

    void OnDisable()
    {
        noAOIButtons.SetActive(true);
        staticAOIButtons.SetActive(true);
        resnetAOIButtons.SetActive(true);
    }
}
