using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Default Object", menuName ="Inventory/Objects/Default")]
public class DefaultObject : ItemObject
{
    //add stats here

    public void Awake()
    {
        type = ItemType.Default;
    }
}
