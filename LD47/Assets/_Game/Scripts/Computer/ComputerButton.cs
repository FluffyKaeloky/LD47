using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Button", menuName = "Computer/Button")]
public class ComputerButton : ScriptableObject
{
    public string ButtonName;
    [TextArea(10, 10)] public string description;
    public int number;
}
