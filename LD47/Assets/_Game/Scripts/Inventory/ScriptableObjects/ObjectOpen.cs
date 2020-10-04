using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectOpenType
{
    Door,
    Safe,
    Box,
    MotherBoard
}

public class ObjectOpen : ScriptableObject
{
    public GameObject prefab;
    public ObjectOpenType type;
    [TextArea(15, 20)]
    public string description;

}
