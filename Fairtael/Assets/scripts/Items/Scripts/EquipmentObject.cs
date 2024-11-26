using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory/Objects/Equipment")]
public class EquipmentObject : ItemObject
{
    //add stats here

    public void Awake()
    {
        type = ItemType.Equipment;
    }
}
