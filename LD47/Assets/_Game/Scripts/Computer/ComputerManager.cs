using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerManager : MonoBehaviour
{
    [SerializeField] DoorComputer door;
    [SerializeField]DoorComputerManager doorOpen;
    bool unlock = false;
    public void GetButtonNumber(int number)
    {
        if (number == door.doorNumber)
            doorOpen.OpenComputerDoor();
        //unlock = true
        //else
        //    unlock = false;
    }

    //public bool UnlockDoorComputer()
    //{
    //    return unlock;
    //}
}
