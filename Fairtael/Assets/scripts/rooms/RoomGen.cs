using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomGen : MonoBehaviour
{

    public List<GameObject> roomList = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();

    public RoomSpawn roomSpawnScript;

    public GameObject OldRoom;

    GameObject[] everyRoomSpawn;
    public GameObject player;
    public GameObject playerSpawn;


    public int ItemChance;

    public TMP_Text chanceText;

    public float roomNumber;

    AudioManage audioManager;



    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManage>();
        enemies.Add(this.gameObject);

        /*
        roomList.Add(ItemRoom);
        roomList.Add(Emptyroom);
        roomList.Add(Room1);
        roomList.Add(Room2);
        */

        NextRoom();

    }

    void Update()
    {
        if (enemies.Count == 1)
        {
            GameObject roomspawn = GameObject.FindWithTag("RoomSpawn");
            roomSpawnScript = roomspawn.GetComponent<RoomSpawn>();
            roomSpawnScript.AllowNextRoom();
        }

    }

    public void NextRoom()
    {
        audioManager.PlaySFX(audioManager.ladder);
        //player = GameObject.FindWithTag("Player");
        //playercontroller playerc = player.GetComponent<playercontroller>();
        //playerc.allowNewItem = true;
        if(OldRoom != null) roomNumber++;
        if (ItemChance >= Random.Range(1, 101))
        {
            if (OldRoom != null) Destroy(OldRoom);
            OldRoom = Instantiate(roomList[0]);
            ItemChance = 1;

            player = GameObject.FindWithTag("Player");
            playerSpawn = GameObject.FindWithTag("PlayerSpawn");
            player.transform.position = playerSpawn.transform.position;

            chanceText.text = ItemChance + "%";
        }
        else
        {

            if (OldRoom != null) 
            {
                Destroy(OldRoom);
                int prefabIndex = UnityEngine.Random.Range(2, roomList.Count);
                OldRoom = Instantiate(roomList[prefabIndex]);
            }

            else if(OldRoom == null)
            {
                Time.timeScale = 1;
                OldRoom = Instantiate(roomList[1]);
                GameObject[] dumbasswalls = GameObject.FindGameObjectsWithTag("Obstacle");
                GameObject[] dumbasswalls2 = GameObject.FindGameObjectsWithTag("enemyObs");

                for (int i = 0; i < dumbasswalls.Length; i++) 
                {
                    Destroy(dumbasswalls[i]);
                }
                for (int i = 0; i < dumbasswalls2.Length; i++)
                {
                    Destroy(dumbasswalls2[i]);
                }


            }
            ItemChance += Random.Range(1, 16);

            player = GameObject.FindWithTag("Player");
            playerSpawn = GameObject.FindWithTag("PlayerSpawn");
            player.transform.position = playerSpawn.transform.position;

            chanceText.text = ItemChance + "%";

        }
    }
}
