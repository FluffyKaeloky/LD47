using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    [TextArea] public string description = "Description";
    [SerializeField] float loopTimer = 60.0f;

    public AudioClip startClip = null;

    public float GetLoopTimer()
    {
        return loopTimer;
    }
}
