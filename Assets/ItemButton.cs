using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    private ItemData itemData;
    [SerializeField] private Image itemIcon;

    private PlayerCurrentItemController itemController;

    private void Start()
    {
        itemController = PlayerController.Instance.CurrentItemController;
    }

    public void Setup(ItemData data)
    {
        itemData = data;
        if (itemData != null && itemIcon != null)
        {
            itemIcon.sprite = itemData.icon;
            itemIcon.enabled = true;
        }
        else
        {
            itemIcon.enabled = false;
        }
    }

    public void OnButtonClicked()
    {
        Debug.Log($"Selected item: {transform.GetSiblingIndex()}");
        itemController.SetCurrentItem(itemData);
    }
}