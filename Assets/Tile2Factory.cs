using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile2Factory : MonoBehaviour
{
    [System.Serializable]
    public class Tile2PrefabEntry
    {
        public Tile2Type type;
        public GameObject prefab;
    }

    [SerializeField] private List<Tile2PrefabEntry> tilePrefabs;

    private Dictionary<Tile2Type, GameObject> prefabMap;

    private void Awake()
    {
        // Chuyển danh sách thành Dictionary để tra nhanh
        prefabMap = new Dictionary<Tile2Type, GameObject>();
        foreach (var entry in tilePrefabs)
        {
            prefabMap[entry.type] = entry.prefab;
        }
    }

    public GameObject SpawnTile(Tile2Data data)
    {
        if (!prefabMap.TryGetValue(data.type, out var prefab))
        {
            Debug.LogError("Tile type not found: " + data.type);
            return null;
        }

        GameObject tile = Instantiate(prefab, data.position, Quaternion.identity);
        tile.transform.parent = Environment.Instance.Tilemap1.transform;
        return tile;
    }
}