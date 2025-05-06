using UnityEngine;

/// <summary>
/// Class cơ sở cung cấp quyền truy cập đến InventoryPanel.
/// Các class khác có thể kế thừa class này để truy cập InventoryPanel.
/// </summary>
public abstract class InventoryPanelAccess : MonoBehaviour
{
    // Tham chiếu đến InventoryPanel
    private InventoryPanel _inventoryPanel;

    // Phương thức để kiểm tra và lấy InventoryPanel
    protected InventoryPanel GetInventoryPanel()
    {
        if (this._inventoryPanel == null)
        {
            this._inventoryPanel = GamePlayUI.Instance.InventoryPanel;
        }

        return this._inventoryPanel;
    }
}