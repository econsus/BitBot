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
}
