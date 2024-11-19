using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
    public RoomGen roomGen;
    public GameObject roomEmpty;

    // Update is called once per frame
    void Start()
    {
        roomEmpty = GameObject.FindWithTag("roomGen");
        roomGen = roomEmpty.GetComponent<RoomGen>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            roomGen.NextRoom();

            gameObject.SetActive(false);
        }
    }

}
