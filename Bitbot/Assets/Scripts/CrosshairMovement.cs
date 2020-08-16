using UnityEngine;

public class CrosshairMovement : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
    void FixedUpdate()
    {
        Vector3 worldMPos = MouseWorldPosition.getMouseWorldPos(0f);
        this.transform.position = new Vector3(worldMPos.x, worldMPos.y, this.transform.position.z);
    }
}
