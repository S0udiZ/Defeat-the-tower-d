using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public /*Static?*/ class Enemybase : MonoBehaviour
{

    public Rigidbody2D rb;
    public float hp = 2;
    public GameObject enemy;
    public float speed;
    public GameObject obstacle;

    public RoomGen roomgenscript;


    void Awake()
    {
        GameObject roomGenObj = GameObject.FindWithTag("roomGen");
        roomgenscript = roomGenObj.GetComponent<RoomGen>();

        if (roomgenscript != null && roomgenscript.enemies != null) roomgenscript.enemies.Add(this.gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(enemy);
        }

    }
    public void TakeDamage(float damage)
    {
        hp -= damage;
    }
    void OnDestroy()
    {
        Instantiate(obstacle, transform.position,Quaternion.identity,roomgenscript.OldRoom.transform);

        if (!Application.isPlaying) return;

        if (roomgenscript != null && roomgenscript.enemies != null && this.gameObject != null)
        {
            roomgenscript.enemies.Remove(this.gameObject);
        }
    }
}
