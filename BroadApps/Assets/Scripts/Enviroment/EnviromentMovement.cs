using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnviromentMovement : MonoBehaviour
{
    [SerializeField] private float _Movement_Speed;

    [SerializeField] private List<Transform> _Obstacle_Groups;

    private Transform _Transform;
    
    private Vector3 _Screen;
    
    private void Awake()
    {
        _Transform = transform;
        
        _Screen = new Vector3(Screen.width, Screen.height);

        _Screen = Camera.main.ScreenToWorldPoint(_Screen);
    }

    private void Start()
    {
        if (_Obstacle_Groups.Count < 2)
            Debug.LogException(new Exception("Minimum list length must be 2"));
        
    }

    private void Move()
    {
        _Transform.Translate(Vector3.left * _Movement_Speed * Time.deltaTime);
    }

    private void CheckPosition()
    {
        if (_Obstacle_Groups[0].position.x <= -_Screen.x * 2)
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        if (_Obstacle_Groups.Count < 2)
            return;
        
        Transform _first_Element = _Obstacle_Groups[0];
            
        ChangeParent(null);
        
        _Transform.position = Vector3.zero;

        float _step = Vector3.Distance(_first_Element.position, _Obstacle_Groups[1].position);
        
        _first_Element.position = new Vector3(_Obstacle_Groups[^1].position.x + _step, _first_Element.position.y);
        
        _Obstacle_Groups.Remove(_first_Element);
        _Obstacle_Groups.Add(_first_Element);

        ChangeParent(_Transform);
    }

    private void ChangeParent(Transform _parent)
    {
        for (int i = 0; i < _Obstacle_Groups.Count; i++)
            _Obstacle_Groups[i].SetParent(_parent);
    }

    private void Update()
    {
        Move();
        CheckPosition();
    }
}