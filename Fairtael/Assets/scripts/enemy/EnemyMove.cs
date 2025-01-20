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

    public RoomGen roomgen;

    void Start()
    {
        
        if (shooter == false)
        {
            player = GameObject.FindWithTag("Player").transform;
            path = GetComponent<AIPath>();
            roomgen = GameObject.FindWithTag("roomGen").GetComponent<RoomGen>();
            path.maxSpeed = Movespeed + (roomgen.roomNumber / 15);
        }

    }

    private void Update()
    {

                path.destination = player.position;

                roomgen = GameObject.FindWithTag("roomGen").GetComponent<RoomGen>();
                path.maxSpeed = Movespeed + (roomgen.roomNumber / 15);
            


    }
   

}
