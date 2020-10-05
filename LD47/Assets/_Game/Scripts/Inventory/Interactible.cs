using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public InteractibleObject interactible;
    public ItemObject itemNeed;
    InteractibleManager interactibleManager;
    private void Awake()
    {
        interactibleManager = GetComponent<InteractibleManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            if (itemNeed == other.GetComponent<PlayerInventory>().inventory.GotItem(itemNeed))
                interactibleManager.Open();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            if (itemNeed == other.GetComponent<PlayerInventory>().inventory.GotItem(itemNeed))
                interactibleManager.Close();
    }
}
