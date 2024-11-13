using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum ItemType
{
    consumable,
    weapon,
    other //base type for non equpable items, and non consumable (ANYTHING else basically)

}
[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 1)]
public class ItemPrefab : ScriptableObject
{
    /*
     --------------------NOTE til TOKE--------------------
    Hvis du vil tilfoeje items saa skal du bare hoejre klikke ude i assets og vaelge det alleroeverste IKKE kopi dette........ plz:0

    */


    //cosmetic
    public string itemName;
    public Sprite sprite;
    [TextArea(2,20)] //makes it more easy too read in the editor
    public string description;
    public ItemType itemType;

    //stats (dont change it here)
    public float defence = 0;
    public float hearts = 0;
    public float tempHealth = 0;
    public float walkspeed = 0;
    public float damage = 0;
    public float fireRate = 0;
    public float range = 0;
    public float bulletSpeed = 0;




}
