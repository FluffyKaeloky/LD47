using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    public float maxVelocity = 1.0f;

    public float strength = 0.25f;
    public float frequency = 1.0f;

    public Transform target = null;

    private Vector3 oldPos = Vector3.zero;

    private Vector3 baseTargetLocalPosition = Vector3.zero;

    private float t = 0.0f;

    private void Start()
    {
        oldPos = transform.position;
        baseTargetLocalPosition = target.localPosition;
    }

    private void FixedUpdate()
    {
        Vector3 newPos = transform.position;
        float velocity = Vector3.ProjectOnPlane((newPos - oldPos), Vector3.up).magnitude;

        t += (velocity / maxVelocity) * frequency;
        target.localPosition = baseTargetLocalPosition + Vector3.up * Mathf.Sin(t) * strength;

        oldPos = newPos;
    }
}
