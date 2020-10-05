using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumpadPress : MonoBehaviour
{
    public KeyPad keyPad;
    [SerializeField] DisplayPanel display;
    public void GetInput()
    {
        display.DisplayNumber(keyPad.num);
    }
}
