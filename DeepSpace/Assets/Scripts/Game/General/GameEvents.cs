using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public static event Action _Boss_Apperaring;

    public static event Action _On_Boss_Defeated;

    public static event Action _Data_Saving;

    public static event Action _On_Paused;
    
    public static event Action _On_Continued;

    public static event Action _On_Player_Died;

    public static void BossAppearing()
    {
        _Boss_Apperaring?.Invoke();
    }
    
    public static void OnBossDefeated()
    {
        _On_Boss_Defeated?.Invoke();
    }

    public static void DataSaving()
    {
        _Data_Saving?.Invoke();
    }

    public static void OnPaused()
    {
        _On_Paused?.Invoke();
    }

    public static void OnContinued()
    {
        _On_Continued?.Invoke();
    }

    public static void OnPlayerDied()
    {
        _On_Player_Died?.Invoke();
    }

}
