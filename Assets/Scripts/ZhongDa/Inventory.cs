using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int slot = 6;
    private List<IInventoryItems> m_items = new List<IInventoryItems>();
    public event EventHandler<InventoryEventArgs> ItemAdded;

    public void AddItem(IInventoryItems item)
    {
        if(m_items.Count < slot)
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();

            if (collider.enabled)
            {
                collider.enabled = false;
                m_items.Add(item);
                item.OnPickUp();

                if(ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }
}
