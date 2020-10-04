using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractibleObjectType
{
    Door,
    Safe,
    Box,
    MotherBoard
}

public class InteractibleObject : ScriptableObject
{
    public GameObject prefab;
    public InteractibleObjectType type;
    [TextArea(15, 20)]
    public string description;

}
