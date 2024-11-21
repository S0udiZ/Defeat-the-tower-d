using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMove : MonoBehaviour
{
    private AIPath path;
    [SerializeField] private float Movespeed;
    [SerializeField] private Transform Player;


    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        path = GetComponent<AIPath>();
    }

    private void Update()
    {
         path.maxSpeed = Movespeed;

         path.destination = Player.position;
    }
}
