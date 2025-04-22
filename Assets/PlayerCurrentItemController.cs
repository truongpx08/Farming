using System;
using UnityEngine;

public class PlayerCurrentItemController : MonoBehaviour
{
    // Biến để lưu trữ item hiện tại
    public ItemData CurrentItem { get; private set; }

    // Sự kiện khi item được thay đổi
    public event Action<ItemData> OnItemChanged;


    // Phương thức để đặt item mới
    public void SetCurrentItem(ItemData newItem)
    {
        if (CurrentItem != newItem)
        {
            CurrentItem = newItem;
            // Gọi sự kiện khi item thay đổi
            OnItemChanged?.Invoke(CurrentItem);
        }
    }

    // Phương thức để sử dụng item
    private void UseItem(Tile2 targetTile)
    {
        switch (CurrentItem.type)
        {
            case ItemType.Rotation:
                // Xoay mục tiêu một góc 90 độ
                targetTile.transform.Rotate(0, 90, 0);
                // Lưu lại rotation dưới dạng Vector3
                targetTile.Data.rotation = targetTile.transform.eulerAngles;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        Debug.Log("Item used on tile: " + targetTile.name);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Tile2 targetTile = FocusController.Instance.TargetTile;
            if (targetTile != null && CurrentItem != null)
            {
                UseItem(targetTile);
            }
        }
    }

    // Phương thức để xóa item hiện tại
    public void ClearCurrentItem()
    {
        SetCurrentItem(null);
    }
}