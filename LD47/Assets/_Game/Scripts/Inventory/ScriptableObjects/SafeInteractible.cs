using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Safe", menuName = "Inventory System/InteractibleObject/Safe")]
public class SafeInteractible : ObjectOpen
{
    public ItemObject needWhat;
    private void Awake()
    {
        type = ObjectOpenType.Safe;
    }
}
