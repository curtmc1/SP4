using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour 
{

    public Inventory Inventory;

    public GameObject MessagePanel;

	// Use this for initialization
	void Start () {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
       // Inventory.ItemRemoved += Inventory_ItemRemoved;
	}

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");

        foreach (Transform slot in inventoryPanel)
        {
            // Border... Image
            //Transform textTransform = slot.GetChild(0).GetChild(1);
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = imageTransform.GetComponentInChildren<Image>();
           // ItemHandler itemDragHandler = imageTransform.GetComponent<ItemHandler>();

            if(image.enabled == false)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;
                //itemDragHandler.Item = e.Item;

                break;
            }
        }
    }

    //private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    //{
    //    Transform inventoryPanel = transform.Find("InventoryPanel");

    //    foreach (Transform slot in inventoryPanel)
    //    {
    //        Transform imageTransform = slot.GetChild(0).GetChild(0);
    //        Image image = imageTransform.GetComponent<Image>();
    //        ItemHandler itemDragHandler = imageTransform.GetComponent<ItemHandler>();

    //        // We found the item in the UI
    //        if (itemDragHandler.Item.Equals(e.Item))
    //        {
    //            image.enabled = false;
    //            image.sprite = null;
    //            itemDragHandler.Item = null;
    //            break;
    //        }
    //    }
    //}

    //private bool mIsMessagePanelOpened = false;

    //public bool IsMessagePanelOpened
    //{
    //    get { return mIsMessagePanelOpened; }
    //}

    //public void OpenMessagePanel(InteractableItemBase item)
    //{
    //    MessagePanel.SetActive(true);

    //    Text mpText = MessagePanel.transform.Find("Text").GetComponent<Text>();
    //    mpText.text = item.InteractText;


    //    mIsMessagePanelOpened = true;


    //}

    //public void OpenMessagePanel(string text)
    //{
    //    MessagePanel.SetActive(true);

    //    Text mpText = MessagePanel.transform.Find("Text").GetComponent<Text>();
    //    mpText.text = text;


    //    mIsMessagePanelOpened = true;
    //}

    //public void CloseMessagePanel()
    //{
    //    MessagePanel.SetActive(false);

    //    mIsMessagePanelOpened = false;
    //}
}
