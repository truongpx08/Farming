using UnityEngine;

public class PrefabFactory : MonoBehaviour
{
    public static PrefabFactory Instance { get; private set; }
    public PrefabDatabase database;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public GameObject Spawn(PrefabType type, Transform parent = null)
    {
        GameObject prefab = database.GetPrefab(type);
        if (prefab == null)
        {
            Debug.LogError($"No prefab found for type: {type}");
            return null;
        }

        return ObjectPoolManager.Instance.GetObjectFromPool(prefab, parent);
    }
}