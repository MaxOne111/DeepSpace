using System;
using System.IO;
using BayatGames.SaveGameFree;
using UnityEngine;

public sealed class SaveData : MonoBehaviour
{
    private const string _Player_Data_File_Name = "_playerData";
    private const string _Player_Skills_File_Name = "_playerSkills";
    private const string _Audio_Settings_File_Name = "_audio_Settings";
    
    [SerializeField] private PlayerData _Player_Data;
    [SerializeField] private PlayerSkills _Player_Skills;
    [SerializeField] private AudioSettings _Audio_Settings;
    
    private void Awake()
    {
        DetectPlayerDataSaveFile();
        DetectPlayerSkillsSaveFile();
        DetectAudioSettingsSaveFile();
        
        PlayerMediatorInit();
        Save();
    }

    private void OnEnable() => GameEvents._Data_Saving += Save;

    private void PlayerMediatorInit()
    {
        PlayerDataMediator.LoadPlayerData(_Player_Data);
        PlayerDataMediator.LoadPlayerSkills(_Player_Skills);
        PlayerDataMediator.LoadAudioSettings(_Audio_Settings);
    }
    
    private void DetectPlayerDataSaveFile()
    {
        if (SaveGame.Exists(_Player_Data_File_Name))
            _Player_Data = SaveGame.Load<PlayerData>(_Player_Data_File_Name);
        else
        {
            _Player_Data = new PlayerData();
            _Player_Data.DefaultValues();
        }
    }
    
    private void DetectPlayerSkillsSaveFile()
    {
        if (SaveGame.Exists(_Player_Skills_File_Name))
            _Player_Skills = SaveGame.Load<PlayerSkills>(_Player_Skills_File_Name);
        else
        {
            _Player_Skills = new PlayerSkills();
            _Player_Skills.DefaultValues();
        }
    }
    
    private void DetectAudioSettingsSaveFile()
    {
        if (SaveGame.Exists(_Audio_Settings_File_Name))
            _Audio_Settings = SaveGame.Load<AudioSettings>(_Audio_Settings_File_Name);
        else
        {
            _Audio_Settings = new AudioSettings();
            Save();
        }
    }
    
    private void Save()
    {
        SaveGame.Save(_Player_Data_File_Name, _Player_Data);
        SaveGame.Save(_Player_Skills_File_Name, _Player_Skills);
        SaveGame.Save(_Audio_Settings_File_Name, _Audio_Settings);
    }

    private void OnDisable() => GameEvents._Data_Saving -= Save;
}