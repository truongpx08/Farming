using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    private ItemDefinition _itemDefinition;
    [SerializeField] private Image itemIcon;

    public void Setup(ItemDefinition definition)
    {
        _itemDefinition = definition;
        if (_itemDefinition != null && _itemDefinition.icon != null && itemIcon != null)
        {
            itemIcon.sprite = _itemDefinition.icon;
            itemIcon.gameObject.SetActive(true);
        }
        else
        {
            itemIcon.gameObject.SetActive(false);
        }
    }

    public void OnButtonClicked()
    {
        Debug.Log($"Selected item: {transform.GetSiblingIndex()}");
        PlayerController.Instance.CurrentItemController.SetCurrentItem(_itemDefinition);
        FocusController.Instance.UpdateModel();
    }
}