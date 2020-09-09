using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartAction : MonoBehaviour
{

    public Button button;
    public void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadSceneAsync(sceneToLoad);
        Debug.Log("uwu");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Start");
    }
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
