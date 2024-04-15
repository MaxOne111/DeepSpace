using System;
using System.Collections;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float _Movement_Speed;

    [SerializeField] protected float _Damage;
    
    protected Transform _Transform;
    
    public float Damage => _Damage;

    protected virtual void Awake()
    {
        _Transform = transform;
    }
    
    private void OnEnable()
    {
        StartCoroutine(Move());
    }

    protected abstract IEnumerator Move();
    

}