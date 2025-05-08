using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotDrop : MonoBehaviour, IDropHandler
{
    [SerializeField] private InventorySlot slot;

    public void OnDrop(PointerEventData eventData)
    {
        var itemDragHandler = eventData.pointerDrag.GetComponent<ItemDragHandler>();
        if (itemDragHandler != null)
        {
            var fromSlot = itemDragHandler.Item.Slot;
            var toSlot = GetComponent<InventorySlot>();

            if (fromSlot != null && toSlot != null && fromSlot != toSlot)
            {
                // Nếu slot đích đã có item, swap
                if (toSlot.Item != null)
                {
                    fromSlot.SwapWith(toSlot);
                }
                else
                {
                    // Nếu slot trống, chỉ chuyển item
                    toSlot.SetItem(fromSlot.Item);
                    fromSlot.SetItem(null);
                }
            }

            // Cập nhật vị trí UI của item (nếu cần)
            itemDragHandler.transform.SetParent(toSlot.transform);
            itemDragHandler.GetComponent<RectTransform>().localPosition = Vector3.zero;
            itemDragHandler.SetDroppedOnSlot();
        }
    }
}