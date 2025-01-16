using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ObstacleCheck : MonoBehaviour
{
    public GameObject[] Obstacles;
    public GameObject[] OldObstacles;
    public GameObject[] EnemyObstacles;
    public GameObject[] EnemyOldObstacles;

    // Update is called once per frame
    void Update()
    {
        Obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        EnemyObstacles = GameObject.FindGameObjectsWithTag("enemyObs");
        if (Obstacles.Length != OldObstacles.Length || EnemyObstacles.Length != EnemyOldObstacles.Length)
        {
            OldObstacles = Obstacles;
            EnemyOldObstacles = EnemyObstacles;

            AstarPath.active.Scan();
        }
    }
}
