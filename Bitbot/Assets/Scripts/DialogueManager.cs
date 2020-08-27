using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Dialogue dialogue;

    public GameObject conversation;

    public float waitTime = 0.3f;

    public float typingWaitTime = 0.02f;

    private PlayerMovement move;

    private GameObject chatBubble;

    private Animator anim;

    private DialogueUI dialogueUI;

    private int activeIndex = 0;

    private bool canTalk;

    private bool canSkip = true;

    void Start()
    {
        move = FindObjectOfType<PlayerMovement>();
        chatBubble = GameObject.Find("Chat Bubble");

        anim = chatBubble.GetComponentInChildren<Animator>();
        
        dialogueUI = conversation.GetComponent<DialogueUI>();

        dialogueUI.Speaker = dialogue.character;

        chatBubble.SetActive(false);

        dialogueUI.HideNextSymbol();
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
            dialogueUI.ShowNextSymbol();
        }
        else
        {
            dialogueUI.HideNextSymbol();
        }
    }

    private void Next()
    {
        if(activeIndex < dialogue.sentences.Length)
        {
            DisplaySentence();
            activeIndex += 1;
        }
        else
        {
            dialogueUI.Hide();
            activeIndex = 0;
            move.enabled = true;
        }
    }

    private void DisplaySentence()
    {
        Sentence line = dialogue.sentences[activeIndex];

        StartCoroutine(SetDialogue(dialogueUI, line.sentence, typingWaitTime));
    }
    IEnumerator SetDialogue(DialogueUI activeDUI, string text, float t)
    {
        activeDUI.Dialogue = "";
        activeDUI.Show();
        int i = 0;
        foreach(char letter in text.ToCharArray())
        {
            canSkip = false;
            activeDUI.Dialogue += letter;
            if (i > 0 && Input.GetKeyDown(KeyCode.E))
            {
                activeDUI.Dialogue = "";
                activeDUI.Dialogue = text;
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
