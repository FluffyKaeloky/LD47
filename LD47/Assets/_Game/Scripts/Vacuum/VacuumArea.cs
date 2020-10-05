using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VacuumArea : MonoBehaviour
{
    [SerializeField] Transform toSpace;
    [SerializeField] VacuumButton vacuum;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8 && vacuum.VacuumOn())
            other.transform.DOMove(toSpace.position, 6.0f).SetEase(Ease.OutExpo);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8 && vacuum.VacuumOn())
            Destroy(other);
    }
}
