using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class GenericFactory<T> : MonoBehaviour where T : Transform
{
    [SerializeField] private T[] _Prefab;

    protected Vector3 _Border;
    protected Vector3 _Screen;
    
    public T GetInstance()
    {
        int _index;
        
        if (_Prefab.Length > 1)
            _index = Random.Range(0, _Prefab.Length);
        else
        {
            _index = 0;
        }

        return Instantiate(_Prefab[_index], SpawnPoint(), StartRotation());
    }
    
    public T GetInstance(Vector3 _position)
    {
        int _index;
        
        if (_Prefab.Length > 1)
            _index = Random.Range(0, _Prefab.Length);
        else
        {
            _index = 0;
        }

        return Instantiate(_Prefab[_index], _position, StartRotation());
    }
    
    protected virtual Vector2 SpawnPoint() => Vector2.zero;
    protected virtual Quaternion StartRotation() => Quaternion.identity;

    protected void DestroySpawnedObject(GameObject _object) => Destroy(_object);
}