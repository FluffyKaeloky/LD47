using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Box", menuName = "Inventory System/InteractibleObject/Box")]
public class BoxInteractible : ObjectOpen
{
    public ItemObject needWhat;
    private void Awake()
    {
        type = ObjectOpenType.Box;
    }
}

