using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Background : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _Background;
    [SerializeField] private Sprite[] _Levels;

    private void Start()
    {
        StartBackground();
    }

    private void StartBackground()
    {
        int _index;
        
        if (_Levels.Length > 1)
            _index = Random.Range(0, _Levels.Length);
        else
        {
            _index = 0;
        }

        _Background.sprite = _Levels[_index];
    }
}
