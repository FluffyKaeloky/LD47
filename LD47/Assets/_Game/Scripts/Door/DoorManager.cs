﻿using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] Transform openTransform;
    [SerializeField] Transform closeTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            OpenDoor();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            CloseDoor();
    }

    public void OpenDoor()
    {
        transform.DOMove(openTransform.position, 1.0f).SetEase(Ease.OutExpo);
        //transform.parent.position = openTransform.position;
    }

    public void CloseDoor()
    {
        transform.DOMove(closeTransform.position, 1.0f).SetEase(Ease.OutExpo);
        //transform.parent.position = closeTransform.position;
    }
}
