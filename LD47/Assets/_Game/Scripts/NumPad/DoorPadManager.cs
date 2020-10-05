using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPadManager : MonoBehaviour
{
    [SerializeField] DoorPad DoorPadScriptableObject;
    InteractibleManager interactibleManager;
    //public DisplayPanel displayPanel;

    private void Awake()
    {
        interactibleManager = GetComponent<InteractibleManager>();
    }

    public void OpenDoorPad(string code)
    {
        if(code == DoorPadScriptableObject.CodeNumber)
            interactibleManager.Open();
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //       if (displayPanel.GetDisplay())
    //            interactibleManager.Open();
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //       if (displayPanel.GetDisplay())
    //            interactibleManager.Close();
    //}
}
