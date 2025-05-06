using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private SlotInitializer initializer;
    public SlotInitializer Initializer => this.initializer;

    public SlotItem Item { get; private set; }

    public void SetItem(SlotItem slotItem)
    {
        this.Item = slotItem;
    }
}