using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _Movement_Force;
    
    [SerializeField] private float _Fuel_Сonsumption;

    [SerializeField] private PlayerCharacteristics _Player_Characteristics;

    [SerializeField] private float _Jetpack_Responce;

    private Transform _Transform;

    private float _Current_Fuel_Сonsumption;

    private bool _Is_Move;
    
    private Rigidbody2D _Rigidbody;

    private void Awake()
    {
        _Rigidbody = GetComponent<Rigidbody2D>();

        _Transform = transform;
    }

    private void OnEnable()
    {
        GameEvents._Boss_Apperaring += NoFuelСonsumption;
        GameEvents._On_Boss_Defeated += HaveFuelСonsumption;
        GameEvents._On_Player_Died += StopMove;
    }

    private void Start()
    {
        HaveFuelСonsumption();
        StartCoroutine(CheckPosition());

        _Rigidbody.bodyType = RigidbodyType2D.Kinematic;

        _Jetpack_Responce = PlayerDataMediator.PlayerSkills.JetpackResponce.Responce;
    }

    private IEnumerator Move()
    {
        _Rigidbody.bodyType = RigidbodyType2D.Dynamic;
        
        _Is_Move = true;
        
        while (_Is_Move && _Player_Characteristics.CurrentFuel > 0)
        {
            _Rigidbody.AddForce(Vector2.up * _Movement_Force * _Jetpack_Responce * Time.deltaTime, ForceMode2D.Force);
            
            _Player_Characteristics.FuelСonsumption(_Current_Fuel_Сonsumption);

            yield return null;
        }
    }
    
    private IEnumerator CheckPosition()
    {
        while (_Transform.position.y > -ScreenParams.ScreenLocal(0,0).y)
        {
            yield return null;
        }
        
        _Player_Characteristics.Death();
    }

    private void NoFuelСonsumption() => _Current_Fuel_Сonsumption = 0;

    private void HaveFuelСonsumption() => _Current_Fuel_Сonsumption = _Fuel_Сonsumption;

    public void StartMove() => StartCoroutine(Move());

    public void StopMove() => _Is_Move = false;

    private void OnDisable()
    {
        GameEvents._Boss_Apperaring -= NoFuelСonsumption;
        GameEvents._On_Boss_Defeated -= HaveFuelСonsumption;
        GameEvents._On_Player_Died -= StopMove;
    }
}