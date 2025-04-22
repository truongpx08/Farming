using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemap1 : MonoBehaviour
{
    [SerializeField] private List<Tile1> tiles;
    public List<Tile1> Tiles => this.tiles;
}