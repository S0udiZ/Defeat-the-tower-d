using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybase : MonoBehaviour
{


    //this script is gonna be used as a base for future enemies, its gonna have the basics like taking damage and letting 
    //you set health, speed, etc, im still not quite sure if were making the enemies follow the player or move around in specific
    //patterns but ill leave it empty for now


    public Rigidbody2D rb;
    public float hp;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hp == 0)
            Destroy(enemy);
            
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        //this is pretty scuffed right now, im not sure how id take the damage value of whatever type of bullet
        //hits and minus the hp by it
        if (collision.collider.CompareTag("bullet"))
            hp--;
            
    }
}
