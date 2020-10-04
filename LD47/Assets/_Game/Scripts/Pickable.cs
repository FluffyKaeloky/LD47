using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Usable))]
[RequireComponent(typeof(Rigidbody))]
public class Pickable : MonoBehaviour
{
    public Rigidbody Rigidbody { get; private set; } = null;

    public UnityEvent onPickup = new UnityEvent();
    public UnityEvent onDrop = new UnityEvent();
    public UnityEvent onThrow = new UnityEvent();

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();

        Usable usable = GetComponent<Usable>();

        usable.onMouseDown.AddListener(Pickup);
        usable.onMouseUp.AddListener(Drop);
        usable.onMouseAltDown.AddListener(Throw);
    }

    public void Pickup(Usable.OnUsableEventArgs args)
    {
        Picker picker = args.Instigator.GetComponent<Picker>();

        if (picker != null)
        {
            picker.Pick(this);
            onPickup?.Invoke();
        }
    }

    public void Drop(Usable.OnUsableEventArgs args)
    {
        Picker picker = args.Instigator.GetComponent<Picker>();

        if (picker != null)
        {
            picker.Drop();
            onDrop?.Invoke();
        }
    }

    public void Throw(Usable.OnUsableEventArgs args)
    {
        Picker picker = args.Instigator.GetComponent<Picker>();

        if (picker != null)
        {
            picker.Throw();
            onThrow?.Invoke();
        }
    }
}
