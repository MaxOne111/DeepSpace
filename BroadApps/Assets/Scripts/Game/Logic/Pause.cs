using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private void Awake() => GameContinue();

    private void OnEnable()
    {
        GameEvents._On_Paused += GamePause;
        GameEvents._On_Continued += GameContinue;
    }

    private void GamePause() => Time.timeScale = 0;

    private void GameContinue() => Time.timeScale = 1;
    
    private void OnDisable()
    {
        GameEvents._On_Paused -= GamePause;
        GameEvents._On_Continued -= GameContinue;
    }
}
