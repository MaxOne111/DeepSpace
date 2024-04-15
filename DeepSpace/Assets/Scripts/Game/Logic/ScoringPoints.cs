using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ScoringPoints : MonoBehaviour
{
    [SerializeField] private float _Points_Speed;

    [SerializeField] private int _Points_Step_For_Boss_Appearing;

    private int _Next_Iteration;

    private float _Current_Points = 0;

    public event Action<float> _On_Points_Changed;

    private bool _Is_Scoring = true;

    private bool _Boss_Appear;

    private void Start()
    {
        _Next_Iteration = _Points_Step_For_Boss_Appearing;
        
        StartCoroutine(Scoring());
    }

    private void OnEnable()
    {
        GameEvents._On_Boss_Defeated += NextIteration;
        GameEvents._On_Player_Died += CheckScore;
        GameEvents._On_Player_Died += StopScoring;
    }

    private void StopScoring() => _Is_Scoring = false;

    private IEnumerator Scoring()
    {
        while (_Is_Scoring)
        {
            if (_Current_Points >= _Next_Iteration)
            {
                _Current_Points = _Next_Iteration;
                GameEvents.BossAppearing();
                
                yield break;
            }
            
            _Current_Points += _Points_Speed * Time.deltaTime;
            _On_Points_Changed?.Invoke(_Current_Points);

            yield return null;
        }
        
    }

    private void CheckScore() => PlayerDataMediator.PlayerData.CheckScore(_Current_Points);

    private void NextIteration()
    {
        _Next_Iteration += _Points_Step_For_Boss_Appearing;

        StartCoroutine(Scoring());
    }

    private void OnDisable()
    {
        GameEvents._On_Boss_Defeated -= NextIteration;
        GameEvents._On_Player_Died -= CheckScore;
        GameEvents._On_Player_Died -= StopScoring;
    }
}
