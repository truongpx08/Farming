using System;
using UnityEngine;

public class SlotItemData : SlotItemAccess
{
    [SerializeField] private ItemData data;
    public ItemData Data => this.data;

    public void SetData(ItemData newData)
    {
        this.data = newData;
    }
}

[Serializable]
public class ItemData
{
    public ItemDefinition itemDefinition;
    public int quantity;

    public bool HasItem()
    {
        return itemDefinition != null && quantity > 0;
    }
}