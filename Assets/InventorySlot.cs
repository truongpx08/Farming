using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private SlotInitializer initializer;
    public SlotInitializer Initializer => this.initializer;

    public SlotItem Item { get; private set; }

    public void SetItem(SlotItem slotItem)
    {
        this.Item = slotItem;
        if (this.Item != null)
            this.Item.SetSlot(this);
    }

    public void SwapWith(InventorySlot otherSlot)
    {
        // Hoán đổi dữ liệu
        var tempItem = this.Item;
        this.SetItem(otherSlot.Item);
        otherSlot.SetItem(tempItem);
    }
}