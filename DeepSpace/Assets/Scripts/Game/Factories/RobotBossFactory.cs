
using System.Collections;
using UnityEngine;

public class RobotBossFactory : EnemyFactory
{
    private float _Offset_X = 2f;
    private float _Offset_Y = 2f;

    private Vector3 _Screen_Offset;
    private void OnEnable() => GameEvents._Boss_Apperaring += CreateBoss;

    private void CreateBoss()
    {
        _Screen_Offset = ScreenParams.ScreenLocal(_Offset_X, -_Offset_Y);
        
        Vector3 _spawn_Point = new Vector3(_Screen_Offset.x, -_Screen_Offset.y, 0);

        RobotBoss _instance = GetInstance(_spawn_Point) as RobotBoss;
        _instance.Init(DestroySpawnedObject);

        StartCoroutine(Appearance(_instance.transform));

    }

    private IEnumerator Appearance(Transform _transform)
    {
        Vector3 _position = new Vector3(_Screen_Offset.x, 0);
        
        while (_transform.position != _position)
        {
            _transform.position = Vector3.Lerp(_transform.position, _position, 2 * Time.deltaTime);
            yield return null;
        }
    }
    
    private void OnDisable() => GameEvents._Boss_Apperaring -= CreateBoss;
}