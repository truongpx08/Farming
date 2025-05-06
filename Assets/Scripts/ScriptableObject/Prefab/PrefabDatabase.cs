using UnityEngine;

[CreateAssetMenu(fileName = "PrefabDatabase", menuName = "Factory/PrefabDatabase")]
public class PrefabDatabase : ScriptableObject
{
    public PrefabEntry[] entries;

    // Lấy prefab theo type
    public GameObject GetPrefab(PrefabType type)
    {
        foreach (var entry in entries)
        {
            if (entry.type == type)
                return entry.prefab;
        }

        Debug.LogWarning($"Prefab of type {type} not found!");
        return null;
    }
}

[System.Serializable]
public class PrefabEntry
{
    public PrefabType type;
    public GameObject prefab;
}

[System.Serializable]
public enum PrefabType
{
    None = 0,
    SlotItem = 1,
}