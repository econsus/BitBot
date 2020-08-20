using UnityEngine;

public class DoorEnter : MonoBehaviour
{
    private bool inFrontofDoor = false;
    [SerializeField] private GameObject symbol;
    void Start()
    {
        symbol.SetActive(false);
    }
    void Update()
    {
        showSymbol();

        if(Input.GetKey(KeyCode.E) && inFrontofDoor)
        {
            Debug.Log("ENTERED DOOR");
        }
    }

    private void showSymbol()
    {
        symbol.SetActive(inFrontofDoor);
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
