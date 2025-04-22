using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemap2 : MonoBehaviour
{
    [SerializeField] private List<Tile2> tiles;
    public List<Tile2> Tiles => this.tiles;
}