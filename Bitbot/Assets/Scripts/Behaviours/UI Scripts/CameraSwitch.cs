using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    private GameObject cam;
    private PlayerMovement move;
    private bool startTransition = false;
    void Awake()
    {
        cam = transform.GetChild(0).gameObject;
        move = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(startTransition)
        {
            StartCoroutine(DisableMovement());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            cam.SetActive(true);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            cam.SetActive(false);
            startTransition = true;
        }
    }
    IEnumerator DisableMovement()
    {
        Debug.Log("Fuck");
        startTransition = false;
        move.canMove = false;
        yield return new WaitForSecondsRealtime(.05f);
        move.Halt();
        yield return new WaitForSecondsRealtime(.4f);
        move.canMove = true;
        Debug.Log("Fuck 2");
    }
}
