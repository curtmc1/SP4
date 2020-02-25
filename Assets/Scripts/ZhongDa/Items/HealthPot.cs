using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPot : MonoBehaviour
{
    private HealthBarShrink hpbar;
    public GameObject item;
    [HideInInspector]
    public GameObject itemManager;
    public bool playerItem;
    public int id;

    void Start()
    {
        hpbar = (HealthBarShrink)FindObjectOfType(typeof(HealthBarShrink));

        itemManager = GameObject.FindGameObjectWithTag("ItemManager");
        if (!playerItem)
        {
            int allItems = itemManager.transform.childCount;

            for (int i = 0; i < allItems; i++)
            {
                if (itemManager.transform.GetChild(i).gameObject.GetComponent<Item>().id == id)
                {
                    item = itemManager.transform.GetChild(i).gameObject;
                }
            }
        }
    }

    void Update()
    {
        Item itemOnHand = item.GetComponent<Item>();

        if (Input.GetKeyUp(KeyCode.G))
        {
            hpbar.IncreaseHealth(10);
            item.gameObject.SetActive(false);
            item.GetComponent<Inventory>().RemoveItem(item, itemOnHand.id, itemOnHand.type, itemOnHand.description, itemOnHand.icon);
        }
    }
}
