using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryController : MonoBehaviour
{
    public Inventory Inventory;

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

    private void OnCollisionEnter(Collision other)
    {
        IInventoryItem item = other.collider.GetComponent<IInventoryItem>();

        if(item != null)
        {
            Inventory.AddItem(item);
        }
    }
}
