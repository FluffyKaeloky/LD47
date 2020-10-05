﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorComputerManager : MonoBehaviour
{
    public DoorComputer doorNumber;
    public ComputerManager computer;
    InteractibleManager interactibleManager;



    private void Awake()
    {
        interactibleManager = GetComponent<InteractibleManager>();
    }

    public void OpenComputerDoor()
    {
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