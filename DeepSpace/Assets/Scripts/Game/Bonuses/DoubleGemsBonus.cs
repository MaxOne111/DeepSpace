using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public sealed class DoubleGemsBonus : ActivableBonus, IDuration
{
    private float _Duration = 10f;
    private int _Value = 2;

    private float _Current_Time;

    private MonoBehaviour _Mono;
    private PlayerData _Player_Data;

    public float Duration => _Duration;
    public float CurrentTime => _Current_Time;

    public override void Init(MonoBehaviour _mono, PlayerData _player_Data)
    {
        _Player_Data = _player_Data;
        _Mono = _mono;
    }

    public override void UseBonus()
    {
        _Mono.StartCoroutine(Effect());
    }
    
    public void DisplayDuration(Image _bar)
    {
        _bar.fillAmount = _Current_Time / _Duration;
    }
    
    private IEnumerator Effect()
    {
        if (!HaveBonus())
            yield break;
        
        SpendBonus();

        _Current_Time = _Duration;
        
        _Player_Data.SetMultiplier(_Value);

        while (_Current_Time > 0)
        {
            _Current_Time -= Time.deltaTime;

            yield return null;
        }
        
        _Player_Data.DefaultMultiplier();
    }
    
    

   
}

