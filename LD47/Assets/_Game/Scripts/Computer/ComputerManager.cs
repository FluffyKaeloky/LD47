using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerManager : MonoBehaviour
{
    [SerializeField] DoorComputer door;
    bool unlock = false;
    public void GetButtonNumber(int number)
    {
        if (number == door.doorNumber)
            unlock = true;
        else
            unlock = false;
    }

    public bool UnlockDoorComputer()
    {
        return unlock;
    }
}
