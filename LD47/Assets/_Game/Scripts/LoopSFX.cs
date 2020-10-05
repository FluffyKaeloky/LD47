using AlmenaraGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LoopManagerScript))]
[RequireComponent(typeof(ScreenFade))]
public class LoopSFX : MonoBehaviour
{
    public AudioObject endLoopSFX = null;
    public AudioObject startLoopSFX = null;

    private LoopManagerScript loopManager = null;
    private ScreenFade fader = null;

    private bool loopEndSFXFired = false;

    private void Awake()
    {
        loopManager = GetComponent<LoopManagerScript>();
        fader = GetComponent<ScreenFade>();

        loopManager.onTimerChanged.AddListener(OnTimerChanged);
        loopManager.onLoopStart.AddListener(OnLoopEnd);
    }

    private void OnTimerChanged()
    {
        if (endLoopSFX == null)
            return;

        if (loopEndSFXFired)
            return;

        if (loopManager.loopTimer <= (endLoopSFX.clips[0].length + 1.0f))
        {
            MultiAudioManager.PlayAudioObject(endLoopSFX, transform.position);
            fader.FadeScreen(true, endLoopSFX.clips[0].length);
            loopEndSFXFired = true;
        }
    }

    private void OnLoopEnd()
    {
        if (startLoopSFX == null)
            return;

        MultiAudioManager.PlayAudioObject(startLoopSFX, transform.position);
        fader.FadeScreen(false, 0.5f);

        loopEndSFXFired = false;
    }
}
