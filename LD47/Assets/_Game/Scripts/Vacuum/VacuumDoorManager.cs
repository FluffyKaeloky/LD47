using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumDoorManager : MonoBehaviour
{
    [SerializeField] VacuumButton button;
    float timeVacuum;
    InteractibleManager interactibleManager;
    BoxCollider boxCollider;
    bool gotTrigger = false;

    private void Awake()
    {
        interactibleManager = GetComponent<InteractibleManager>();
        boxCollider = GetComponent<BoxCollider>();
        timeVacuum = button.timeVacuum;
    }

    //For Door Vacuum (not To Space)
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !button.VacuumOn() && gameObject.tag != "Vacuum")
        {
            interactibleManager.Open();
            Debug.Log("OnTriggerEnterOpen");
            gotTrigger = true;
        }
                
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !button.VacuumOn() && gameObject.tag != "Vacuum" && gotTrigger)
        {
            interactibleManager.Close();
            Debug.Log("OnTriggerExit Close");
            gotTrigger = false;
        }

    }

    public void DoorToSpace()
    {
        StartCoroutine(OpenDoorToSpace());
        Debug.Log("DoorToSpace");
    }

    public void BlockDoor()
    {
        StartCoroutine(DoorBlock());
        Debug.Log("BlockDoor");
    }

    IEnumerator OpenDoorToSpace()
    {
        interactibleManager.Open();
        yield return new WaitForSeconds(timeVacuum);
        interactibleManager.Close();
    }
    IEnumerator DoorBlock()
    {
        yield return new WaitForSeconds(timeVacuum);
        button.deactivateVacuum();
        Debug.Log("Deactivate Vacuum");
    }
}
