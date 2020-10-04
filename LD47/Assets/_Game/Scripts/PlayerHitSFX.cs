using AlmenaraGames;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Damageable))]
[RequireComponent(typeof(MultiAudioSource))]
public class PlayerHitSFX : SerializedMonoBehaviour
{
    public AudioObject sfxFallback = null;
    public Dictionary<Damageable.DamageType, AudioObject> hitSfxs = new Dictionary<Damageable.DamageType, AudioObject>();

    private Damageable damageable = null;
    private MultiAudioSource audioSource = null;

    private void Awake()
    {
        damageable = GetComponent<Damageable>();
        audioSource = GetComponent<MultiAudioSource>();
    }

    private void Start()
    {
        damageable.onDamageTaken.AddListener(OnDamageTaken);
    }

    private void OnDamageTaken(Damageable.DamageTakenEventArgs args)
    {
        AudioObject sfx = sfxFallback;
        if (hitSfxs.ContainsKey(args.DamageType))
            sfx = hitSfxs[args.DamageType];

        audioSource.AudioObject = sfx;
        audioSource.Play();
    }
}
