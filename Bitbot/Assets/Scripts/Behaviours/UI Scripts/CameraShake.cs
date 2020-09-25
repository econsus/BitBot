﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float intensity;
    [SerializeField] private float time;
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
        em.OnGunShotEvent += ShakeCamera;
    }
    private void OnDisable()
    {
        em.OnGunShotEvent -= ShakeCamera;
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
    private void ShakeCamera()
    {
        Debug.Log("Shake");
        CinemachineBasicMultiChannelPerlin basicPerlin = 
            vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        basicPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }
}
