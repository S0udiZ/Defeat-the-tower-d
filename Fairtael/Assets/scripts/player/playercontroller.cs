using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using Unity.VisualScripting;

public class playercontroller : MonoBehaviour
{
    public InventoryObject inventory;

    public ItemChoiceScript itemChoiceScript;

    public RoomGen roomGen;

    public bool allowNewItem = true;

    bool hasDied = false;

    public Enemybase Enemybase;

    public GameObject deathUI;

    public GameObject playerUI;

    public float Speed = 10;
    public Rigidbody2D rb;


    public float hearts;
    public float maxHearts;
    public TMP_Text hearttext;

    bool immunity = false;

    SpriteRenderer spriteRenderer;

    public GameObject FullHeart;
    public GameObject HollowHeart;
    public Vector3 heartPlacement;

    Animator ani;

    //public GameObject healthBar;  

    AudioManage audioManager;


    public GameObject purchagedUI;
    // To avoid flipping too early
    private bool canFlip = true;

    // Start is called before the first frame update
    void Start()
    {

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManage>();

        rb = GetComponent<Rigidbody2D>();

        ani = GetComponent<Animator>();

        hearttext.text = "Hearts: " + hearts;
        spriteRenderer = GetComponent<SpriteRenderer>();

        GameObject game = GameObject.FindGameObjectWithTag("ItemBookUI");
        purchagedUI = game.transform.GetChild(0).GetChild(9).gameObject;

        Vector3 placement = heartPlacement;
        for (int i = 0; i < hearts; i++)
        {
            placement = placement + new Vector3(20, 0, 0);
            Instantiate(FullHeart, placement, Quaternion.identity, playerUI.transform);
        }
    }

    // Update is called once per frame
    private void Update()
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


        if (hearts <= 0)
        {
            if (!hasDied) 
            {
                audioManager.PlaySFX(audioManager.playerDeath);
                this.gameObject.transform.Rotate(0, 0, 90);
                hasDied = true;
            }

            deathUI.SetActive(true);
            TMP_Text txt = deathUI.gameObject.transform.GetChild(1).GetComponent<TMP_Text>();
            txt.text = "Floors Cleared:  "+ roomGen.roomNumber;

            Time.timeScale = 0f;

            inventory.items.Clear();
        }

        //theres probably a better way to do this
        hearttext.text = "Hearts: " + hearts;

    }
    public void ChangeHearts(float tMaxHearts, float tHearts)
    {
        maxHearts += tMaxHearts;
        hearts += tHearts;
    }
    IEnumerator unimmunity()
    {

        yield return new WaitForSeconds(1.5f);
        immunity = false;
    }

    IEnumerator redblink()
    {
        audioManager.PlaySFX(audioManager.playerHit);
        spriteRenderer.color = new Color(255, 0, 0, 1);
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = new Color(255, 255, 255, 1);
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag==("enemy"))
        {
            if (immunity == false)
            {
                Debug.Log("SIGMA!!!");
                hearts--;//Enemybase.Edamage;
                immunity = true;
                StartCoroutine(redblink());
                StartCoroutine(unimmunity());

            }
            /*Debug.Log("sigma!");
            TakeDamage();*/
        }
    }
    public void TakeDamage(int Tdamage)
    {
        if (immunity == false)
        {
            hearts -= Tdamage;
            immunity = true;
            StartCoroutine(redblink());
            StartCoroutine(unimmunity());

        }
    }
    public void TakeItemLeft()
    {
        if (allowNewItem)
        {
            itemChoiceScript = GameObject.FindWithTag("itemBook").GetComponent<ItemChoiceScript>();
            inventory.AddItem(itemChoiceScript.itemLeft, 1);

            purchagedUI.SetActive(true);

            GameObject game = GameObject.FindGameObjectWithTag("ItemBookUI");
            Transform childTransform = game.gameObject.transform.GetChild(0);
            itemChoiceScript.ItemChoiceUI = childTransform.gameObject;
            itemChoiceScript.ItemChoiceUI.SetActive(false);
            Time.timeScale = 1;
            allowNewItem = false;
            audioManager.PlaySFX(audioManager.itemObtain);

            Debug.LogWarning("dd");
        }
        else
        {
            Debug.Log("ur shit.... umm u have taken an here item allready");
        }
    }
    public void TakeItemRight()
    {
        if (allowNewItem)
        {
            itemChoiceScript = GameObject.FindWithTag("itemBook").GetComponent<ItemChoiceScript>();

            inventory.AddItem(itemChoiceScript.itemRight, 1);

            purchagedUI.SetActive(true);

            GameObject game = GameObject.FindGameObjectWithTag("ItemBookUI");
            Transform childTransform = game.gameObject.transform.GetChild(0);
            itemChoiceScript.ItemChoiceUI = childTransform.gameObject;
            itemChoiceScript.ItemChoiceUI.SetActive(false);
            Time.timeScale = 1;
            allowNewItem = false;
            audioManager.PlaySFX(audioManager.itemObtain);

        }
        else 
        {
            Debug.Log("ur shit.... umm u have taken an item here allready");
        }
    }
    private void OnApplicationQuit()
    {
        inventory.items.Clear();
    }


}
