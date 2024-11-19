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

    GameObject[] everyRoomSpawn;
    private int ItemChance;



    // Start is called before the first frame update
    void Start()
    {
        roomList.Add(ItemRoom);
        roomList.Add(Room1);
        roomList.Add(Room2);
        roomList.Add(Room3);

        NextRoom();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Length == 0)
        {

        }

    }

    public void NextRoom()
    {
        if(enemies.Length == 0)
        {
            if (ItemChance >= Random.Range(1, 101))
            {
                if (OldRoom != null) Destroy(OldRoom);
                OldRoom = Instantiate(roomList[0]);
                ItemChance = 1;


            }
            else
            {

                if (OldRoom != null) Destroy(OldRoom);
                int prefabIndex = UnityEngine.Random.Range(1, 3);
                OldRoom = Instantiate(roomList[prefabIndex]);
                ItemChance += Random.Range(1, 11);

            }
        }
    }
}
