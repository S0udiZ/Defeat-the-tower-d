using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
    public SpriteRenderer visual;

    public RoomGen roomGen;
    public GameObject roomEmpty;


    bool allowNextRoom;

    // Update is called once per frame
    void Start()
    {
        roomEmpty = GameObject.FindWithTag("roomGen");
        roomGen = roomEmpty.GetComponent<RoomGen>();
        visual = GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") && allowNextRoom)
        {
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Player") && allowNextRoom)
        {
            roomGen.NextRoom();
            allowNextRoom = false;
            visual.enabled = false;
        }
    }

    public void AllowNextRoom()
    {
        allowNextRoom = true;
        visual.enabled = true;

    }
}
