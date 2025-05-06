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
    public SlotItemData ItemData => this.itemData;
}