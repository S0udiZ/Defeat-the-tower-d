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
    SpriteRenderer spriteRenderer;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hearttext.text = "Hearts: " + hearts;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //this is to let you move
        Vector3 direction = new Vector3(0, 0, 0);
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        direction = Vector3.ClampMagnitude(direction, 1);
        direction *= Speed;
        rb.velocity = direction;
        if(direction.x < 0) 
        {
            spriteRenderer.flipX = false;
        
        }
        if (direction.x > 0) 
        {
            spriteRenderer.flipX = true;
        }

        //<!> This part reloads the scene, it needs to be changed when in the actual game to load the death screen
        //title screen or whatever else<!>
        if (hearts <= 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        //theres probably a better way to do this
        hearttext.text = "Hearts: " + hearts;
    }

    public void TakeDamage(int Tdamage) 
    {
        hearts -= Tdamage;
    }

}
