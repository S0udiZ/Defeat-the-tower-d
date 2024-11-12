using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    GameObject[] camerapoints;

    public int currentPoint;
    bool allowNextLevel;

    // Start is called before the first frame update
    void Start()
    {
        camerapoints = GameObject.FindGameObjectsWithTag("CameraPoint");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
