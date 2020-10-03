using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerInput))]
public class Picker : MonoBehaviour
{
    public FixedJoint pickableHandlerJoint = null;

    public float throwForce = 10.0f;

    public Pickable CurrentPickable { get; private set; } = null;
    private Vector3 oldPickablePosition = Vector3.zero;

    private PlayerInput playerInput = null;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
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
    }

    public void Drop()
    {
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
