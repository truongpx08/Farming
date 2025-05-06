using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotDrop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        var item = eventData.pointerDrag.GetComponent<ItemDragHandler>();
        if (item != null)
        {
            item.transform.SetParent(transform);
            item.GetComponent<RectTransform>().localPosition = Vector3.zero;
            item.SetDroppedOnSlot();
        }
    }
}