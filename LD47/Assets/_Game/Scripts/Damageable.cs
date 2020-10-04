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

    [Serializable]
    public class DamageTakenEvent : UnityEvent<DamageTakenEventArgs> { }

    [Serializable]
    public class DamageTakenEventArgs
    {
        public Damageable Sender { get; set; } = null;

        public Transform Instigator { get; set; } = null;

        public float Damage { get; set; } = 0.0f;
        public DamageType DamageType { get; set; } = DamageType.Misc;
    }

    public enum DamageType
    {
        Misc,
        Fire,
        Bullet
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
    public DamageTakenEvent onDamageTaken = new DamageTakenEvent();
    public UnityEvent onDeath = new UnityEvent();

    public bool invincible = false;

    public void TakeDamage(float damage, Transform instigator, DamageType damageType)
    {
        if (invincible)
            return;

        Health -= damage;

        onDamageTaken?.Invoke(new DamageTakenEventArgs()
        {
            Damage = damage,
            DamageType = damageType,
            Instigator = instigator,
            Sender = this
        });
    }
}
