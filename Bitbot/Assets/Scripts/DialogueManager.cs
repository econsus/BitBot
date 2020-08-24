using System.Collections;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Dialogue dialogue;

    public GameObject conversation;

    public float waitTime = 0.3f;

    private PlayerMovement move;

    private GameObject chatBubble;

    private Animator anim;

    private DialogueUI dialogueUI;

    private int activeIndex = 0;

    private bool canTalk;

    void Start()
    {
        move = FindObjectOfType<PlayerMovement>();
        chatBubble = GameObject.Find("Chat Bubble");

        anim = chatBubble.GetComponentInChildren<Animator>();
        
        dialogueUI = conversation.GetComponent<DialogueUI>();

        dialogueUI.Speaker = dialogue.character;

        chatBubble.SetActive(false);
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

            StartCoroutine(hideChatBubble(waitTime));
        }
    }

    IEnumerator hideChatBubble(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        chatBubble.SetActive(false);
    }
    void Update()
    {
        if(canTalk && Input.GetKeyDown(KeyCode.E))
        {
            move.halt();
            move.enabled = false;
            next();
        }
    }

    private void next()
    {
        if(activeIndex < dialogue.sentences.Length)
        {
            displaySentence();
            activeIndex += 1;
        }
        else
        {
            dialogueUI.Hide();
            activeIndex = 0;
            move.enabled = true;
        }
    }

    private void displaySentence()
    {
        Sentence line = dialogue.sentences[activeIndex];

        setDialogue(dialogueUI, line.sentence);
    }
    private void setDialogue(DialogueUI activeDUI, string text)
    {
        activeDUI.Dialogue = text;
        activeDUI.Show();
    }
}
