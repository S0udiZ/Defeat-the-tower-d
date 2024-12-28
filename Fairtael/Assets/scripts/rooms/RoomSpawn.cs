using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
    public SpriteRenderer visual;

    public RoomGen roomGen;
    public GameObject roomEmpty;

    public GameObject player;
    public playercontroller playerController;

    bool allowNextRoom;

    // Update is called once per frame
    void Start()
    {
        roomEmpty = GameObject.FindWithTag("roomGen");
        roomGen = roomEmpty.GetComponent<RoomGen>();
        visual = GetComponent<SpriteRenderer>();


        player = GameObject.FindWithTag("player");
        playerController = player.GetComponent<playercontroller>();
    }

    private void OnTriggerStay2D(Collider2D collision)
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
            //playerController.allowNewItem = true;
        }
    }

    public void AllowNextRoom()
    {
        allowNextRoom = true;
        visual.enabled = true;

    }
}
