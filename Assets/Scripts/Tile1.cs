using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Tile1 : MonoBehaviour
{
    [SerializeField] private Tile1Data data;
    public Tile1Data Data => this.data;

    [Button]
    private void UpdatePositionData()
    {
        this.data.position = transform.position;
    }
}