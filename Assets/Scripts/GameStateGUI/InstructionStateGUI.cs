using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InstructionStateGUI : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI instructionTitle;
    public TextMeshProUGUI instuctionContent;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setInstructionTitle(string text)
    {
        instructionTitle.text = text;
    }

    public void setInstructionContent(string text)
    {
        instuctionContent.text = text;
    }

    public void SetEnabled()
    {
        gameObject.SetActive(true);
    }

    public void SetDisabled()
    {
        gameObject.SetActive(false);
    }

}
