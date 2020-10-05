using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorComputerManager : MonoBehaviour
{
    [SerializeField] DoorComputer doorComputerScriptableObject;
    InteractibleManager interactibleManager;

    private void Awake()
    {
        interactibleManager = GetComponent<InteractibleManager>();
    }

    public void OpenComputerDoor(int number)
    {
        if(doorComputerScriptableObject.doorNumber == number)
            interactibleManager.Open();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //        if (computer.UnlockDoorComputer())
    //            interactibleManager.Open();
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //        if (computer.UnlockDoorComputer())
    //            interactibleManager.Close();
    //}
}
