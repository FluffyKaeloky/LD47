using AlmenaraGames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PooledSFXPlayer : MonoBehaviour
{
    public AudioObject audioObject = null;

    public void Play()
    {
        MultiAudioManager.PlayAudioObject(audioObject, transform.position);
    }
}
