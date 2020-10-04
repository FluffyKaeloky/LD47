using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Door", menuName = "Inventory System/InteractibleObject/Door")]
public class DoorInteractible : ObjectOpen
{
    public ItemObject needWhat;
    public int accessLevel = 1;
    private void Awake()
    {
        type = ObjectOpenType.Door;
    }
}
