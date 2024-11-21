using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ObstacleCheck : MonoBehaviour
{
    public GameObject[] Obstacles;
    public GameObject[] OldObstacles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        if (Obstacles.Length != OldObstacles.Length)
        {
            OldObstacles = Obstacles;

            AstarPath.active.Scan();
        }
    }
}
