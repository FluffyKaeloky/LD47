using AlmenaraGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Damageable))]
public class ScreenHurtEffect : MonoBehaviour
{
    public Material mat = null;
    public MultiAudioSource heartbeat = null;

    private void Awake()
    {
        Damageable damageable = GetComponent<Damageable>();

        damageable.onHealthChanged.AddListener(UpdateEffects);
        damageable.onDeath.AddListener(() => 
        {
            heartbeat.MasterVolume = 0.0f;
        });
    }

    private void OnApplicationQuit()
    {
        if (mat != null)
            mat.SetFloat("_Fade", 0.0f);
    }

    private void Start()
    {
        heartbeat.MasterVolume = 0.0f;
    }

    private void UpdateEffects(Damageable.HealthChangedEventArgs args)
    {
        float ratio = args.NewHealth / args.MaxHealth;

        mat.SetFloat("_Fade", (1.0f - ratio) * 0.8f);

        heartbeat.MasterVolume = 1.0f - ratio;
    }
}
