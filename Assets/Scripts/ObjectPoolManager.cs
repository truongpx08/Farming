using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class ObjectPoolManager : TruongSingleton<ObjectPoolManager>
{
    // Dictionary để lưu trữ pool cho từng loại prefab
    [ShowInInspector] private Dictionary<string, Queue<GameObject>> _pools = new();

    // Số lượng object tối đa trong mỗi pool
    [SerializeField] private int maxPoolSize = 10;

    // Transform để chứa các object không sử dụng
    [SerializeField] private Transform poolContainer;

    protected override void Awake()
    {
        base.Awake();
        poolContainer.gameObject.SetActive(false); // Ẩn container
    }

    // Tạo key từ prefab
    private string GetKeyFromPrefab(GameObject prefab)
    {
        return prefab.GetInstanceID() + "_" + prefab.name;
    }

    // Phương thức để lấy object từ pool hoặc tạo mới
    public GameObject GetObjectFromPool(GameObject prefab, Transform parent = null)
    {
        // Nếu prefab là null, không thể tạo object
        if (prefab == null)
            return null;

        string key = GetKeyFromPrefab(prefab);

        // Kiểm tra xem pool đã tồn tại chưa
        if (!_pools.ContainsKey(key))
        {
            _pools[key] = new Queue<GameObject>();
        }

        // Lấy pool tương ứng
        Queue<GameObject> pool = _pools[key];

        GameObject obj = null;

        // Kiểm tra xem trong pool có object nào không
        while (pool.Count > 0 && obj == null)
        {
            GameObject pooledObj = pool.Dequeue();
            Debug.Log("Dequeue");
            if (pooledObj != null)
            {
                obj = pooledObj;
            }
        }

        // Nếu không có object trong pool hoặc tất cả đã bị hủy, tạo mới
        if (obj == null)
        {
            obj = Instantiate(prefab);
            obj.name = $"{prefab.name}_Pooled";

            // Thêm component để đánh dấu object thuộc pool nào
            PooledObject pooledObj = obj.AddComponent<PooledObject>();
            pooledObj.PoolKey = key;
        }

        // Thiết lập parent nếu có
        if (parent != null)
        {
            obj.transform.SetParent(parent);
        }
        else
        {
            obj.transform.SetParent(null);
        }

        // Kích hoạt object nếu chưa được kích hoạt
        if (!obj.activeSelf)
        {
            obj.SetActive(true);
        }

        return obj;
    }

    // Phương thức để trả object về pool
    public void ReturnObjectToPool(GameObject obj)
    {
        if (obj == null)
            return;

        // Lấy component PooledObject để biết object thuộc pool nào
        PooledObject pooledObj = obj.GetComponent<PooledObject>();
        if (pooledObj == null || string.IsNullOrEmpty(pooledObj.PoolKey))
        {
            // Nếu không có thông tin pool, hủy object
            Destroy(obj);
            return;
        }

        // Lấy pool tương ứng
        string key = pooledObj.PoolKey;
        if (!_pools.ContainsKey(key))
        {
            _pools[key] = new Queue<GameObject>();
        }

        Queue<GameObject> pool = _pools[key];

        // Kiểm tra xem pool đã đầy chưa
        if (pool.Count >= maxPoolSize)
        {
            // Nếu pool đã đầy, hủy object
            Destroy(obj);
            return;
        }

        // Đặt lại object và thêm vào pool
        if (obj.activeSelf)
        {
            obj.SetActive(false);
        }

        obj.transform.SetParent(poolContainer);
        Debug.Log("Dequeue");
        pool.Enqueue(obj);
    }

    // Phương thức để xóa một pool cụ thể
    public void ClearPool(string key)
    {
        if (_pools.ContainsKey(key))
        {
            Queue<GameObject> pool = _pools[key];
            while (pool.Count > 0)
            {
                GameObject obj = pool.Dequeue();
                if (obj != null)
                {
                    Destroy(obj);
                }
            }

            _pools.Remove(key);
        }
    }

    // Phương thức để xóa một pool bằng prefab
    public void ClearPool(GameObject prefab)
    {
        if (prefab != null)
        {
            string key = GetKeyFromPrefab(prefab);
            ClearPool(key);
        }
    }

    // Phương thức để xóa tất cả các pool
    public void ClearAllPools()
    {
        foreach (var key in new List<string>(_pools.Keys))
        {
            ClearPool(key);
        }

        _pools.Clear();
    }

    protected override void OnDestroy()
    {
        // Xóa tất cả các pool khi component bị hủy
        ClearAllPools();
        base.OnDestroy();
    }
}

// Component để đánh dấu object thuộc pool nào
public class PooledObject : MonoBehaviour
{
    public string PoolKey { get; set; }
}