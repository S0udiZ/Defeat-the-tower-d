using System;
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

    public Enemyshooting enemyshoot;
    public RoomGen roomgenscript;

    AudioManage audioManager;
    
   ItemBuffs itemBuffs;


    void Awake()
    {
        enemyshoot = this.gameObject.GetComponent<Enemyshooting>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManage>();
        GameObject roomGenObj = GameObject.FindWithTag("roomGen");
        roomgenscript = roomGenObj.GetComponent<RoomGen>();

        if (this.gameObject.CompareTag("enemyObs"))
        { }
        else if (roomgenscript != null && roomgenscript.enemies != null) roomgenscript.enemies.Add(this.gameObject);
        
        spriteRenderer = GetComponent<SpriteRenderer>();

        hp += roomgenscript.roomNumber / 10;
    }


    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            audioManager.PlaySFX(audioManager.enemyDeath);
            Destroy(enemy);
        }

    }
    public void TakeDamage(float damage)
    {
        audioManager.PlaySFX(audioManager.enemyHit);
        hp -= damage;
        StartCoroutine(redblink());
        StartCoroutine(stun());
    }

    public IEnumerator stun()
    {
        if (!this.gameObject.CompareTag("enemyObs") && enemyshoot==null)
        {
            Debug.LogWarning("gg");
            rb.constraints = ~RigidbodyConstraints2D.FreezePositionX | ~RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

            itemBuffs = GameObject.FindWithTag("buffs").GetComponent<ItemBuffs>();
            yield return new WaitForSeconds(0.1f+itemBuffs.stunChange);
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            
        }
    }

    //this thing makes the thing work
    IEnumerator redblink()
    {
        spriteRenderer.color = new Color(255, 0, 0, 1);
        itemBuffs = GameObject.FindWithTag("buffs").GetComponent<ItemBuffs>();
        yield return new WaitForSeconds(0.2f+itemBuffs.stunChange);
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
