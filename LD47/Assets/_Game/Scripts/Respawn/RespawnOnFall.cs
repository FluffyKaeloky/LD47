using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOnFall : MonoBehaviour
{
    [SerializeField] Transform SpawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = SpawnPoint.position;
    }
}
