using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[CreateAssetMenu(fileName = "New Key Object", menuName = "Inventory System/Items/Key")]
public class KeyObject : ItemObject
{
    public ObjectOpenType openWhat;
    public int AccessLevel = 0;
    private void Awake()
    {
        type = ItemType.Key;
    }
}

