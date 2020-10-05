using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class ScreenFade : MonoBehaviour
{
    public Material mat = null;

    public bool playOnStart = true;

    public Color color = Color.black;
    public float duration = 1.0f;

    public UnityEvent onFadeEnd = new UnityEvent();

    public void Start()
    {
        if (playOnStart)
            FadeScreen(true);
    }

    private void OnApplicationQuit()
    {
        mat.SetFloat("_Fade", 0.0f);
    }

    public void FadeScreen(bool state, float? duration = null)
    {
        mat.SetColor("_FadeColor", color);
        mat.DOFloat(state ? 1.0f : 0.0f, "_Fade", duration != null ? duration.Value : this.duration);
    }

    [Button("Fade Now")]
    private void EditorTestFade()
    {
        if (Application.isPlaying)
            FadeScreen(true);
    }
}
