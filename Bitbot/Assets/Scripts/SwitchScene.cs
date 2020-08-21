using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public Animator transition;
    [SerializeField] private string sceneToLoad = "Scene";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            StartCoroutine(sceneTransition(1f));
        }
    }

    private void loadScene(string sceneToLoad)
    {
        SceneManager.LoadSceneAsync(sceneToLoad);
    }

    IEnumerator sceneTransition(float waitTime)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(waitTime);
        loadScene(sceneToLoad);
    }
}
