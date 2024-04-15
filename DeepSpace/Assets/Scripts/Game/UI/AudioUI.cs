using System;
using UnityEngine;

public abstract class AudioUI : MonoBehaviour
{
    public event Action _Music_On;
    public event Action _Music_Off;
    
    public event Action _Vibration_On;
    public event Action _Vibration_Off;

    protected void MusicOn() => _Music_On?.Invoke();

    protected void MusicOff() => _Music_Off?.Invoke();
    
    protected void VibrationOn() => _Vibration_On?.Invoke();

    protected void VibrationOff() => _Vibration_Off?.Invoke();
}