using System;
using UnityEngine;

public sealed class RobotBoss : Enemy
{
    [SerializeField] private float _Max_Health;
    
    private float _Current_Health;

    public event Action<float, float> _On_Health_Changed; 

    private void OnEnable()
    {
        _On_Killed += Defeat;
    }

    protected override void Start()
    {
        base.Start();
        _Current_Health = _Max_Health;
        
        _On_Health_Changed?.Invoke(_Current_Health, _Max_Health);
    }

    private void Defeat(GameObject _gameObject) => GameEvents.OnBossDefeated();

    protected override void TakeDamage(float _damage)
    {
        if (_Current_Health - _damage <= 0)
        {
            _Current_Health = 0;
            
            _On_Health_Changed?.Invoke(_Current_Health, _Max_Health);
            
            Death();
            
            PlayerDataMediator.PlayerData.AddBosses();

            return;
        }
        
        _Current_Health -= _damage;
        _On_Health_Changed?.Invoke(_Current_Health, _Max_Health);
    }
}