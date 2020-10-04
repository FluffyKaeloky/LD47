using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleManager : MonoBehaviour
{
    [SerializeField] Transform openTransform;
    [SerializeField] Transform closeTransform;
    Interactible interactible = null;
    public void Open()
    {
        transform.DOMove(openTransform.position, 1.0f).SetEase(Ease.OutExpo);
        //transform.parent.position = openTransform.position;
    }

    public void Close()
    {
        transform.DOMove(closeTransform.position, 1.0f).SetEase(Ease.OutExpo);
        //transform.parent.position = closeTransform.position;
    }
}
