using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[CreateAssetMenu(fileName = "New Key Object", menuName = "Inventory System/Items/Key")]
public class KeyItem : ItemObject
{
    public InteractibleObjectType openWhat;
    public int AccessLevel = 0;
    private void Awake()
    {
        type = ItemType.Key;
    }
}

