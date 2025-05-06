using System;
using UnityEngine;

public class InventoryActive : InventoryPanelAccess
{
    public void ToggleInventory()
    {
        this.GetInventoryPanel().gameObject.SetActive(!this.GetInventoryPanel().gameObject.activeSelf);
    }
}