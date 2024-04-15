using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : AudioUI
{
    [SerializeField] private GeneralSettings generalSettings;
    
    [SerializeField] private Button _Open_Store_Button;

    [SerializeField] private Button _Music_On_Button;
    [SerializeField] private Button _Music_Off_Button;
    
    [SerializeField] private Button _Vibration_On_Button;
    [SerializeField] private Button _Vibration_Off_Button;

    private void OnEnable()
    {
        _Open_Store_Button.onClick.AddListener(generalSettings.OpenStore);
        
        _Music_On_Button.onClick.AddListener(MusicOff);
        _Music_Off_Button.onClick.AddListener(MusicOn);
        
        _Vibration_On_Button.onClick.AddListener(VibrationOff);
        _Vibration_Off_Button.onClick.AddListener(VibrationOn);
    }

    private void OnDisable()
    {
        _Open_Store_Button.onClick.AddListener(generalSettings.OpenStore);
        
        _Music_On_Button.onClick.RemoveListener(MusicOff);
        _Music_Off_Button.onClick.RemoveListener(MusicOn);
        
        _Vibration_On_Button.onClick.RemoveListener(VibrationOff);
        _Vibration_Off_Button.onClick.RemoveListener(VibrationOn);
    }
}
