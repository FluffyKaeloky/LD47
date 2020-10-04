using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class ScreenShakerController : MonoBehaviour
{
    public static ScreenShakerController Instance { get; private set; } = null;

    public float defaultShakeAmplitude = 5.0f;

    private CinemachineBasicMultiChannelPerlin perlin = null;

    private Tweener tween = null;

    private void Awake()
    {
        Instance = this;

        perlin = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Shake(float time)
    {
        Shake(time, defaultShakeAmplitude);
    }

    public void Shake(float time, float amplitude)
    {
        StopShake();

        tween = DOTween.To(x => perlin.m_AmplitudeGain = x, amplitude, 0.0f, time);
    }

    public void StopShake()
    {
        if (tween != null && tween.active)
            tween.Kill();
    }
}
