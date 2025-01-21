using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemChoiceScript : MonoBehaviour
{
    public List<ItemObject> allItems = new List<ItemObject>();
    public ItemObject itemRight;
    public ItemObject itemLeft;
    

    public GameObject ItemChoiceUI;
    public GameObject player;
    public playercontroller playercontroller;

    AudioManage audioManager;
    public MenuController menuController;

    void Awake()
    {
        menuController = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuController>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManage>();
        player = GameObject.FindWithTag("Player");
        playercontroller = player.GetComponent<playercontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && playercontroller.allowNewItem == false)
        {
            GameObject game = GameObject.FindGameObjectWithTag("ItemBookUI");
            Transform childTransform = game.gameObject.transform.GetChild(0);
            ItemChoiceUI = childTransform.gameObject;
            ItemChoiceUI.SetActive(false);


        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        audioManager.PlaySFX(audioManager.pedestal);
        GameObject game = GameObject.FindGameObjectWithTag("ItemBookUI");
        Transform childTransform = game.gameObject.transform.GetChild(0);
        ItemChoiceUI = childTransform.gameObject;

        Time.timeScale = 0;

        ItemChoiceUI.SetActive(true);

        itemLeft = allItems[Random.Range(0,allItems.Count)];
        itemRight = allItems[Random.Range(0, allItems.Count)];
        while (itemLeft == itemRight)
        {
            itemRight = allItems[Random.Range(0, allItems.Count)];
        }
        Image leftSprite = ItemChoiceUI.gameObject.transform.GetChild(3).gameObject.GetComponent<Image>();
        TMP_Text leftItemName = ItemChoiceUI.gameObject.transform.GetChild(1).gameObject.GetComponent<TMP_Text>();
        TMP_Text leftItemDescription = ItemChoiceUI.gameObject.transform.GetChild(2).gameObject.GetComponent<TMP_Text>(); 

        Image rightSprite = ItemChoiceUI.gameObject.transform.GetChild(6).gameObject.GetComponent<Image>(); 
        TMP_Text rightItemName = ItemChoiceUI.gameObject.transform.GetChild(4).gameObject.GetComponent<TMP_Text>(); 
        TMP_Text rightItemDescription = ItemChoiceUI.gameObject.transform.GetChild(5).gameObject.GetComponent<TMP_Text>();
        
        leftSprite.sprite = itemLeft.sprite;
        leftItemName.text = itemLeft.name;
        leftItemDescription.text = itemLeft.itemDescription;

        rightSprite.sprite = itemRight.sprite;
        rightItemName.text = itemRight.name;
        rightItemDescription.text = itemRight.itemDescription;
    }



}
