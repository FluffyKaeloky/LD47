using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(PlayerMovements))]
[RequireComponent(typeof(Damageable))]
public class SlowdownOnHit : MonoBehaviour
{
    private PlayerMovements playerMovements = null;

    private void Awake()
    {
        playerMovements = GetComponent<PlayerMovements>();

        GetComponent<Damageable>().onDamageTaken.AddListener((args) => 
        {
            playerMovements.moveSpeedMultiplier = Mathf.Max(playerMovements.moveSpeedMultiplier - 0.25f, 0.2f);
        });
    }
}
