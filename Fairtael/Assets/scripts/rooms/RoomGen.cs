using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGen : MonoBehaviour
{

    List<GameObject> roomList = new List<GameObject>();
    public GameObject Room1;
    public GameObject Room2;
    public GameObject Room3;
    public GameObject ItemRoom;
    public GameObject OldRoom;
    public GameObject [] enemies;
    public GameObject RoomSpawn;
    public GameObject RoomSpawnTwo;

    public bool enemy;

    private int ItemChance;



    // Start is called before the first frame update
    void Start()
    {
        roomList.Add(Room1);
        roomList.Add(Room2);
        roomList.Add(Room3);
        roomList.Add(ItemRoom);
        NextRoom();
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        if (enemies.Length==0 && enemy)
        {
            enemy = false;
            Debug.Log("bonkers");
            RoomSpawn.SetActive(true);
        }
        else if (enemies.Length>0 && !enemy)
        {
            enemy = true;
        }
    }

    public void NextRoom()
    {
        if (ItemChance <= Random.Range(1, 100))
        {
            RoomSpawn = null;
            RoomSpawnTwo = null;
            if (OldRoom != null)Destroy(OldRoom);
            OldRoom=Instantiate(roomList[3]);
            ItemChance = 10;

            RoomSpawnTwo = GameObject.FindWithTag("RoomSpawn");
            if (RoomSpawnTwo != null) RoomSpawn = RoomSpawnTwo;
            RoomSpawn.SetActive(false);
        }
        else
        {
            RoomSpawn = null;
            RoomSpawnTwo = null;
            if (OldRoom != null) Destroy(OldRoom);
            int prefabIndex = UnityEngine.Random.Range(0, 2);
            OldRoom=Instantiate(roomList[prefabIndex]);
            ItemChance += 10;

            RoomSpawnTwo = GameObject.FindWithTag("RoomSpawn");
            if (RoomSpawnTwo != null) RoomSpawn = RoomSpawnTwo;
            RoomSpawn.SetActive(false);
        }
    }
}
