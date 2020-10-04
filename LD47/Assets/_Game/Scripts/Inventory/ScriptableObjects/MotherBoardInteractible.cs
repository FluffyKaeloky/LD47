using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MotherBoard", menuName = "Inventory System/InteractibleObject/MotherBoard")]
public class MotherBoardInteractible : InteractibleObject
{
    private void Awake()
    {
        type = InteractibleObjectType.MotherBoard;
    }
}
