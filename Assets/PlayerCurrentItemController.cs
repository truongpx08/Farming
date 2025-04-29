using System;
using UnityEngine;

public class PlayerCurrentItemController : MonoBehaviour
{
    // Biến để lưu trữ item hiện tại
    public ItemData CurrentItemData { get; private set; }
    public GameObject currentItemObj;

    // Phương thức để đặt item mới
    public void SetCurrentItem(ItemData newItemData)
    {
        if (CurrentItemData != newItemData)
        {
            CurrentItemData = newItemData;
            // Tắt item đang cầm trên tay
            if (currentItemObj != null)
            {
                ObjectPoolManager.Instance.ReturnObjectToPool(this.currentItemObj);
                this.currentItemObj = null;
            }

            switch (CurrentItemData.type)
            {
                case ItemType.None:

                    break;
                case ItemType.Rotation:
                    this.currentItemObj = ObjectPoolManager.Instance.GetObjectFromPool(CurrentItemData.prefab,
                        this.transform
                    );
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    // Phương thức để sử dụng item
    private void UseItem(Tile2 targetTile)
    {
        switch (CurrentItemData.type)
        {
            case ItemType.None:
                break;
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
            if (targetTile != null && CurrentItemData != null)
            {
                UseItem(targetTile);
            }
        }
    }
}