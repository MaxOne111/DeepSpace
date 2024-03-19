using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(CompositeCollider2D))]
public abstract class Enemy : MonoBehaviour, IPlayerDie
{
    private Rigidbody2D _Rigidbody;
    private CompositeCollider2D _Collider;

    private Transform _Transform;

    public event Action<GameObject> _On_Killed;
    

    private Vector3 _Borders;

    private void Awake()
    {
        _Rigidbody = GetComponent<Rigidbody2D>();
        _Collider = GetComponent<CompositeCollider2D>();

        _Transform = transform;

        _Borders = ScreenParams.Border();
    }

    protected virtual void Start()
    {
        StartCoroutine(CheckPosition());
    }

    public void Init(Action<GameObject> _action)
    {
        _On_Killed += _action;
    }
    
    protected abstract void TakeDamage(float _damage);

    public void FallFromStone(Transform _parent)
    {
        _parent = null;
        transform.SetParent(_parent);

        _Collider.enabled = false;
        
        _Rigidbody.bodyType = RigidbodyType2D.Dynamic;
        
        PlayerDataMediator.PlayerData.AddKill();
    }

    public void Death()
    {
        _On_Killed?.Invoke(gameObject);
    }

    private IEnumerator CheckPosition()
    {
        while (_Transform.position.y > -_Borders.y)
        {
            yield return null;
        }
        
        Death();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerProjectile _projectile))
        {
            TakeDamage(_projectile.Damage);
        }
    }
    
    protected virtual void OnDisable()
    {
        _On_Killed = null;
    }

    protected virtual void OnDestroy()
    {
        _On_Killed = null;
    }
    
}