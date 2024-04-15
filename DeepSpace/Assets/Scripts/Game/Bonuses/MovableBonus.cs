using System;
using UnityEngine;

public abstract class MovableBonus : MovableEnviroment
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out IBonusVisitor _visitor))
        {
            Accept(_visitor);
            _Destruction?.Invoke(gameObject);
        }
    }
    
    protected abstract void Accept(IBonusVisitor _visitor);

}