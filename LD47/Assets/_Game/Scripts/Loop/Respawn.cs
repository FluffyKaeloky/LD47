using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] Transform spawnPoint = null; //insert original camera transform position
    [SerializeField] GameObject playerPawn;
    public void RespawnPlayer()
    {
        playerPawn.transform.position = spawnPoint.position;
    }
}
