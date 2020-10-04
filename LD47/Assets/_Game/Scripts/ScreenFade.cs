using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class ScreenFade : MonoBehaviour
{
    public bool playOnStart = true;

    public Color color = Color.black;

    public UnityEvent onFadeEnd = new UnityEvent();

    private Tween tween = null;

    public void Start()
    {
        if (playOnStart)
            FadeScreen(true);
    }

    public void FadeScreen(bool state)
    {

    }
}
