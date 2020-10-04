using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    #region Class Declarations

    [Serializable]
    public class HealthChangedEvent : UnityEvent<HealthChangedEventArgs> { }

    [Serializable]
    public class HealthChangedEventArgs
    {
        public Damageable Sender { get; private set; } = null;

        public float NewHealth { get; private set; } = 0.0f;
        public float MaxHealth { get; private set; } = 0.0f;

        public HealthChangedEventArgs(Damageable sender, float newHealth, float maxHealth)
        {
            Sender = sender;
            NewHealth = newHealth;
            MaxHealth = maxHealth;
        }
    }

    #endregion

    public float Health { get { return health; }
        set
        {
            health = Mathf.Max(value, 0.0f);
            onHealthChanged?.Invoke(new HealthChangedEventArgs(this, health, maxHealth));

            if (health <= 0.0f)
                onDeath?.Invoke();
        }
    }
    [SerializeField]
    private float health = 100.0f;

    public float MaxHealth { get { return maxHealth; }
        set
        {
            maxHealth = value;
            health = Mathf.Min(health, maxHealth);

            onHealthChanged?.Invoke(new HealthChangedEventArgs(this, health, maxHealth));
        }
    }
    [SerializeField]
    private float maxHealth = 100.0f;

    public HealthChangedEvent onHealthChanged = new HealthChangedEvent();
    public UnityEvent onDeath = new UnityEvent();

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }
}
