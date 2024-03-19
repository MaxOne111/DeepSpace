using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public sealed class PlayerCharacteristics : MonoBehaviour
{
    [SerializeField] private float _Max_Fuel;
    
    [Range(0,1)]
    [SerializeField] private float _Critical_Fuel_Value;

    [SerializeField] private bool _God_Mode;

    [SerializeField] private ParticleSystem _Collision_Explosion;

    private float _Current_Fuel;

    private CircleCollider2D _Collider;

    private bool _Is_Alive = true;

    public float CurrentFuel => _Current_Fuel;
    
    public event Action<float, float> _On_Fuel_Changed;
    public event Action<float, float> _On_Critical_Fuel_Value_Reached;

    private void Awake() => _Collider = GetComponent<CircleCollider2D>();

    private void Start()
    {
        _Max_Fuel = PlayerDataMediator.PlayerSkills.MaxFuel.Fuel;
        _Current_Fuel = _Max_Fuel;
    }
    
    public void Death()
    {
        if(!_Is_Alive)
            return;
        
        PhoneVibration.Vibrate();
        
        _Is_Alive = false;
            
        _Collider.enabled = false;

        Instantiate(_Collision_Explosion, transform.position, Quaternion.identity);
        
        gameObject.SetActive(false);
        
        GameEvents.OnPlayerDied();
        PlayerDataMediator.PlayerData.AddDeaths();
    }
    
    public void FuelСonsumption(float _consumption)
    {
        _Current_Fuel -= _consumption * Time.deltaTime;
        _On_Fuel_Changed?.Invoke(_Current_Fuel, _Max_Fuel);

        if (_Current_Fuel <= _Max_Fuel * _Critical_Fuel_Value)
            _On_Critical_Fuel_Value_Reached?.Invoke(_Current_Fuel, _Max_Fuel * _Critical_Fuel_Value);
    }

    public void AddFuel(float _value)
    {
        if (_Current_Fuel + _value >= _Max_Fuel)
        {
            _Current_Fuel = _Max_Fuel;
        }
        else
        {
            _Current_Fuel += _value;
        }
        
        _On_Fuel_Changed?.Invoke(_Current_Fuel, _Max_Fuel);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out IPlayerDie _object) && !_God_Mode)
        {
            Death();
        }
    }
}