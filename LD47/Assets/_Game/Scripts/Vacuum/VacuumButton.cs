using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumButton : MonoBehaviour
{
    [SerializeField] VacuumDoorManager doorToBlock;
    [SerializeField] VacuumDoorManager doorToSpace;
    [SerializeField] GameObject vacuumArea;
    [SerializeField] public float timeVacuum = 6.0f;
    bool vacuumOn = false;

    public void activateVacuum()
    {
        if (!vacuumOn)
        {
            vacuumOn = true;
            vacuumArea.SetActive(true);
            doorToBlock.BlockDoor();
            doorToSpace.DoorToSpace();

        }

    }

    public void deactivateVacuum()
    {
        vacuumOn = false;
        vacuumArea.SetActive(false);
    }
    public bool VacuumOn()
    {
        return vacuumOn;
    }
}
