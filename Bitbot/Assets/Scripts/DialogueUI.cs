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


    //[SerializeField] private float typingSpeed = 0.02f;

    //IEnumerator typeText(float typingSpeed)
    //{
    //    foreach (char letter in sentences[index].ToCharArray())
    //    {
    //        sentenceDisplay.text += letter;
    //        yield return new WaitForSecondsRealtime(typingSpeed);

    //    }
    //}
}