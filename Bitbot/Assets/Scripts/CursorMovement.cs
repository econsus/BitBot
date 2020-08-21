using UnityEngine;
public class CursorMovement : MonoBehaviour
{
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
    void FixedUpdate()
    {
        moveToCursor();
    }

    private void moveToCursor()
    {
        Vector3 worldMPos = MousePosition.getMouseWorldPos(0f, cam);
        this.transform.position = new Vector3(worldMPos.x, worldMPos.y, this.transform.position.z);
        //this.transform.position = Vector3.Lerp(this.transform.position, worldMPos, 6f);
    }
}
