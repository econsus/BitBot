using Cinemachine;
using UnityEngine;

public class CrosshairMovement : MonoBehaviour
{
    private Transform xhair;
    void Start()
    {
        xhair = GetComponent<Transform>();
    }
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

        xhair.transform.position = new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane);

        Debug.Log("MOSPOS" + xhair.transform.position);
    }
}
