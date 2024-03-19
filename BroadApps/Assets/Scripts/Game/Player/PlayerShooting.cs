
using System;
using UnityEngine;


public sealed class PlayerShooting : MonoBehaviour
{
    [SerializeField] private PlayerProjectile _Bullet_Prefab;

    [SerializeField] private Transform _Shoot_Point;

    [SerializeField] private Transform _Projectile_Pool;

    private void Awake() => PoolInit();

    private void PoolInit()
    {
        for (int i = 0; i < _Projectile_Pool.childCount; i++)
        {
            _Projectile_Pool.GetChild(i).GetComponent<PlayerProjectile>().Init(_Projectile_Pool, _Shoot_Point);
        }
    }

    public void Shoot()
    {
        PlayerProjectile _projectile = ObjectPool.PoolInstantiate( _Bullet_Prefab, _Shoot_Point, _Projectile_Pool);

        if (!_projectile)
            return;
        
        _projectile.Init(_Projectile_Pool, _Shoot_Point);
        
    }

}