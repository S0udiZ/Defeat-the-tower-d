using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 10;
    public Rigidbody2D rb;
    public int hearts;
    public TMP_Text hearttext;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hearttext.text = "Hearts: " + hearts;
    }

    // Update is called once per frame
    void Update()
    {
        //mover
        Vector3 direction = new Vector3(0, 0, 0);
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        direction = Vector3.ClampMagnitude(direction, 1);
        direction *= Speed;
        rb.velocity = direction;

        if (hearts == 0)
        {
            Scene scene = SceneManager.GetActiveScene();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when you hit an enemy it does damage
        if (collision.collider.CompareTag("enemybase"))
            hearts--;

        if (collision.collider.CompareTag("enemybullet"))
            hearts=-2;
    }
}
