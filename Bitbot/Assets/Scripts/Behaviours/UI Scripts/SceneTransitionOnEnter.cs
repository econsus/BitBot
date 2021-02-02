using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionOnEnter : MonoBehaviour
{
    public Animator transition;

    public Vector2 playerPosition;
    public VectorValue playerPositionStorage;
    [SerializeField] private string sceneToLoad = "Scene";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            playerPositionStorage.initialValue = playerPosition;
            StartCoroutine(SceneTransition(1f));
        }
    }

    private void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadSceneAsync(sceneToLoad);
    }

    IEnumerator SceneTransition(float waitTime)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(waitTime);
        LoadScene(sceneToLoad);
    }
}
