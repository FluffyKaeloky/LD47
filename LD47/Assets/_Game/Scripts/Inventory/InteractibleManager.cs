using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleManager : MonoBehaviour
{

    [Header("Direction of OpenClose")]
    [SerializeField] public bool UpDown = false;
    [SerializeField] public bool DownUp = false;
    [SerializeField] public bool LeftRight = false;
    [SerializeField] public bool RightLeft = false;
    public float animationTime = 0.6f;
    Vector3 originalPos;

    Vector3 dimension;
    PooledSFXPlayer sfx;

    private void Awake()
    {
        sfx = GetComponent<PooledSFXPlayer>();
        dimension = GetComponentInChildren<Renderer>().bounds.size / 2;
        originalPos = transform.position;
    }
    public void Open()
    {
        if (UpDown)
             transform.DOMove(new Vector3(transform.position.x, transform.position.y + (dimension.y*2), transform.position.z), animationTime).SetEase(Ease.OutExpo);
        else if (DownUp)
            transform.DOMove(new Vector3(transform.position.x, transform.position.y - dimension.y, transform.position.z), animationTime).SetEase(Ease.OutExpo);
        else if (LeftRight)
            transform.DOMove(new Vector3(transform.position.x - dimension.y, transform.position.y, transform.position.z), animationTime).SetEase(Ease.OutExpo);
        else if (RightLeft)
            transform.DOMove(new Vector3(transform.position.x + dimension.y, transform.position.y, transform.position.z), animationTime).SetEase(Ease.OutExpo);
        else
            transform.DOMove(new Vector3(transform.position.x, transform.position.y + dimension.y, transform.position.z), animationTime).SetEase(Ease.OutExpo);
        sfx.Play();
    }

    public void Close()
    {
        if (UpDown)
            transform.DOMove(originalPos, animationTime).SetEase(Ease.OutExpo);
        else if (DownUp)
            transform.DOMove(originalPos, animationTime).SetEase(Ease.OutExpo);
        else if (LeftRight)
            transform.DOMove(originalPos, animationTime).SetEase(Ease.OutExpo);
        else if (RightLeft)
            transform.DOMove(originalPos, animationTime).SetEase(Ease.OutExpo);
        else
            transform.DOMove(originalPos, animationTime).SetEase(Ease.OutExpo);
        sfx.Play();
    }

}
