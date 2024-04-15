using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class EnemyFactory : GenericFactory<Transform>
{
    
    protected new Enemy GetInstance() => base.GetInstance().GetComponent<Enemy>();

    protected new Enemy GetInstance(Vector3 _position) => base.GetInstance(_position).GetComponent<Enemy>();
}