using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject playerPawn = null;

    public void RespawnPlayer()
    {
        playerPawn.transform.position = spawnPoint.position;
    }
}
