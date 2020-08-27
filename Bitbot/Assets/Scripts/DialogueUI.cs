using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public Image portraitDisplay, nextDisplay;
    public TextMeshProUGUI nameDisplay, sentenceDisplay;

    private Character speaker;
    public Character Speaker
    {
        get 
        {
            return speaker;
        }
        set 
        {
            speaker = value;

            portraitDisplay.sprite = speaker.characterPortrait;
            nameDisplay.text = speaker.characterName;
        }
    }

    public string Dialogue
    {
        get
        {
            return sentenceDisplay.text;
        }
        set 
        { 
            sentenceDisplay.text = value;
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void ShowNextSymbol()
    {
        nextDisplay.enabled = true;
    }
    public void HideNextSymbol()
    {
        nextDisplay.enabled = false;
    }
}