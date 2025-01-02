using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Default Object", menuName ="Inventory/Objects/Default")]
public class DefaultObject : ItemObject
{
    //add stats here

    public float damageChange;
    public float firerateChange;
    public float rangeChange;

    public float walkspeed;


    public void Awake()
    {
        type = ItemType.Default;
    }
}
