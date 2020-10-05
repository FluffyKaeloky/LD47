using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    InteractibleManager interactibleManager;
    private void Awake()
    {
        interactibleManager = GetComponent<InteractibleManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            interactibleManager.Open();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            interactibleManager.Close();
    }
}
