using System;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/Item")]
public class ItemData : ScriptableObject
{
    public ItemType type;
    // Danh sách các loại tile1 mà item có thể sử dụng
    public List<Tile1Type> usableTile1Types;

    // Danh sách các loại tile2 mà item có thể sử dụng
    public List<Tile2Type> usableTile2Types;
}

[Serializable]
public enum ItemType
{
    None = 0,
    Rotation,
}