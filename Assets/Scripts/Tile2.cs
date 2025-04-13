using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Tile2 : MonoBehaviour
{
    [SerializeField] private Tile2Data data;
    public Tile2Data Data => this.data;

    [Button]
    private void UpdatePositionData()
    {
        this.data.position = transform.position;
    }
}