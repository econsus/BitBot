using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Dialog dialog;

    public GameObject conversation;

    public float waitTime = 0.3f;

    public float typingWaitTime = 0.02f;

    private PlayerMovement move;

    private GameObject chatBubble;

    private Animator anim;

    private DialogUI dialogUI;

    private int activeIndex = 0;

    private bool canTalk;

    private bool canSkip = true;

    void Start()
    {
        move = FindObjectOfType<PlayerMovement>();
        chatBubble = GameObject.Find("Chat Bubble");

        anim = chatBubble.GetComponentInChildren<Animator>();
        
        dialogUI = conversation.GetComponent<DialogUI>();

        dialogUI.Speaker = dialog.character;

        chatBubble.SetActive(false);

        dialogUI.HideNextSymbol();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            chatBubble.SetActive(true);
            anim.SetBool("canTalk", true);

            canTalk = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            canTalk = false;
            anim.SetBool("canTalk", false);

            StartCoroutine(HideChatBubble(waitTime));
        }
    }

    IEnumerator HideChatBubble(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        chatBubble.SetActive(false);
    }
    void Update()
    {
        if(canTalk && canSkip && Input.GetKeyDown(KeyCode.E))
        {
            move.Halt();
            move.enabled = false;
            Next();
        }
        if(canSkip)
        {
            dialogUI.ShowNextSymbol();
        }
        else
        {
            dialogUI.HideNextSymbol();
        }
    }

    private void Next()
    {
        if(activeIndex < dialog.sentences.Length)
        {
            DisplaySentence();
            activeIndex += 1;
        }
        else
        {
            dialogUI.Hide();
            activeIndex = 0;
            move.enabled = true;
        }
    }

    private void DisplaySentence()
    {
        Sentence line = dialog.sentences[activeIndex];

        StartCoroutine(SetDialog(dialogUI, line.sentence, typingWaitTime));
    }
    IEnumerator SetDialog(DialogUI activeDUI, string text, float t)
    {
        activeDUI.Dialog = "";
        activeDUI.Show();
        int i = 0;
        foreach(char letter in text.ToCharArray())
        {
            canSkip = false;
            activeDUI.Dialog += letter;
            if (i > 0 && Input.GetKeyDown(KeyCode.E))
            {
                activeDUI.Dialog = "";
                activeDUI.Dialog = text;
            }
            else
            {
                yield return new WaitForSecondsRealtime(t);
            }
            i++;
        }
        canSkip = true;
    }
}
