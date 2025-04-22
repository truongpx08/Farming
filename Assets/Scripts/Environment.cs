using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : TruongSingleton<Environment>
{
    
    
    [SerializeField] private Tile1Factory tile1Factory;
    public Tile1Factory Tile1Factory => this.tile1Factory;
    [SerializeField] private Tilemap1 tilemap1;
    public Tilemap1 Tilemap1 => this.tilemap1;
    [SerializeField] private Tile2Factory tile2Factory;
    public Tile2Factory Tile2Factory => this.tile2Factory;
    [SerializeField] private Tilemap2 tilemap2;
    public Tilemap2 Tilemap2 => this.tilemap2;
}