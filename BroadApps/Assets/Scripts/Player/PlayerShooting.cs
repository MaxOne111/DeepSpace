
using System;
using UnityEngine;


public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Projectile _Bullet_Prefab;

    [SerializeField] private Transform _Shoot_Point;

    [SerializeField] private Transform _Projectile_Pool;

    private void Awake()
    {
        PoolInit();
    }

    private void PoolInit()
    {
        for (int i = 0; i < _Projectile_Pool.childCount; i++)
        {
            _Projectile_Pool.GetChild(i).GetComponent<Projectile>().Init(_Projectile_Pool, _Shoot_Point);
        }
    }

    public void Shoot()
    {
        Projectile _projectile = ObjectPool.PoolInstantiate( _Bullet_Prefab, _Shoot_Point, _Projectile_Pool);

        if (!_projectile)
            return;
        
        _projectile.Init(_Projectile_Pool, _Shoot_Point);
        
    }
    
}