using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;

        //Have the item already
        for(int i = 0; i < Container.Count; i++)
        {
            if(Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }

        //Have Not the item
        if (!hasItem)
        {
            Container.Add(new InventorySlot(_item, _amount));
        }
    }

    public bool GetItem(ItemObject _item)
    {
        bool hasItemRequired = false;

        for(int j = 0; j < Container.Count; j++)
        {
            if (Container[j].item == _item)
            {
                hasItemRequired = true;
                break;
            }
        }

        if (hasItemRequired)
        {
            return true;
        }

        return false;
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = 1;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}
