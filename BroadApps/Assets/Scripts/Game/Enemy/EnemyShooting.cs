using System;
using UnityEngine;

public sealed class EnemyShooting : MonoBehaviour
{
    [SerializeField] private Enemy _Characteristics;
    
    [SerializeField] private Transform _Shoot_Point;
    
    [SerializeField] private float _Fire_Rate;
    
    [SerializeField] private EnemyProjectile _Projectile;

    [SerializeField] private bool _Follow_Player;

    private Transform _Player;

    private float _Next_Fire;

    private void Start() => FindPlayer();

    private void FindPlayer() => _Player = GameObject.FindWithTag("Player")?.transform;

    private void OnEnable()
    {
        _Characteristics._On_Killed += ShootingDisable;
        GameEvents._On_Player_Died += ShootingDisable;
    }

    private void Shoot()
    {
        _Next_Fire = Time.time + 1f / _Fire_Rate;

        Quaternion _projectile_Rotation;

        if (_Follow_Player)
        {
            _projectile_Rotation = ProjectileRotation();
        }
        else
        {
            _projectile_Rotation = _Shoot_Point.rotation;
        }
        
        
        Instantiate(_Projectile, _Shoot_Point.position, _projectile_Rotation);
    }

    private Quaternion ProjectileRotation()
    {
        if (!_Player)
            return _Shoot_Point.rotation;

        Vector3 _projectile_Direction = _Player.position - _Shoot_Point.position;
        
        float _angle_Rotate = Mathf.Atan(_projectile_Direction.y/_projectile_Direction.x) * Mathf.Rad2Deg;
        
        Quaternion _start_Rotate = Quaternion.Euler(0,0,_angle_Rotate);

        return _start_Rotate;
    }

    private void ShootingDisable(GameObject _gameObject) => enabled = false;

    private void ShootingDisable() => enabled = false;

    private void Update()
    {
        if (Time.time < _Next_Fire)
            return;
        
        Shoot();
    }

    private void OnDisable()
    {
        _Characteristics._On_Killed -= ShootingDisable;
        GameEvents._On_Player_Died -= ShootingDisable;
    }
}