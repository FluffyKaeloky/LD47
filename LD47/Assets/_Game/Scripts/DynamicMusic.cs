using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DynamicMusic : MonoBehaviour {

    public float item_proximity = 0;
    public float player_health = 1;

    public Damageable playerDamageable = null;

    [SerializeField] private AudioMixer audio_mixer;

    public void Start() {
        playerDamageable.onHealthChanged.AddListener((args) => UpdatePlayerHealth(args.NewHealth / args.MaxHealth));

        UpdateAudioSettings();
    }

    public void UpdatePlayerHealth(float player_health) {
        this.player_health = player_health;
        UpdateAudioSettings();
    }

    public void UpdateItemProximity(float item_proximity) {
        this.item_proximity = item_proximity;
        UpdateAudioSettings();
    }

    public void UpdateAudioSettings() {
        audio_mixer.SetFloat("FrequencyGain", player_health);
        float volume_value = -Mathf.Abs((1 - item_proximity)) * 80;
        audio_mixer.SetFloat("BGM_EXTRAVolume", volume_value);
    }
}