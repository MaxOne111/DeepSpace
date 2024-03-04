using System.Collections;
using UnityEngine;

public sealed class ObstacleFabric : GenericFabric<Transform>
{
    [SerializeField] private float _Create_Delay;
    [SerializeField] private Transform _Enviroment;
    private bool _Is_Createing = true;

    private Vector3 _Screen;

    protected override void Awake()
    {
        base.Awake();

        _Screen = new Vector3(Screen.width, Screen.height);

        _Screen = Camera.ScreenToWorldPoint(_Screen);
    }

    private void Start()
    {
        StartCoroutine(Create());
    }

    public void StopCreate()
    {
        _Is_Createing = false;
    }
    protected override Vector2 SpawnPoint()
    {
        int _screen_Parts = 2;
        float _x_Offset = 2f;
        
        float _height = _Screen.y;

        float _width = _Screen.x;

        float _spawn_Area = _height / _screen_Parts;

        float _spawn_Point = Random.Range(-_spawn_Area, _spawn_Area);

        Vector2 _area = new Vector3(_width + _x_Offset, _spawn_Point);

        return _area;
    }

    private IEnumerator Create()
    {
        while (_Is_Createing)
        {
            Transform _obstacle = GetInstance(_Enviroment);

            yield return new WaitForSeconds(_Create_Delay);

            yield return null;
        }
    }
}