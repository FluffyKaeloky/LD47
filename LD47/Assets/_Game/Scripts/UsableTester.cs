using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Usable))]
public class UsableTester : MonoBehaviour
{
    private Usable usable = null;

    private void Awake()
    {
        usable = GetComponent<Usable>();
    }

    private void Start()
    {
        usable.onHoverEnter.AddListener((args) => Debug.Log("Hover Enter (" + args.Instigator.gameObject.name + ")"));
        usable.onHoverLeave.AddListener((args) => Debug.Log("Hover Leave (" + args.Instigator.gameObject.name + ")"));
        usable.onMouseUp.AddListener((args) => Debug.Log("Mouse Up (" + args.Instigator.gameObject.name + ")"));
        usable.onMouseDown.AddListener((args) => Debug.Log("Mouse Down (" + args.Instigator.gameObject.name + ")"));
        usable.onMouseAltUp.AddListener((args) => Debug.Log("Mouse Alt Up (" + args.Instigator.gameObject.name + ")"));
        usable.onMouseAltDown.AddListener((args) => Debug.Log("Mouse Alt Down (" + args.Instigator.gameObject.name + ")"));
    }
}
