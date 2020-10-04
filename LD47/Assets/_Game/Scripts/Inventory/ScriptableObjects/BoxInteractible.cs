using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Box", menuName = "Inventory System/InteractibleObject/Box")]
public class BoxInteractible : InteractibleObject
{
    private void Awake()
    {
        type = InteractibleObjectType.Box;
    }
}

