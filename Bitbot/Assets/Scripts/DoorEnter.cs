using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorEnter : MonoBehaviour
{
    private bool inFrontofDoor = false;
    public GameObject symbol;
    [SerializeField] private string sceneToLoad = "Scene";
    void Start()
    {
        symbol.SetActive(false);
    }
    void Update()
    {
        showSymbol();

        if(Input.GetKey(KeyCode.E) && inFrontofDoor)
        {
            loadScene(sceneToLoad);
        }
    }

    private void showSymbol()
    {
        symbol.SetActive(inFrontofDoor);
    }
    private void loadScene(string sceneToLoad)
    {
        SceneManager.LoadSceneAsync(sceneToLoad);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
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

}
