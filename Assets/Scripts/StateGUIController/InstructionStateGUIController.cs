using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InstructionStateGUIController : GUIController
{
    // Start is called before the first frame update
    public TextMeshProUGUI instructionTitle;
    public TextMeshProUGUI instuctionContent;

    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public void setInstructionTitle(string text)
    {
        instructionTitle.text = text;
    }

    public void setInstructionContent(string text)
    {
        instuctionContent.text = text;
    }

    //public void EnableSelf()
    //{
    //    gameObject.SetActive(true);
    //}

    //public void DisableSelf()
    //{
    //    gameObject.SetActive(false);
    //}

}
