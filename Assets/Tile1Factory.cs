using UnityEngine;
using System.Collections.Generic;

public class Tile1Factory : MonoBehaviour
{
    [System.Serializable]
    public class Tile1PrefabEntry
    {
        public Tile1Type type;
        public GameObject prefab;
    }

    [SerializeField] private List<Tile1PrefabEntry> tilePrefabs;

    private Dictionary<Tile1Type, GameObject> prefabMap;

    private void Awake()
    {
        // Chuyển danh sách thành Dictionary để tra nhanh
        prefabMap = new Dictionary<Tile1Type, GameObject>();
        foreach (var entry in tilePrefabs)
        {
            prefabMap[entry.type] = entry.prefab;
        }
    }

    public GameObject SpawnTile(Tile1Data data)
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