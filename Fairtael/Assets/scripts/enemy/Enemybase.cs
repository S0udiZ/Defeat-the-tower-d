using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public /*Static?*/ class Enemybase : MonoBehaviour
{

    public Rigidbody2D rb;
    public float hp = 2;
    public GameObject enemy;
    public GameObject obstacle;
    public int Edamage = 1;
    SpriteRenderer spriteRenderer;
    public float speed;

    public EnemyMove enemymovescript;
    public RoomGen roomgenscript;
   


    void Awake()
    {
        GameObject roomGenObj = GameObject.FindWithTag("roomGen");
        roomgenscript = roomGenObj.GetComponent<RoomGen>();

        if (roomgenscript != null && roomgenscript.enemies != null) roomgenscript.enemies.Add(this.gameObject);
        
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        StartCoroutine(redblink());
        StartCoroutine(stun());
    }

    IEnumerator stun()
    {
            Debug.Log("uhhghhhg");
            speed = speed - 10;
            yield return new WaitForSeconds(1f);
            speed = speed + 10;

    }
    //this thing makes the thing work
    IEnumerator redblink()
    {
        spriteRenderer.color = new Color(255, 0, 0, 1);
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = new Color(255, 255, 255, 1);
    }
    
    void OnDestroy()
    {

        if(roomgenscript.OldRoom.transform != null)Instantiate(obstacle, transform.position,Quaternion.identity,roomgenscript.OldRoom.transform);

        if (!Application.isPlaying) return;

        if (roomgenscript != null && roomgenscript.enemies != null && this.gameObject != null)
        {
            roomgenscript.enemies.Remove(this.gameObject);
        }
    }

  
   
}
