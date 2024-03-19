using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefeatPanelUI : MonoBehaviour
{
    [SerializeField] private Button _Restart_Button;
    [SerializeField] private Button _Main_Menu_Button;
    
    [SerializeField] private TextMeshProUGUI _Gems;
    [SerializeField] private TextMeshProUGUI _Score;

    private void OnEnable()
    {
        _Restart_Button.onClick.AddListener(Restart);
        _Main_Menu_Button.onClick.AddListener(ToMainMenu);
        
        Active();
    }

    private void Active()
    {
        _Gems.text = PlayerDataMediator.PlayerData.Gems.ToString("0");
        _Score.text = PlayerDataMediator.PlayerData.BestScore.ToString("0");
    }
    
    public void ToMainMenu() => SceneManager.LoadScene(1);
    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    private void OnDisable()
    {
        _Restart_Button.onClick.RemoveListener(Restart);
        _Main_Menu_Button.onClick.RemoveListener(ToMainMenu);
    }
}
