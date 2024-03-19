using UnityEngine;

public class RobotSoldierFactory : EnemyFactory
{
    [SerializeField] private ObstacleFactory _Obstacle_Factory;

    [SerializeField] [Range(0, 100)] private float _Spawn_Chance;
    
    private void OnEnable()
    {
        _Obstacle_Factory._Creating += CreateSoldier;
        
        GameEvents._Boss_Apperaring += StopCreating;
        GameEvents._On_Boss_Defeated += StartCreating;
    }

    private void StopCreating() => _Obstacle_Factory._Creating -= CreateSoldier;

    private void StartCreating() => _Obstacle_Factory._Creating += CreateSoldier;


    private void CreateSoldier(Transform _transform)
    {
        float _chance = Random.Range(0, 100);

        if (_chance > _Spawn_Chance)
            return;
        
        RobotSoldier _instance = GetInstance(_transform.position) as RobotSoldier;
        _instance.Init(DestroySpawnedObject);
        
        _instance.transform.SetParent(_transform);
        _instance.transform.position = _transform.position;
    }
    
    private void OnDisable()
    {
        _Obstacle_Factory._Creating -= CreateSoldier;
        
        GameEvents._Boss_Apperaring -= StopCreating;
        GameEvents._On_Boss_Defeated -= StartCreating;
    }
}