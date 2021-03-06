﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionKeyOnStay : MonoBehaviour
{
    private bool inFrontofDoor = false;
    public GameObject symbol;
    public Animator transition;

    public Vector2 playerPosition;
    public Vector2Reference playerSpawn;
    [SerializeField] private string sceneToLoad = "Scene";
    void Start()
    {
        symbol.SetActive(false);
    }
    void Update()
    {
        ShowSymbol();

        if (Input.GetKey(KeyCode.W) && inFrontofDoor)
        {
            playerSpawn.Value = playerPosition;
            StartCoroutine(sceneTransition(1f));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            inFrontofDoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            inFrontofDoor = false;
        }
    }

    private void ShowSymbol()
    {
        symbol.SetActive(inFrontofDoor);
    }
    IEnumerator sceneTransition(float waitTime)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(waitTime);
        LoadScene(sceneToLoad);
    }
    private void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadSceneAsync(sceneToLoad);
    }


}
