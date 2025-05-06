using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform originalParent;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private bool isDroppedOnSlot;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.position = eventData.position;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        isDroppedOnSlot = false;
        originalParent = transform.parent;
        transform.SetParent(transform.root);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        if (!isDroppedOnSlot)
        {
            transform.SetParent(originalParent);
            rectTransform.localPosition = Vector3.zero;
        }
    }

    public void SetDroppedOnSlot()
    {
        isDroppedOnSlot = true;
    }
}