using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

[Serializable]
public sealed class MagnetBonus : ActivableBonus, IDuration
{
    private Transform _Player;

    private MonoBehaviour _Mono;
    
    private float _Duration = 10f;

    private float _Current_Time;

    private IEnumerator _Current_Coroutine;

    public float Duration => _Duration;
    public float CurrentTime => _Current_Time;

    public override void Init(MonoBehaviour _mono, Transform _player)
    {
        _Player = _player;
        _Mono = _mono;
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

        while (_Current_Time > 0)
        {
           MovableBonus[] _bonuses = Object.FindObjectsOfType<MovableBonus>();

           if (_bonuses.Length > 0)
           {
               for (int i = 0; i < _bonuses.Length; i++)
               {
                   _bonuses[i].transform.position = Vector3.Lerp(_bonuses[i].transform.position, _Player.position, 2 * Time.deltaTime);
               }
           }

           _Current_Time -= Time.deltaTime;

           yield return null;
        }

        _Current_Coroutine = null;
    }
    

    private bool HaveCoroutine()
    {
        if (_Current_Coroutine != null)
            return true;
            
        _Current_Coroutine = Effect();

        return false;
    }

    public override void UseBonus()
    {
        if (HaveCoroutine())
            return;
        
        _Mono.StartCoroutine(_Current_Coroutine);
    }
}