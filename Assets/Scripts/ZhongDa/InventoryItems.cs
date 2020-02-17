using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItems
{
    string name { get; }
    Sprite image { get; }

    void OnPickUp();
}

public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(IInventoryItems item)
    {
        Item = item;
    }

    public IInventoryItems Item;
}
