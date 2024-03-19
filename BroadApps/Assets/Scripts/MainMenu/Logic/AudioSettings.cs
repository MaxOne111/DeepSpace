using System;
using UnityEngine;

[Serializable]
public class AudioSettings
{
    [field: SerializeField] public bool IsMusicMute { get; private set; }
    [field: SerializeField] public bool IsVibrationMute { get; private set; }
    
    public void MusicOn() => IsMusicMute = false;

    public void MusicOff() => IsMusicMute = true;
    
    public void VibrationOn() => IsVibrationMute = false;

    public void VibrationOff() => IsVibrationMute = true;
}