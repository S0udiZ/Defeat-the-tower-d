using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/inventory")]
public class InventoryObject : ScriptableObject
{
    public List<Inventoryslot> items = new List<Inventoryslot>();


    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].item == _item) 
            {   
                items[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem) 
        {
            items.Add(new Inventoryslot(_item, _amount));
        }

    }

}

[System.Serializable]
public class Inventoryslot
{
    public ItemObject item;
    public int amount;

    public Inventoryslot(ItemObject _item, int _amount) 
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}