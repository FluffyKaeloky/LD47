using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(VisualEffect))]
public class VFXPlayRepeat : MonoBehaviour
{
    public float minDelay = 1.0f;
    public float maxDelay = 2.0f;

    private VisualEffect vfx = null;

    private void Awake()
    {
        vfx = GetComponent<VisualEffect>();
    }

    private async void Start()
    {
        while (true)
        {
            if (this == null) return;
            vfx.Play();

            await new WaitForSeconds(Random.Range(minDelay, maxDelay));
        }
    }
}
