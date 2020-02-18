using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryController : MonoBehaviour
{
    //private InventoryItemBase mCurrentItem = null;
    //private InteractableItemBase mInteractItem = null;
    //public HUD Hud;
    //public GameObject onHand;
    public Inventory Inventory;

    //void Start()
    //{
    //    Inventory.ItemUsed += Inventory_ItemUsed;
    //    Inventory.ItemRemoved += Inventory_ItemRemoved;
    //}

    //private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    //{
    //    InventoryItemBase item = e.Item;

    //    GameObject goItem = (item as MonoBehaviour).gameObject;
    //    goItem.SetActive(true);
    //    goItem.transform.parent = null;

    //}

    //private void SetItemActive(InventoryItemBase item, bool active)
    //{
    //    GameObject currentItem = (item as MonoBehaviour).gameObject;
    //    currentItem.SetActive(active);
    //    currentItem.transform.parent = active ? onHand.transform : null;
    //}

    //private void Inventory_ItemUsed(object sender, InventoryEventArgs events)
    //{
    //    if (events.Item.ItemType != EItemType.Consumable)
    //    {
    //        // If the player carries an item, un-use it (remove from player's hand)
    //        if (mCurrentItem != null)
    //        {
    //            SetItemActive(mCurrentItem, false);
    //        }

    //        InventoryItemBase item = events.Item;

    //        // Use item (put it to hand of the player)
    //        SetItemActive(item, true);

    //        mCurrentItem = events.Item;
    //    }

    //}

    //public void DropCurrentItem()
    //{
    //    GameObject goItem = (mCurrentItem as MonoBehaviour).gameObject;
    //    Inventory.RemoveItem(mCurrentItem);
    //}
    //public void DropItem()
    //{

    //    // Remove Rigidbody
    //    Destroy((mCurrentItem as MonoBehaviour).GetComponent<Rigidbody>());

    //    mCurrentItem = null;
    //}

    //void Update()
    //{
    //    if (mCurrentItem != null && Input.GetKeyDown(KeyCode.R))
    //    {
    //        DropCurrentItem();
    //    }

    //    if (mInteractItem != null && Input.GetKeyDown(KeyCode.F))
    //    {
    //        InteractableItemBase item = other.GetComponent<InteractableItemBase>();
    //        Inventory.AddItem(item);
    //    }

    //        if (Input.GetKeyDown(KeyCode.I))
    //    {
    //        Cursor.visible = true;
    //    }
    //    else
    //        Cursor.visible = false;

    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    InteractableItemBase item = other.GetComponent<InteractableItemBase>();
    //    if (item != null)
    //    {
    //        if (item.CanInteract(other))
    //        {
    //            mInteractItem = item;
    //            Hud.OpenMessagePanel(mInteractItem);
    //        }
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    InteractableItemBase item = other.GetComponent<InteractableItemBase>();
    //    if (item != null)
    //    {
    //        Hud.CloseMessagePanel();
    //        mInteractItem = null;
    //    }
    //}

    void Start()
    {
        //Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if(Input.GetKeyDown(KeyCode.O))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();

        if(item != null)
        {
            Inventory.AddItem(item);
        }
    }
}
