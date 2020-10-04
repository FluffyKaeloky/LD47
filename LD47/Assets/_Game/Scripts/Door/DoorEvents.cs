using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvents : MonoBehaviour
{
    public static DoorEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action onDoorwayTriggerEnter;
    public void DoorwayTriggerEnter()
    {
        if (onDoorwayTriggerEnter != null)
        {
            onDoorwayTriggerEnter();
        }
    }
}
