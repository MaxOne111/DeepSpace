using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GenericFabric<T> : MonoBehaviour where T: Transform
{
    [SerializeField] private T[] _Prefab;

    public Camera Camera { get; private set; }
    
    protected T CurrentInstance { get; set; }

    protected virtual void Awake()
    {
        Camera = Camera.main;
        SpawnPoint();
    }

    public T GetInstance()
    {
        int _index;
        
        if (_Prefab.Length > 1)
            _index = Random.Range(0, _Prefab.Length);
        else
        {
            _index = 0;
        }

        CurrentInstance = _Prefab[_index];
        
        return Instantiate(_Prefab[_index], SpawnPoint(), Quaternion.identity);
    }
    
    public T GetInstance(Transform _parent)
    {
        int _index;
        
        if (_Prefab.Length > 1)
            _index = Random.Range(0, _Prefab.Length);
        else
        {
            _index = 0;
        }
        
        CurrentInstance = _Prefab[_index];
        
        T _instance = Instantiate(_Prefab[_index], SpawnPoint(), Quaternion.identity);
        _instance.SetParent(_parent);
        
        return _instance;
    }

    protected virtual Vector2 SpawnPoint()
    {
        return Vector2.zero;
    }
}