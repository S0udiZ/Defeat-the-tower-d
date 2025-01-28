using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum ItemType
{
    Food,
    Equipment,
    Default
}
public abstract class ItemObject : ScriptableObject
{

    public float damageChange;
    public float stunChange;
    public float firerateChange;
    public float rangeChange;
    public float bulletSpeed;

    public float acuraty;

    public float walkspeed;

    public float maxHearts;
    public float hearts;



    public GameObject prefab; 

    public Sprite sprite;

    public ItemType type;

    [TextArea(2,5)]
    public string itemDescription;
}
