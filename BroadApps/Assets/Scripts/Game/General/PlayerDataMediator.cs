using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerDataMediator
{
    public static PlayerData PlayerData { get; private set; }
    public static PlayerSkills PlayerSkills { get; private set; }
    public static AudioSettings AudioSettings { get; private set; }

    public static void LoadPlayerData(PlayerData _data) => PlayerData = _data;
    public static void LoadPlayerSkills(PlayerSkills _data) => PlayerSkills = _data;
    public static void LoadAudioSettings(AudioSettings _settings) => AudioSettings = _settings;
}
