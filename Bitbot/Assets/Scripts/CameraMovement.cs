using Cinemachine;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Damping Time")]
    
    public float dampingTIme = 1f;

    private float maxSpeed;

    private PlayerMovement move;
    private CinemachineVirtualCamera vcam;
    void Start()
    {
        move = FindObjectOfType<PlayerMovement>();
        vcam = GetComponent<CinemachineVirtualCamera>();
    }
    void LateUpdate()
    {
        flipScreenX(move.facingRight);
    }

    private void flipScreenX(bool facingRight)
    {
        float flipLeft = Mathf.SmoothDamp(0.88f, 0.18f,ref maxSpeed, dampingTIme);
        float flipRight = Mathf.SmoothDamp(0.18f, 0.88f, ref maxSpeed, dampingTIme);

        if (!move.facingRight)
        {
            vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = flipLeft;
        }
        else
        {

            vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = flipRight;
        }
    }
}
