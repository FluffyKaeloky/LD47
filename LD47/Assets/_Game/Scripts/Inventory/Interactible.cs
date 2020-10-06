using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

public class Interactible : MonoBehaviour
{
   
    public InteractibleObject interactible;
    public ItemObject itemNeed;
    InteractibleManager interactibleManager;
    [SerializeField] public TMP_Text TextDisplay;
    [SerializeField] GameObject redLock;
    [SerializeField] GameObject greenUnlock;
    private void Awake()
    {
        interactibleManager = GetComponent<InteractibleManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            if (itemNeed == other.GetComponent<PlayerInventory>().inventory.GotItem(itemNeed))
            {
                interactibleManager.Open();
                redLock.SetActive(false);
                greenUnlock.SetActive(true);
                TextDisplay.text = "Open";
            }
               
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            if (itemNeed == other.GetComponent<PlayerInventory>().inventory.GotItem(itemNeed))
                interactibleManager.Close();
    }
}
