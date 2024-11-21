using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMove : MonoBehaviour
{
    private AIPath path;
    [SerializeField] private float movespeed;
    [SerializeField] private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        path = GetComponent<AIPath>();
    }

    private void Update()
    {

            path.maxSpeed = movespeed;

            path.destination = player.position;

    }
}
