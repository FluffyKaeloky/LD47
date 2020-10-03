using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopGameObject : MonoBehaviour
{
    [TextArea] public string description = "Description";
    [SerializeField] float loopTimer = 60.0f;
}
