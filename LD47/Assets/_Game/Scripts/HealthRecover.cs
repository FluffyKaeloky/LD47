using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Damageable))]
public class HealthRecover : MonoBehaviour
{
    public float recoverTime = 5.0f;
    public float recoverDuration = 0.5f;

    private float timer = 0.0f;

    private Damageable damageable = null;

    private Tween tween = null;

    private void Awake()
    {
        damageable = GetComponent<Damageable>();

        damageable.onDamageTaken.AddListener((args) => 
        {
            timer = recoverTime;

            if (tween != null && DOTween.IsTweening(tween))
                tween.Kill();
            tween = null;
        });
    }

    private void Update()
    {
        timer = Mathf.Max(0.0f, timer - Time.deltaTime);

        if (timer == 0.0f && damageable.Health < damageable.MaxHealth && damageable.Health > 0.0f)
        {
            tween = DOTween.To((value) => { damageable.Health = value; }, damageable.Health, damageable.MaxHealth, recoverDuration)
                .SetEase(Ease.OutCubic);
        }
    }
}
