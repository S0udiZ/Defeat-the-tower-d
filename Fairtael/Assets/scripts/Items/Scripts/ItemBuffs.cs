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
        public float damageChangeDiv;
    public float stunChange;
    public float firerateChange;
        public float firerateChangeDiv;
    public float rangeChange;
    public float bulletSpeed;

    public float walkspeed;

    public float maxHearts;
    public float hearts;

    public void ChangeStats(float tacuraty, float tdamageChange, float tdamageChangeDiv, float tstunChange, float tfirerateChange, float tfirerateChangeDiv,float trangeChange, float twalkspeed, float tmaxHearts, float thearts, float tBulletSpeed)
    {
        acuraty += tacuraty;
        damageChange += tdamageChange;
            damageChangeDiv /= tdamageChangeDiv;
        stunChange += tstunChange;
        firerateChange += tfirerateChange;
            firerateChangeDiv /= tfirerateChangeDiv;
        rangeChange += trangeChange;
        walkspeed += twalkspeed;
        bulletSpeed += tBulletSpeed;
        playerontroller.ChangeHearts(tmaxHearts,thearts);

    }
}
