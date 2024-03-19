using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class BonusWheel : MonoBehaviour
{
    [SerializeField] private float _Max_Rotation_Speed;
    [SerializeField] private float _Min_Rotation_Speed;

    [SerializeField] private float _Braking;

    [SerializeField] private Transform _Wheel;

    [SerializeField] private BonusMark[] _Bonus_Marks;

    [SerializeField] private Transform _Wheel_Aim;

    [SerializeField] private int _Gift_Count;

    private float _Current_Rotation_Speed;

    public event Action _On_Spin_Started;
    public event Action _On_Spin_Finished;
    
    public event Action<string, Sprite, int> _On_Gift_Haved;

    private void Start() => FreeSpin();

    public void Spin() => StartCoroutine(Rotate());
    

    private IEnumerator Rotate()
    {
        if (PlayerDataMediator.PlayerData.FreeSpins <= 0)
            yield break;
        
        PlayerDataMediator.PlayerData.SpendSpin();
        
        _On_Spin_Started?.Invoke();
        
        _Current_Rotation_Speed = Random.Range(_Min_Rotation_Speed, _Max_Rotation_Speed);
        
        while (_Current_Rotation_Speed > 0)
        {
            _Wheel.Rotate(Vector3.forward * _Current_Rotation_Speed * Time.deltaTime);

            _Current_Rotation_Speed -= _Braking * Time.deltaTime;

            yield return null;
        }
        
        GiftBonus();
        
        _On_Spin_Finished?.Invoke();
    }

    private void GiftBonus()
    {
        Dictionary<float, Transform> _marks = new Dictionary<float, Transform>();

        for (int i = 0; i < _Bonus_Marks.Length; i++)
        {
            _marks.Add((_Bonus_Marks[i].transform.position - _Wheel_Aim.position).magnitude, _Bonus_Marks[i].transform);
        }

        float _min_Distance = _marks.Keys.Min();

        BonusMark _nearest_Mark = _marks[_min_Distance].GetComponent<BonusMark>();

        ActivableBonus _bonus = _nearest_Mark.GetBonusType();
        
        if (_bonus == null)
            return;

        PlayerDataMediator.PlayerData.AddBonus(_bonus, _Gift_Count);

        GameEvents.DataSaving();
        
        _On_Gift_Haved?.Invoke(_nearest_Mark.Config.Name, _nearest_Mark.Config.Icon, _Gift_Count);

    }

    private void FreeSpin()
    {
        int _today = DateTime.Now.Day;
        int _month = DateTime.Now.Month;

        int _saved_Day = PlayerPrefs.GetInt("Day", _today);
        int _saved_Month = PlayerPrefs.GetInt("Month", _month);

        if (_today > _saved_Day || _month > _saved_Month)
            PlayerDataMediator.PlayerData.AddSpin();
        
    }
    
}