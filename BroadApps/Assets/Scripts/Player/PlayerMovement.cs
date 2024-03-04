using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _Movement_Force;

    private bool _Is_Move;
    
    private Rigidbody2D _Rigidbody;

    private void Awake()
    {
        _Rigidbody = GetComponent<Rigidbody2D>();
    }

    private IEnumerator Move()
    {
        _Is_Move = true;
        
        while (_Is_Move)
        {
            _Rigidbody.AddForce(Vector2.up * _Movement_Force * Time.fixedDeltaTime, ForceMode2D.Force);

            yield return null;
        }
    }
    
    public void StartMove()
    {
        StartCoroutine(Move());
    }

    public void StopMove()
    {
        _Is_Move = false;
    }
}