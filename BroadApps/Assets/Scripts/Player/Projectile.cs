using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _Movement_Speed;

    private Transform _Transform;
    private Transform _Projectile_Pool;
    private Transform _Shoot_Point;

    private void Awake()
    {
        _Transform = transform;
    }
    
    public void Init(Transform _pool, Transform _shoot_Point)
    {
        _Projectile_Pool = _pool;
        _Shoot_Point = _shoot_Point;
    }

    private void OnEnable()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (true)
        {
            _Transform.Translate(Vector3.right * _Movement_Speed * Time.deltaTime);

            yield return null;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerShooting _player))
            return;
        
        ObjectPool.ReturnToPool(_Transform, _Projectile_Pool, _Shoot_Point);
    }
    
}