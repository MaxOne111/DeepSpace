using System;
using BayatGames.SaveGameFree;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSettings _Settings;

    [SerializeField] private AudioSource _Music;
    [SerializeField] private AudioUI _UI;

    private void OnEnable()
    {
        _UI._Music_On += MusicOn;
        _UI._Music_Off += MusicOff;
        
        _UI._Vibration_On += VibrationOn;
        _UI._Vibration_Off += VibrationOff;
    }

    private void Start()
    {
        _Settings = PlayerDataMediator.AudioSettings;
        InstallSettings();
    }


    private void MusicOn()
    {
        _Settings.MusicOn();
        _Music.mute = _Settings.IsMusicMute;
        
        GameEvents.DataSaving();
    }

    private void MusicOff()
    {
        _Settings.MusicOff();
        _Music.mute = _Settings.IsMusicMute;
        
        GameEvents.DataSaving();
    }

    private void VibrationOn()
    {
        _Settings.VibrationOn();
        PhoneVibration.VibrationOn();
        
        GameEvents.DataSaving();
    }

    private void VibrationOff()
    {
        _Settings.VibrationOff();
        PhoneVibration.VibrationOff();
        
        GameEvents.DataSaving();
    }
    

    private void InstallSettings()
    {
        _Music.mute = _Settings.IsMusicMute;
    }
    
    private void OnDisable()
    {
        _UI._Music_On -= _Settings.MusicOn;
        _UI._Music_Off -= _Settings.MusicOff;
        
        _UI._Vibration_On -= VibrationOn;
        _UI._Vibration_Off -= VibrationOff;
    }
    
}