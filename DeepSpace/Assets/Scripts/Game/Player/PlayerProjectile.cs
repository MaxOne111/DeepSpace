using System;
using System.Collections;
using UnityEngine;

public class PlayerProjectile : Projectile
{
    [SerializeField] private ParticleSystem _Projectile_Explosion;
    
    private Transform _Projectile_Pool;
    private Transform _Shoot_Point;

    private void Start() => _Damage = PlayerDataMediator.PlayerSkills.ProjectileDamage.Damage;

    public void Init(Transform _pool, Transform _shoot_Point)
    {
        _Projectile_Pool = _pool;
        _Shoot_Point = _shoot_Point;
        _Damage = PlayerDataMediator.PlayerSkills.ProjectileDamage.Damage;
    }

    protected override IEnumerator Move()
    {
        while (true)
        {
            _Transform.Translate(Vector3.right * (_Movement_Speed * Time.deltaTime));

            yield return null;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerShooting _player))
            return;
        
        Instantiate(_Projectile_Explosion, _Transform.position, Quaternion.identity);
        ObjectPool.ReturnToPool(_Transform, _Projectile_Pool, _Shoot_Point);
    }
}