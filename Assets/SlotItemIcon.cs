using UnityEngine;
using UnityEngine.UI;

public class SlotItemIcon : SlotItemAccess
{
    [SerializeField] private Image image;

    public void SetSprite()
    {
        if (this.GetItem().ItemData.Data.HasItem())
        {
            this.image.sprite = this.GetItem().ItemData.Data.itemDefinition.icon;
            this.image.enabled = true;
        }
        else
        {
            this.image.enabled = false;
        }
    }
}