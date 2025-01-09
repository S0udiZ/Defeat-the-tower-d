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


    public float acuraty;  //ass
    public float damageChange;
    public float firerateChange;
    public float rangeChange;

    public float walkspeed;

    public float maxHearts;
    public float hearts;

    public void ChangeStats(float tacuraty,float tdamageChange, float tfirerateChange, float trangeChange, float twalkspeed, float tmaxHearts, float thearts)
    {
        acuraty += tacuraty;
        damageChange += tdamageChange;
        firerateChange += tfirerateChange;
        rangeChange += trangeChange;
        walkspeed += twalkspeed;
        playerontroller.ChangeHearts(tmaxHearts,thearts);

    }
}
