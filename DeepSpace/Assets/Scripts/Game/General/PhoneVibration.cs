using UnityEngine;

public static class PhoneVibration
{
    private static bool _Is_Vibration_On = true;

    public static void Vibrate()
    {
        if (!_Is_Vibration_On)
            return;

        Handheld.Vibrate();
    }

    public static void VibrationOn() => _Is_Vibration_On = true;
    public static void VibrationOff() => _Is_Vibration_On = false;
}