using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        InventoryPanel inventoryPanel = GamePlayUI.Instance.InventoryPanel;
        inventoryPanel.Active.ToggleInventory();
        if (inventoryPanel.gameObject.activeSelf && !inventoryPanel.Initializer.HasInitialized)
        {
            inventoryPanel.Initializer.Initialize();
        }
    }
}