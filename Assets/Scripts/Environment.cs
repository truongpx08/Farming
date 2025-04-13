using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : TruongSingleton<Environment>
{
    [SerializeField] private List<Tile1> tilemap1Items;
    public List<Tile1> Tilemap1Items => this.tilemap1Items;
    [SerializeField] private List<Tile2> tilemap2Items;
    public List<Tile2> Tilemap2Items => this.tilemap2Items;
    [SerializeField] private Tile1Factory tile1Factory;
    public Tile1Factory Tile1Factory => this.tile1Factory;
    [SerializeField] private Tilemap1 tilemap1;
    public Tilemap1 Tilemap1 => this.tilemap1;
    [SerializeField] private Tile2Factory tile2Factory;
    public Tile2Factory Tile2Factory => this.tile2Factory;
}