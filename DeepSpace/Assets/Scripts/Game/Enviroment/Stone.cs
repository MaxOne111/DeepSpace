using System;
using System.Collections;
using UnityEngine;

public class Stone : MovableEnviroment, IPlayerDie
{
    [SerializeField] private Transform _Enemy_Spawn_Point;

    private Enemy _Robot;
    public Transform EnemySpawnPoint => _Enemy_Spawn_Point;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerProjectile _projectile))
        {
            if (_Enemy_Spawn_Point.childCount > 0)
            {
                _Robot = _Enemy_Spawn_Point.GetChild(0).GetComponent<Enemy>();
                _Robot.FallFromStone(_Transform);
                
                _Destruction?.Invoke(gameObject);
            }
                
        }
    }
}