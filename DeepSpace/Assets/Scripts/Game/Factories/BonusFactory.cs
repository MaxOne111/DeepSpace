using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class BonusFactory : GenericFactory<Transform>
{
    [SerializeField] private float _Movement_Speed;

    [SerializeField] private float _Create_Delay;

    [SerializeField] [Range(0, 100)] private float _Spawn_Chance;
    
    private bool _Is_Creating = true;

    private void OnEnable()
    {
        GameEvents._Boss_Apperaring += StopCreate;
        GameEvents._On_Boss_Defeated += StartCreate;
    }

    private void Start() => StartCreate();

    private void StartCreate() => StartCoroutine(Create());
    private void StopCreate() => _Is_Creating = false;

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

    protected override Quaternion StartRotation()
    {
        float _angle_Z = Random.Range(-30, 30);
        
        Quaternion _rotation = Quaternion.Euler(0,0, _angle_Z);

        return _rotation;
    }


    private IEnumerator Create()
    {
        yield return new WaitForSeconds(_Create_Delay);

        _Border = ScreenParams.Border();
        
        _Is_Creating = true;
        
        while (_Is_Creating)
        {
            float _chance = Random.Range(0, 100);

            if (_chance > _Spawn_Chance)
                yield return null;
            
            MovableBonus _instance = GetInstance().GetComponent<MovableBonus>();
            _instance.Init(_Movement_Speed, DestroySpawnedObject);

            yield return new WaitForSeconds(_Create_Delay);

            yield return null;
            
        }
        
    }
    
    private void OnDisable()
    {
        GameEvents._Boss_Apperaring -= StopCreate;
        GameEvents._On_Boss_Defeated -= StartCreate;
    }
}