using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInitializer : SlotItemAccess
{
    public void Initialize(ItemData itemData)
    {
        this.GetItem().ItemData.SetData(itemData);
        this.GetItem().ItemIcon.SetSprite();
        this.GetItem().Quantity.SetText();
    }
}

[Serializable]
public class SlotItemAccess : MonoBehaviour
{
    private SlotItem slotItem;

    public SlotItem GetItem()
    {
        if (this.slotItem == null)
            this.slotItem = GetComponentInParent<SlotItem>();
        return this.slotItem;
    }
}