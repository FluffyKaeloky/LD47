using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Door", menuName = "Inventory System/InteractibleObject/Door")]
public class DoorInteractible : InteractibleObject
{
    private void Awake()
    {
        type = InteractibleObjectType.Door;
    }
}
