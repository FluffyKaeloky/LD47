using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerManager : MonoBehaviour
{
    [SerializeField] DoorComputer doorComputerScriptableObject;
    [SerializeField] DoorComputerManager doorComputerManager;
    bool unlock = false;
    public void GetButtonNumber(int number)
    {
        if (number == doorComputerScriptableObject.doorNumber && unlock == false)
        {
            doorComputerManager.OpenComputerDoor(doorComputerScriptableObject.doorNumber);
            unlock = true;
        }
        //else
        //    unlock = false;
    }

    //public bool UnlockDoorComputer()
    //{
    //    return unlock;
    //}
}
