using Cinemachine;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header ("Lerp Value")]
    public float lerpValue = 5f;

    private PlayerMovement move;
    private CinemachineVirtualCamera vcam;
    void Start()
    {
        move = FindObjectOfType<PlayerMovement>();
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        flipScreenX(move.facingRight);
    }

    private void flipScreenX(bool facingRight)
    {
        float lerpLeft = Mathf.Lerp(0.15f, 0.75f, lerpValue);
        float lerpRight = Mathf.Lerp(0.75f, 0.15f, lerpValue);
        if (move.facingRight)
        {
            vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = Mathf.Lerp(0.75f, 0.15f, lerpValue);
        }
        if (!move.facingRight)
        {
            vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = Mathf.Lerp(0.15f, 0.75f, lerpValue);
        }
    }
}
