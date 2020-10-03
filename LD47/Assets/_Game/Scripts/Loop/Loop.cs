using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Loop", menuName = "Loop")]
public class Loop : ScriptableObject
{
    public new string name = "Loop";
    [TextArea] public string description = "Description";
    public int id = 0;
    public float loopTimer = 60.0f;
   
}
