using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class ObstacleFactory : GenericFactory<Transform>
{
    [SerializeField] private float _Movement_Speed;
    [SerializeField] private float _Create_Delay;
    
    private bool _Is_Creating = true;

    public event Action<Transform> _Creating;

    private void Start() => StartCreate();
    
    private void StopCreate() => _Is_Creating = false;

    private void StartCreate() => StartCoroutine(Create());
    
    protected override Vector2 SpawnPoint()
    {
        int _screen_Parts = 2;

        float _height = _Border.y;

        float _width = _Border.x;

        float _spawn_Area = _height / _screen_Parts;

        float _spawn_Point = Random.Range(-_spawn_Area, _spawn_Area);

        Vector2 _area = new Vector3(_width, _spawn_Point);

        return _area;
    }
    
    private IEnumerator Create()
    {
        yield return new WaitForSeconds(_Create_Delay);

        _Border = ScreenParams.Border();
        
        _Is_Creating = true;
        
        while (_Is_Creating)
        {
            Stone _obstacle = GetInstance().GetComponent<Stone>();
            _obstacle.Init(_Movement_Speed, DestroySpawnedObject);

            _Creating?.Invoke(_obstacle.EnemySpawnPoint);

            yield return new WaitForSeconds(_Create_Delay);

            yield return null;
        }
    }
    
}