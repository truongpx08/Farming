using UnityEngine;

public class SlotInitializer : MonoBehaviour
{
    [SerializeField] private InventorySlot slot;
    [SerializeField] private SlotItem itemPrefab;

    public void Initialize(ItemData itemData)
    {
        if (itemData != null && itemData.HasItem())
        {
            var item = ObjectPoolManager.Instance.GetObjectFromPool(this.itemPrefab.gameObject, slot.transform)
                .GetComponent<SlotItem>();
            this.slot.SetItem(item);
            this.slot.Item.GetComponent<RectTransform>().localPosition = Vector3.zero;
            this.slot.Item.Initializer.Initialize(itemData);
        }
    }
}