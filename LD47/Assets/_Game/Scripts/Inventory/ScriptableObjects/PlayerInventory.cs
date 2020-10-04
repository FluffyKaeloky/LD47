using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Picker playerPicker;
    public InventorySystem inventory;

    public void PlayerPicker_onPick(Pickable pickable)
    {
        Item item = pickable.GetComponent<Item>();
        if(item == null)
            return;
        
        inventory.AddItem(item.item, 1);
        Destroy(item.gameObject);
    }

    private void OnEnable()
    {
        playerPicker.onPickup.AddListener(PlayerPicker_onPick);
    }

    private void OnDisable()
    {
        playerPicker.onPickup.RemoveListener(PlayerPicker_onPick);
    }
    //Reset Inventory on Quit
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
