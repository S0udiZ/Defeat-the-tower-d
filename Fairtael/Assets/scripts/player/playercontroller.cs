using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class playercontroller : MonoBehaviour
{
    public InventoryObject inventory;


    public float Speed = 10;
    public Rigidbody2D rb;


    public int hearts;
    public TMP_Text hearttext;


    SpriteRenderer spriteRenderer;

    Animator ani;



    // To avoid flipping too early
    private bool canFlip = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        ani = GetComponent<Animator>();

        hearttext.text = "Hearts: " + hearts;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get current animation state info
        AnimatorStateInfo stateInfo = ani.GetCurrentAnimatorStateInfo(0);

        //this is to let you move
        Vector3 direction = new Vector3(0, 0, 0);
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        direction = Vector3.ClampMagnitude(direction, 1);
        direction *= Speed;
        rb.velocity = direction;

        //hella bad animation code but it works sooooo   :-)
        ani.SetBool("NotWalking", Input.GetAxisRaw("Vertical") == 0 && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D));
        ani.SetBool("WalkingHor", Input.GetAxisRaw("Horizontal") != 0);
        ani.SetBool("WalkingBack", Input.GetAxisRaw("Vertical") > 0);
        ani.SetBool("WalkingFront", Input.GetAxisRaw("Vertical") < 0);



        // Prevent flipping until animation finishes
        if (stateInfo.IsName("WalkingHor")) // Replace "WalkingHor" with the actual animation name
        {
            if (stateInfo.normalizedTime >= 1f)
            {
                // Animation finished, allow flipping
                canFlip = true;
            }
            else
            {
                // Animation is still playing, prevent flipping
                canFlip = false;
            }
        }

        // Flip sprite renderer based on conditions
        if (canFlip && direction.x != 0)
        {
            spriteRenderer.flipX = direction.x > 0;
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



    public void TakeItem(ItemObject _item)
    {
        if (_item)
        {
            inventory.AddItem(_item, 1);

        }
    }


}
