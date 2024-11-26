using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemChoiceScript : MonoBehaviour
{
    public ItemObject itemRight;
    public ItemObject itemLeft;


    public GameObject ItemChoiceUI;

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            GameObject game = GameObject.FindGameObjectWithTag("ItemBookUI");
            Transform childTransform = game.gameObject.transform.GetChild(0);
            ItemChoiceUI = childTransform.gameObject;
            ItemChoiceUI.SetActive(false);


        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject game = GameObject.FindGameObjectWithTag("ItemBookUI");
        Transform childTransform = game.gameObject.transform.GetChild(0);
        ItemChoiceUI = childTransform.gameObject;
        

        ItemChoiceUI.SetActive(true);



    }

    
}
