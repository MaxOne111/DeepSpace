using UnityEngine;

public static class ObjectPool
{
    private static Transform FreeObject(Transform _pool)
    {
        if (_pool.childCount == 0)
            return null;
        
        
        for (int i = 0; i < _pool.childCount; i++)
        {
            if (_pool.GetChild(i))
            {
                return _pool.GetChild(i);
            }
        }

        return null;
    }

    public static void ReturnToPool(Transform _object, Transform _pool, Transform _spawn_Point)
    {
        _object.SetParent(_pool);
        _object.position = _spawn_Point.position;
        _object.gameObject.SetActive(false);
    }
    
    public static T PoolInstantiate<T>( T _prefab, Transform _spawn_Point,  Transform _pool) where T : MonoBehaviour
    {
        if (FreeObject(_pool))
        {
            FreeObject(_pool).gameObject.SetActive(true);
            FreeObject(_pool).transform.position = _spawn_Point.position;
            FreeObject(_pool).transform.SetParent(null);

            return null;
        }

        T _new_Oblect = Object.Instantiate(_prefab, _spawn_Point.position, Quaternion.identity);
        return _new_Oblect;
        
    }
}