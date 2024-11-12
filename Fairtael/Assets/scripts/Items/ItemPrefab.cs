using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public int description;

    //stats (its okay to leave them null)
    public float defence;
    public float health;
    public float tempHealth;
    public float walkspeed;
    public float damage;
    public float fireRate;
    public float range;
    public float bulletSpeed;




}
