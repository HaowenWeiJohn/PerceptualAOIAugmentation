using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FeedbackStateGUIController : GUIController
{
    // Start is called before the first frame update

    public TMP_InputField scoreInputField;
    public TMP_InputField messageInputField;

    [Header("Digits Buttons")]
    public Button oneButton;
    public Button twoButton;
    public Button threeButton;
    public Button fourButton;
    public Button fiveButton;
    public Button sixButton;
    public Button sevenButton;
    public Button eightButton;
    public Button nineButton;

    [Header("Delete Buttons")]
    public Button deleteButton;




    void Start()
    {
        base.Update();

        scoreInputField.onValidateInput += scoreInputFeildValidator;

        oneButton.onClick.AddListener(oneButtonPressed);
        twoButton.onClick.AddListener(twoButtonPressed);
        threeButton.onClick.AddListener(threeButtonPressed);
        fourButton.onClick.AddListener(fourButtonPressed);
        fiveButton.onClick.AddListener(fiveButtonPressed);
        sixButton.onClick.AddListener(sixButtonPressed);
        sevenButton.onClick.AddListener(sevenButtonPressed);
        eightButton.onClick.AddListener(eightButtonPressed);
        nineButton.onClick.AddListener(nineButtonPressed);

        deleteButton.onClick.AddListener(deleteButtonPressed);




    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        


    }

    private char scoreInputFeildValidator(string text, int charIndex, char addedChar)
    {


        if (!char.IsDigit(addedChar))
        {
            addedChar = '\0'; // Replace the character with null ('\0') to prevent it from being entered
            return addedChar;
        }

        // check if the score is larger than Presets.MaxScore
        int currentValue;
        int.TryParse(text+addedChar, out currentValue);
        Debug.Log(currentValue);
        if (currentValue > Presets.MaxScore)
        {
            addedChar = '\0';
            return addedChar;
        }

        return addedChar;


    }



    private void oneButtonPressed()
    {
        int score;
        int.TryParse(scoreInputField.text + "1", out score);
        if (score < Presets.MaxScore)
        {
            scoreInputField.text = scoreInputField.text + "1";
        }
    }

    private void twoButtonPressed()
    {
        int score;
        int.TryParse(scoreInputField.text + "2", out score);
        if (score < Presets.MaxScore)
        {
            scoreInputField.text = scoreInputField.text + "2";
        }
    }

    private void threeButtonPressed()
    {
        int score;
        int.TryParse(scoreInputField.text + "3", out score);
        if (score < Presets.MaxScore)
        {
            scoreInputField.text = scoreInputField.text + "3";
        }
    }

    private void fourButtonPressed()
    {
        int score;
        int.TryParse(scoreInputField.text + "4", out score);
        if (score < Presets.MaxScore)
        {
            scoreInputField.text = scoreInputField.text + "4";
        }
    }

    private void fiveButtonPressed()
    {
        int score;
        int.TryParse(scoreInputField.text + "5", out score);
        if (score < Presets.MaxScore)
        {
            scoreInputField.text = scoreInputField.text + "5";
        }
    }

    private void sixButtonPressed()
    {
        int score;
        int.TryParse(scoreInputField.text + "6", out score);
        if (score < Presets.MaxScore)
        {
            scoreInputField.text = scoreInputField.text + "6";
        }
    }

    private void sevenButtonPressed()
    {
        int score;
        int.TryParse(scoreInputField.text + "7", out score);
        if (score < Presets.MaxScore)
        {
            scoreInputField.text = scoreInputField.text + "7";
        }
    }

    private void eightButtonPressed()
    {
        int score;
        int.TryParse(scoreInputField.text + "8", out score);
        if (score < Presets.MaxScore)
        {
            scoreInputField.text = scoreInputField.text + "8";
        }
    }

    private void nineButtonPressed()
    {
        int score;
        int.TryParse(scoreInputField.text + "9", out score);
        if (score < Presets.MaxScore)
        {
            scoreInputField.text = scoreInputField.text + "9";
        }
    }


    private void deleteButtonPressed()
    {
        string scoreText = scoreInputField.text;
        if (!string.IsNullOrEmpty(scoreText))
        {
            scoreInputField.text = scoreText.Substring(0, scoreText.Length - 1);
        }
    }


    public int getScore() {
        int score;
        int.TryParse(scoreInputField.text, out score);
        return score;
    }

    public string getMessage()
    {
        return messageInputField.text;
    }

    public void clearFeedback()
    {
        scoreInputField.text = "";
        messageInputField.text = "";
    }


    public void EnableSelf()
    {
        clearFeedback();
        base.EnableSelf();
    }

    public void DisableSelf()
    {
        clearFeedback();
        base.DisableSelf();
    }

}
