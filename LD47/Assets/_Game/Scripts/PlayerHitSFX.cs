using AlmenaraGames;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Damageable))]
public class PlayerHitSFX : SerializedMonoBehaviour
{
    public AudioObject sfxFallback = null;
    public Dictionary<Damageable.DamageType, AudioObject> hitSfxs = new Dictionary<Damageable.DamageType, AudioObject>();

    private Damageable damageable = null;

    public AudioObject deathSfx = null;

    private void Awake()
    {
        damageable = GetComponent<Damageable>();
    }

    private void Start()
    {
        damageable.onDamageTaken.AddListener(OnDamageTaken);
        damageable.onDeath.AddListener(() => 
        {
            MultiAudioManager.PlayAudioObject(deathSfx, transform.position);
        });
    }

    private void OnDamageTaken(Damageable.DamageTakenEventArgs args)
    {
        AudioObject sfx = sfxFallback;
        if (hitSfxs.ContainsKey(args.DamageType))
            sfx = hitSfxs[args.DamageType];

        MultiAudioManager.PlayAudioObject(sfx, transform.position);
    }
}
