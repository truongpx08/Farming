using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotItem : MonoBehaviour
{
    [SerializeField] private SlotItemIcon itemIcon;
    public SlotItemIcon ItemIcon => this.itemIcon;
    [SerializeField] private ItemQuantity quantity;
    public ItemQuantity Quantity => this.quantity;
    [SerializeField] private ItemInitializer initializer;
    public ItemInitializer Initializer => this.initializer;
    [SerializeField] private SlotItemData itemData;
    private InventorySlot slot;
    public InventorySlot Slot => this.slot;
    public SlotItemData ItemData => this.itemData;

    public void SetSlot(InventorySlot inventorySlot)
    {
        this.slot = inventorySlot;
    }
}