using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Customizable per project
/// </summary>
[Serializable]
public class GameData
{
    public List<Tile1Data> tilemap1 = new();
    public List<Tile2Data> tilemap2 = new();
    public InventoryData inventoryData = new();
}

[Serializable]
public class Tile1Data
{
    public Tile1Type type;
    public Vector3 position;
}

[Serializable]
public class Tile2Data
{
    public Tile2Type type;
    public Vector3 position;
    public Vector3 rotation;
    public bool isOwnedByPlayer;
}

[Serializable]
public enum Tile2Type
{
    None,
    BigTree,
    Fence2,
    Fence21,
    Fence3,
    Fence4,
    MiniTree,
    Door,
    All,
}

[Serializable]
public enum Tile1Type
{
    None,
    Land,
    Water,
}

[Serializable]
public class InventoryData
{
    public List<ItemData> items = new();
}