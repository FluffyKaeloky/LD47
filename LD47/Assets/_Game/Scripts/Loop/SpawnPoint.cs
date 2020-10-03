using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class SpawnPoint : MonoBehaviour
{
    [SerializeField] Transform originalCameraPivotPosition;

    //Get initial spawn point position
    private void Awake()
    {
        transform.position = originalCameraPivotPosition.position;
    }

    public Transform GetSpawnPoint()
    {
        return transform;
    }
}
