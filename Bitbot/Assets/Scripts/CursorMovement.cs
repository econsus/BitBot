using UnityEngine;
public class CursorMovement : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
    void FixedUpdate()
    {
        Vector3 worldMPos = MousePosition.getMouseWorldPos(0f);
        this.transform.position = new Vector3(worldMPos.x, worldMPos.y, this.transform.position.z);
        //this.transform.position = Vector3.Lerp(this.transform.position, worldMPos, 6f);
    }
}
