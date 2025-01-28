using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemBuffs : MonoBehaviour
{
    playercontroller playerontroller;
    private void Start()
    {
        playerontroller = GameObject.FindWithTag("Player").gameObject.GetComponent<playercontroller>();
    }


    public float acuraty;  
    public float damageChange;
    public float stunChange;
    public float firerateChange;
    public float rangeChange;
    public float bulletSpeed;

    public float walkspeed;

    public float maxHearts;
    public float hearts;

    public void ChangeStats(float tacuraty,float tdamageChange,float tstunChange, float tfirerateChange, float trangeChange, float twalkspeed, float tmaxHearts, float thearts, float tBulletSpeed)
    {
        acuraty += tacuraty;
        damageChange += tdamageChange;
        stunChange += tstunChange;
        firerateChange += tfirerateChange;
        rangeChange += trangeChange;
        walkspeed += twalkspeed;
        bulletSpeed += tBulletSpeed;
        playerontroller.ChangeHearts(tmaxHearts,thearts);

    }
}
