using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerButtonManager : MonoBehaviour
{
    [SerializeField] ComputerButton buttonScriptableObject;
    [SerializeField] ComputerManager computer;
    public void ButtonPress()
    {
        computer.GetButtonNumber(buttonScriptableObject.number);
    }
}
