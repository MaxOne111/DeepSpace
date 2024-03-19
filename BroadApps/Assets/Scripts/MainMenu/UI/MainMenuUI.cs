using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    private PlayerData _Player_Data;

    [SerializeField] private Button _Play_Game_Button;
    
    [SerializeField] private TextMeshProUGUI _Gems_Count;
    
    [SerializeField] private TextMeshProUGUI _Best_Score;
    [SerializeField] private TextMeshProUGUI _Total_Gems;
    [SerializeField] private TextMeshProUGUI _Total_Kills;
    [SerializeField] private TextMeshProUGUI _Total_Bosses;
    [SerializeField] private TextMeshProUGUI _Total_Deaths;
    
    [SerializeField] private TextMeshProUGUI _Magnet_Bonus_Count;
    [SerializeField] private TextMeshProUGUI _Bomb_Bonus_Count;
    [SerializeField] private TextMeshProUGUI _Double_Gem_Bonus_Count;

    private void Awake() => _Player_Data = PlayerDataMediator.PlayerData;

    private void OnEnable()
    {
        ShowGemsCount();
        
        ShowBestScore();
        ShowTotalGems();
        ShowTotalKills();
        ShowTotalBosses();
        ShowTotalDeaths();
        
        ShowMagnetBonusCount();
        ShowBombBonusCount();
        ShowDoubleGemShowCount();
        
        _Play_Game_Button.onClick.AddListener(StartPlay);
    }

    private void StartPlay() => SceneManager.LoadScene(2);

    private void ShowGemsCount() => _Gems_Count.text = _Player_Data.Gems.ToString("0");
    private void ShowBestScore() => _Best_Score.text = _Player_Data.BestScore.ToString("0");
    private void ShowTotalGems() => _Total_Gems.text = _Player_Data.TotalGems.ToString("0");
    private void ShowTotalKills() => _Total_Kills.text = _Player_Data.TotalKills.ToString("0");
    private void ShowTotalBosses() => _Total_Bosses.text = _Player_Data.TotalBosses.ToString("0");
    private void ShowTotalDeaths() => _Total_Deaths.text = _Player_Data.TotalDeaths.ToString("0");

    private void ShowMagnetBonusCount()
    {
        _Magnet_Bonus_Count.text = _Player_Data.MagnetBonus.Count.ToString("0");
    }

    private void ShowBombBonusCount()
    {
        _Bomb_Bonus_Count.text = _Player_Data.BombBonus.Count.ToString("0");
    }

    private void ShowDoubleGemShowCount()
    {
        _Double_Gem_Bonus_Count.text = _Player_Data.DoubleGemsBonus.Count.ToString("0");
    }

    private void OnDisable() => _Play_Game_Button.onClick.RemoveListener(StartPlay);
}
