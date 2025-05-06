using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        GamePlayUI.Instance.InventoryPanel.Active.ToggleInventory();
    }
}