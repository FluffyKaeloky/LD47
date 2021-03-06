﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerInput))]
public class Picker : MonoBehaviour
{
    [Serializable]
    public class UnityEventPickable : UnityEvent<Pickable> { }
    public UnityEventPickable onPickup = new UnityEventPickable();

    public FixedJoint pickableHandlerJoint = null;

    public float throwForce = 10.0f;

    public float forceDropForce = 200.0f;

    public Pickable CurrentPickable { get; private set; } = null;
    private Vector3 oldPickablePosition = Vector3.zero;

    private PlayerInput playerInput = null;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (pickableHandlerJoint.currentForce.magnitude > forceDropForce)
            Drop();
    }

    public void Pick(Pickable pickable)
    {
        if (CurrentPickable != null)
            return;

        pickableHandlerJoint.transform.position = pickable.transform.position;
        pickableHandlerJoint.connectedBody = pickable.Rigidbody;
        pickableHandlerJoint.autoConfigureConnectedAnchor = false;
        pickableHandlerJoint.connectedAnchor = Vector3.zero;
        CurrentPickable = pickable;

        oldPickablePosition = CurrentPickable.transform.position;

        onPickup.Invoke(pickable);
    }

    public void Drop()
    {
        if (CurrentPickable == null)
            return;

        pickableHandlerJoint.connectedBody = null;

        Vector3 delta = CurrentPickable.transform.position - oldPickablePosition;
        CurrentPickable.Rigidbody.velocity = delta / Time.fixedDeltaTime;
        if (CurrentPickable.Rigidbody.velocity.magnitude > throwForce)
            CurrentPickable.Rigidbody.velocity = CurrentPickable.Rigidbody.velocity.normalized * throwForce;

        CurrentPickable = null;
    }

    public void Throw()
    {
        pickableHandlerJoint.connectedBody = null;
        CurrentPickable.Rigidbody.AddForce(playerInput.camera.transform.forward * throwForce, ForceMode.Impulse);
        CurrentPickable = null;
    }

    private void FixedUpdate()
    {
        if (CurrentPickable != null)
            oldPickablePosition = CurrentPickable.transform.position;
        else
            oldPickablePosition = Vector3.zero;
    }
}
