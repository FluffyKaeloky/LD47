using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DoorPad", menuName = "NumPad/Door")]
public class DoorPad : ScriptableObject
{
    public string name;
    [TextArea(10,25)] public string description;
    public int number;
}
