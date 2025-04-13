using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Customizable per project
/// </summary>
[Serializable]
public class TruongGameData
{
    public List<Tile1Data> tilemap1 = new();
    public List<Tile2Data> tilemap2 = new();
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
    MiniTree
}

[Serializable]
public enum Tile1Type
{
    None,
    Land,
    Water,
}