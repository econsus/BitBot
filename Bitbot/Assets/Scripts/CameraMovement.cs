using Cinemachine;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Damping Time")]
    
    public float dampingTIme = 1f;

    private CinemachineVirtualCamera vcam;
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }
    void Update()
    {

    }

    private void flipScreenX(bool facingRight)
    {
        
    }
}
