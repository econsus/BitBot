using UnityEngine;

public class CrosshairMovement : MonoBehaviour
{
    [Header("Deadzone")]
    public float z = 6f;

    private Transform xhair;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        xhair = GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        Vector3 screenMPos = Input.mousePosition;
        Vector3 worldMPos = Camera.main.ScreenToWorldPoint(new Vector3(screenMPos.x, screenMPos.y, z));
        xhair.position = new Vector3(worldMPos.x, worldMPos.y, xhair.position.z);
        Debug.Log("MPOS: " + xhair.position);
    }
}
