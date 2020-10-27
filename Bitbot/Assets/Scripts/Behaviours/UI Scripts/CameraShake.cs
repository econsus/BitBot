using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private float shakeTimer;

    private CinemachineVirtualCamera vcam;
    private EventManager em;
    void Awake()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        
        em = FindObjectOfType<EventManager>();
    }
    private void OnEnable()
    {
        em.OnShakeCameraEvent += ShakeCamera;
    }
    private void OnDisable()
    {
        em.OnShakeCameraEvent -= ShakeCamera;
    }

    private void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
        }
        if(shakeTimer <= 0f)
        {
            CinemachineBasicMultiChannelPerlin basicPerlin = 
                vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            basicPerlin.m_AmplitudeGain = 0f;
        }
    }
    private void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin basicPerlin = 
            vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        basicPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }
}
