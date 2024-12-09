using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMove : MonoBehaviour
{
    private AIPath path;
    [SerializeField] public float Movespeed;
    [SerializeField] private Transform player;
    public bool shooter;
    [SerializeField] Vector3 targetPos;
    Enemybase basescript;


    void Start()
    {
        
        if (shooter == false)
        {
            player = GameObject.FindWithTag("Player").transform;
            path = GetComponent<AIPath>();
            path.maxSpeed = Movespeed;
        }


        else
        {
            //umm uhh moves the shooters path to the other side of the screen
            player = GameObject.FindWithTag("Player").transform;
            path = GetComponent<AIPath>();
            path.maxSpeed = Movespeed;
            
        }

    }

    private void Update()
    {


        if (shooter == true)
        {
            Vector3 dir = player.transform.position - transform.position;
            dir = dir.normalized;
            targetPos = player.transform.position + -dir * 10;
            targetPos = targetPos - transform.position;

            Movespeed = this.gameObject.GetComponent<Enemybase>().speed;
            path.maxSpeed = Movespeed;

            path.destination = targetPos;
        }
        else
        {
            path.destination = player.position;

            Movespeed = this.gameObject.GetComponent<Enemybase>().speed;
            path.maxSpeed = Movespeed;
        }

    }


}
