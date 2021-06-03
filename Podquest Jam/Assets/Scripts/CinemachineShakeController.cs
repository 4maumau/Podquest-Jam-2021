using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShakeController : MonoBehaviour
{
    public static CinemachineShakeController instance;
    
    private CinemachineVirtualCamera vCam;
    private CinemachineBasicMultiChannelPerlin perlinChannel;

    private float startingIntensity;
    private float shakeTimer;
    private float shakeTimerTotal;

    private void Awake()
    {
        instance = this;

        vCam = GetComponent<CinemachineVirtualCamera>();
        perlinChannel = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ShakeCamera(5f, 0.3f);
        }
        
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            
            perlinChannel.m_AmplitudeGain = 
                Mathf.Lerp(startingIntensity, 0f, 1 - (shakeTimer / shakeTimerTotal));
        }
    }

    public void ShakeCamera(float intensity, float time)
    {
        perlinChannel.m_AmplitudeGain = intensity;

        startingIntensity = intensity;
        shakeTimerTotal = time;
        shakeTimer = time;
    }

}
