using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybase : MonoBehaviour
{


    //this script is gonna be used as a base for future enemies, its gonna have the basics like taking damage and letting 
    //you set health, speed, etc, im still not quite sure if were making the enemies follow the player or move around in specific
    //patterns but ill leave it empty for now, i expect it to change depending on if the enemy is a hitter or a shooter


    public Rigidbody2D rb;
    public float hp;
    public GameObject enemy;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
            Destroy(enemy);
            
    }
    public void TakeDamage(float damage)
    {
        hp -= damage;
    }


}
