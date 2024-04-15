using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanelUI : AudioUI
{
    [SerializeField] private Button _Continue_Button;
    [SerializeField] private Button _Main_Menu_Button;

    [SerializeField] private Toggle _Music_Toggle;
    [SerializeField] private Toggle _Vibration_Toggle;

    private void Start()
    {
        _Music_Toggle.isOn = !PlayerDataMediator.AudioSettings.IsMusicMute;
        _Vibration_Toggle.isOn = !PlayerDataMediator.AudioSettings.IsVibrationMute;
    }

    private void OnEnable()
    {
        _Continue_Button.onClick.AddListener(GameEvents.OnContinued);
        _Main_Menu_Button.onClick.AddListener(ToMainMenu);
        
        
        _Music_Toggle.onValueChanged.AddListener(delegate { SwitchMusic(_Music_Toggle); });
        _Vibration_Toggle.onValueChanged.AddListener(delegate { SwitchVibration(_Vibration_Toggle); });
    }

    public void ToMainMenu() => SceneManager.LoadScene(1);

    private void SwitchMusic(Toggle _toggle)
    {
        if (_toggle.isOn)
        {
            MusicOn();
            return;
        }
        MusicOff();
        
    }

    private void SwitchVibration(Toggle _toggle)
    {
        if (_toggle.isOn)
        {
            VibrationOn();
            return;
        }
        VibrationOff();
    }
    
    private void OnDisable()
    {
        _Continue_Button.onClick.RemoveListener(GameEvents.OnContinued);
        _Main_Menu_Button.onClick.RemoveListener(ToMainMenu);

        _Music_Toggle.onValueChanged.RemoveListener(delegate { SwitchMusic(_Music_Toggle); });
        _Vibration_Toggle.onValueChanged.RemoveListener(delegate { SwitchVibration(_Vibration_Toggle); });
    }
}