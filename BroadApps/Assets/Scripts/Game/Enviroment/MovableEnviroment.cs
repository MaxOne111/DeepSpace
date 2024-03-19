using System;
using System.Collections;
using UnityEngine;

public class MovableEnviroment : MonoBehaviour
{
    private float _Movement_Speed;

    private bool _Is_Moving = true;

    public event Action<GameObject> _On_Out_Of_Border;
    protected Action<GameObject> _Destruction;

    protected Transform _Transform;
    
    private Vector3 _Screen;

    private void Awake()
    {
        _Transform = transform;

        _Screen = ScreenParams.Border();
    }
    
    private void Start() => StartMove();

    private void StartMove() => StartCoroutine(Move());

    private void StopMove() => _Is_Moving = false;

    public void Init(float _movement_Speed, Action<GameObject> _action)
    {
        _Movement_Speed = _movement_Speed;
        _On_Out_Of_Border += _action;

        _Destruction += _action;
    }

    private IEnumerator Move()
    {
        _Is_Moving = true;
        
        while (_Is_Moving)
        {
            if (_Transform.position.x <= -_Screen.x)
                _On_Out_Of_Border?.Invoke(gameObject);
            
            _Transform.Translate(Vector3.left * (_Movement_Speed * Time.deltaTime), Space.World);

            yield return null;

        }
    }

    private void OnDisable()
    {
        _On_Out_Of_Border = null;
        _Destruction = null;
    }

    private void OnDestroy()
    {
        _On_Out_Of_Border = null;
        _Destruction = null;
    }
}