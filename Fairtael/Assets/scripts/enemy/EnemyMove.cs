using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMove : MonoBehaviour
{
    private AIPath path;
    [SerializeField] private float Movespeed;
    [SerializeField] private Transform player;
    public bool shooter;
    [SerializeField]  Vector3 targetPos;


    void Start()
    {
        if (shooter == false)
        {
            player = GameObject.FindWithTag("Player").transform;
            path = GetComponent<AIPath>();
        }
        

        else
        {
            //umm uhh moves the shooters path to the other side of the screen
            player = GameObject.FindWithTag("Player").transform;



            path = GetComponent<AIPath>();
        }
        
    }

    private void Update()
    {

        if(shooter==true)
        {
            Vector3 dir = player.transform.position - transform.position;
            dir = dir.normalized;
            targetPos = player.transform.position + -dir * 10;
            targetPos = targetPos - transform.position;

            path.maxSpeed = Movespeed;

            path.destination = targetPos;
        }
        else
        {
            path.maxSpeed = Movespeed;

            path.destination = player.position;
        }

    }
}
