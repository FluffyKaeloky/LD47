using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Usable))]
[RequireComponent(typeof(Rigidbody))]
public class Pickable : MonoBehaviour
{
    public Rigidbody Rigidbody { get; private set; } = null;

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
            picker.Pick(this);
    }

    public void Drop(Usable.OnUsableEventArgs args)
    {
        Picker picker = args.Instigator.GetComponent<Picker>();

        if (picker != null)
            picker.Drop();
    }

    public void Throw(Usable.OnUsableEventArgs args)
    {
        Picker picker = args.Instigator.GetComponent<Picker>();

        if (picker != null)
            picker.Throw();
    }
}
