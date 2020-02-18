﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem
{
    string Name { get; }
    Sprite Image { get; }
    void onPickup();
}
public class InventoryEventArgs : EventArgs
{
    //public InventoryEventArgs(InventoryItemBase item)
    //{
    //    Item = item;
    //}

    //public InventoryItemBase Item;

    public InventoryEventArgs(IInventoryItem item)
    {
        Item = item;
    }

    public IInventoryItem Item;
}

