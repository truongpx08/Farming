using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemQuantity : SlotItemAccess
{
    [SerializeField] private TextMeshProUGUI textMP;

    public void SetText()
    {
        if (this.GetItem().ItemData.Data.HasItem())
        {
            this.textMP.enabled = true;
            this.textMP.text = this.GetItem().ItemData.Data.quantity.ToString();
        }
        else
        {
            this.textMP.enabled = false;
        }
    }
}