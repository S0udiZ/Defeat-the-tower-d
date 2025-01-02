using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Food Object", menuName ="Inventory/Objects/Food")]
public class FoodObject : ItemObject
{
    //add stats here

    public void Awake()
    {
        type = ItemType.Food;
    }
}
