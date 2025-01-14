using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/inventory")]
public class InventoryObject : ScriptableObject
{
    public ItemBuffs Buffs;
    public List<Inventoryslot> items = new List<Inventoryslot>();


    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].item == _item) 
            {
                Debug.LogWarning("so not sigma");
                Debug.LogWarning("acuraty   " + items[i].item.acuraty);
                items[i].AddAmount(_amount);
                Buffs.ChangeStats(items[i].item.acuraty, items[i].item.damageChange, items[i].item.firerateChange, items[i].item.rangeChange,  items[i].item.walkspeed, items[i].item.maxHearts, items[i].item.hearts);
                Debug.LogWarning("acuraty    "+items[i].item.acuraty);
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