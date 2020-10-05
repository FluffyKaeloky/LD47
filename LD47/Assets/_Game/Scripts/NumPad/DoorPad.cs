using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Door", menuName = "NumPad/Door")]
public class DoorPad : ScriptableObject
{
    public string DoorName;
    [TextArea(10, 25)] public string description;
    public string CodeNumber;

}
