using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerButtonManager : MonoBehaviour
{
    [SerializeField] ComputerButton button;
    [SerializeField] ComputerManager computer;
    public void ButtonPress()
    {
        computer.GetButtonNumber(button.number);
    }
}
