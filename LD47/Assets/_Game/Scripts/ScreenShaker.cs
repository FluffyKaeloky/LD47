using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaker : MonoBehaviour
{
    public bool playOnStart = false;

    public float duration = 0.5f;
    public float amplitude = 1.0f;

    private void Start()
    {
        if (playOnStart)
            DoShake();
    }

    [Button("Shake Now")]
    public void DoShake()
    {
        if (!Application.isPlaying)
            return;

        ScreenShakerController.Instance.Shake(duration, amplitude);
    }
}
