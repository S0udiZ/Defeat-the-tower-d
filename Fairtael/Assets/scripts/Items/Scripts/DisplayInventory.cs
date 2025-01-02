using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;


    public int xStart;
    public int yStart;
    public int xSpace;
    public int columnAmount;
    public int ySpace;
    Dictionary<Inventoryslot,GameObject> itemsDisplayed = new Dictionary<Inventoryslot,GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }
    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.items.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.items[i]))
            {
                itemsDisplayed[inventory.items[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.items[i].amount.ToString();
            }
            else
            {
                var obj = Instantiate(inventory.items[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.items[i].amount.ToString();
                itemsDisplayed.Add(inventory.items[i], obj);
            }
        }
    }
    public void CreateDisplay()
    {
        for(int i = 0; i < inventory.items.Count; i++)
        {
            var obj = Instantiate(inventory.items[i].item.prefab, Vector3.zero,Quaternion.identity,transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.items[i].amount.ToString();
            itemsDisplayed.Add(inventory.items[i], obj);
        }
    }
    public Vector3 GetPosition(int i)
    {
        return new Vector3(xStart + (xSpace * (i % columnAmount)), yStart + (-ySpace * (i / columnAmount)), 0f);
    }
}
