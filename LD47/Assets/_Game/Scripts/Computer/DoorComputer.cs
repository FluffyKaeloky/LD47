using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Door", menuName = "Computer/Door")]
public class DoorComputer : ScriptableObject
{
    public string DoorName;
    [TextArea(10, 25)] public string description;
    public int doorNumber;
}
