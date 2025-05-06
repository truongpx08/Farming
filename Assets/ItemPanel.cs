using UnityEngine;
using System.Collections.Generic;

public class ItemPanel : MonoBehaviour
{
    [SerializeField] private List<ItemButton> itemButtons = new();
    public List<ItemButton> ItemButtons => this.itemButtons;
    [SerializeField] private List<ItemDefinition> availableItems = new();

    public void InitializeButtons()
    {
        // Đảm bảo số lượng button và item phù hợp
        int itemCount = Mathf.Min(itemButtons.Count, availableItems.Count);

        // Gán item cho mỗi button
        for (int i = 0; i < itemButtons.Count; i++)
        {
            if (i < itemCount)
                itemButtons[i].Setup(availableItems[i]);
            else
                itemButtons[i].Setup(null); // Button không có item
        }

        ItemButtons[0].OnButtonClicked();
    }
}