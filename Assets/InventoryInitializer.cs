public class InventoryInitializer : InventoryPanelAccess
{
    public bool HasInitialized { get; private set; }

    public void Initialize()
    {
        int count = 0;
        DataManager.Instance.GameData.inventoryData.items.ForEach(itemData =>
        {
            var slot = this.GetInventoryPanel().Slots[count];
            slot.Initializer.Initialize(itemData);
            count++;
        });

        this.HasInitialized = true;
    }
}