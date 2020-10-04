using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "New DoorPad", menuName = "NumericNumPad/DoorPad")]
public class DoorPadManager : MonoBehaviour
{
    public DoorPad door;
    DisplayPanel displayPanel;
    int num;
    InteractibleManager interactibleManager;

    private void Awake()
    {
        interactibleManager = GetComponent<InteractibleManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            if (displayPanel.DoorUnlock())
                interactibleManager.Open();

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            if (displayPanel.DoorUnlock())
                interactibleManager.Close();

    }
}
