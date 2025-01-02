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
    public GameObject prefab; 

    public Sprite sprite;

    public ItemType type;

    [TextArea(2,5)]
    public string itemDescription;
}
