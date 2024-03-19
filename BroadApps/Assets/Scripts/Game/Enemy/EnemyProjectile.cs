using System.Collections;
using UnityEngine;

public class EnemyProjectile : Projectile, IPlayerDie
{
    private Vector3 _Border;
    protected override void Awake()
    {
        base.Awake();
        _Border = ScreenParams.Border();
    }

    protected override IEnumerator Move()
    {
        while (_Transform.position.x > -_Border.x)
        {
            _Transform.Translate(Vector3.left * (_Movement_Speed * Time.deltaTime));

            yield return null;
        }
        
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out EnemyShooting _enemy) || col.TryGetComponent(out IPlayerDie _object))
            return;
        
        Destroy(gameObject);
    }
}