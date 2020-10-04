using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MotherBoard", menuName = "Inventory System/InteractibleObject/MotherBoard")]
public class MotherBoardInteractible : ObjectOpen
{
    public ItemObject needWhat;
    private void Awake()
    {
        type = ObjectOpenType.MotherBoard;
    }
}
