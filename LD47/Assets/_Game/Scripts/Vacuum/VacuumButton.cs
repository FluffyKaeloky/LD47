using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumButton : MonoBehaviour
{
    [SerializeField] VacuumDoorManager doorToBlock;
    [SerializeField] VacuumDoorManager doorToSpace;
    [SerializeField] public float timeVacuum = 6.0f;
    bool vacuumOn = false;

    public void activateVacuum()
    {
        if (!vacuumOn)
        {
            vacuumOn = true;
            doorToBlock.BlockDoor();
            doorToSpace.DoorToSpace();
        }

    }

    public void deactivateVacuum()
    {
        vacuumOn = false;
    }
    public bool VacuumOn()
    {
        return vacuumOn;
    }
}
