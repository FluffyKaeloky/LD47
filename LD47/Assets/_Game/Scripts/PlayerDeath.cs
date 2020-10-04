using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Damageable))]
public class PlayerDeath : MonoBehaviour
{
    public UnityEvent onPlayerDeath = new UnityEvent();

    public void Awake()
    {
        Damageable damageable = GetComponent<Damageable>();

        damageable.onDeath.AddListener(() => onPlayerDeath?.Invoke());
    }
}
