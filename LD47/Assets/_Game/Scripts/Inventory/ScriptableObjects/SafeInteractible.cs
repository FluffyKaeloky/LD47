using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Safe", menuName = "Inventory System/InteractibleObject/Safe")]
public class SafeInteractible : InteractibleObject
{
    private void Awake()
    {
        type = InteractibleObjectType.Safe;
    }
}
