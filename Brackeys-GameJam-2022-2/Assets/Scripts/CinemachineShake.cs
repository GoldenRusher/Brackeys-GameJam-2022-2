using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }

    private CinemachineVirtualCamera Cvc;

    float ShakeTimerTotal;
    float shakeTimer;
    float startingIntensity;

    void Start()
    {
        Instance = this;
        Cvc = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float Intensity, float timer) 
    {
        CinemachineBasicMultiChannelPerlin noise = Cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        noise.m_AmplitudeGain = Intensity;

        startingIntensity = Intensity;
        shakeTimer = timer;
        ShakeTimerTotal = timer;
    }


    void Update()
    {
        if(shakeTimer > 0) 
        {
            shakeTimer -= Time.deltaTime;

            CinemachineBasicMultiChannelPerlin noise = Cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            noise.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0, (1 - (shakeTimer / ShakeTimerTotal)));
        }
    }
}
