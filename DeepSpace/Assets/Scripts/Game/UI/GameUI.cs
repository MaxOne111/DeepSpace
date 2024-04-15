using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class GameUI : MonoBehaviour
{
    private PlayerData _Player_Data;
    [Header("PlayerScripts")]
    [SerializeField] private PlayerMovement _Player_Movement;
    [SerializeField] private PlayerShooting _Player_Shooting;
    [Header("PlayerButtons")]
    [SerializeField] private PlayerMovementButton _Movement_Button;
    [SerializeField] private PlayerShootButton _Shooting_Button;
    [Header("PlayerBonusButtons")]
    [SerializeField] private PlayerBonusButton _Magnet_Button;
    [SerializeField] private PlayerBonusButton _Bomb_Button;
    [SerializeField] private PlayerBonusButton _Gems_Button;
    [Header("PlayerUI")]
    [SerializeField] private GameObject _Player_Fuel;
    [SerializeField] private Image _Fuel_Bar;
    [SerializeField] private Image _Normal_Fuel;
    [SerializeField] private Image _Critical_Fuel;
    [Header("RobotBossUI")]
    [SerializeField] private GameObject _Robot_Boss_Health;
    [SerializeField] private Image _Robot_Boss_Health_Bar;
    [Header("General")]
    [SerializeField] private TextMeshProUGUI _Score;
    [SerializeField] private TextMeshProUGUI _Gems_Count;
    [SerializeField] private Button _Pause_Button;
    [SerializeField] private GameObject _Pause_Menu;
    [SerializeField] private GameObject _Defeat_Panel;

    private void Awake() => ButtonsInit();

    private void ButtonsInit()
    {
        _Player_Data = PlayerDataMediator.PlayerData;
        
        _Movement_Button.Init(_Player_Movement);
        _Shooting_Button.Init(_Player_Shooting);

        _Magnet_Button.Init(_Player_Data.MagnetBonus, _Player_Movement, _Player_Movement.transform);
        _Bomb_Button.Init(_Player_Data.BombBonus);
        _Gems_Button.Init(_Player_Data.DoubleGemsBonus, _Player_Movement, _Player_Data);
    }

    private void OnEnable()
    {
        GameEvents._Boss_Apperaring += ShowRobotBossHealthBar;
        GameEvents._Boss_Apperaring += HidePlayerFuelBar;
        
        GameEvents._On_Boss_Defeated += HideRobotBossHealthBar;
        GameEvents._On_Boss_Defeated += ShowPlayerFuelBar;

        GameEvents._On_Paused += ShowPauseMenu;
        GameEvents._On_Continued += HidePauseMenu;

        _Player_Data._On_Gems_Changed += ShowGems;

        GameEvents._On_Player_Died += DefeatPanel;
        
        _Pause_Button.onClick.AddListener(GameEvents.OnPaused);
    }

    private void Start() => ShowGems(_Player_Data.Gems);
    
    
    public void PlayerFuel(float _current_Fuel, float _max_Fuel) => _Fuel_Bar.fillAmount = _current_Fuel / _max_Fuel;

    private void ShowRobotBossHealthBar() => _Robot_Boss_Health.SetActive(true);
    private void ShowPlayerFuelBar() => _Player_Fuel.SetActive(true);

    private void HideRobotBossHealthBar() => _Robot_Boss_Health.SetActive(false);
    private void HidePlayerFuelBar() => _Player_Fuel.SetActive(false);

    private void ShowPauseMenu() => _Pause_Menu.SetActive(true);
    private void HidePauseMenu() => _Pause_Menu.SetActive(false);

    private void ShowGems(int _value) => _Gems_Count.text = _value.ToString("0");

    private void DefeatPanel() => _Defeat_Panel.SetActive(true);

    public void RobotBossHealth(float _current_Health, float _max_Health) => _Robot_Boss_Health_Bar.fillAmount = _current_Health / _max_Health;

    public void CriticalFuelValue(float _current_Fuel, float _critical_Value)
    {
        if (_current_Fuel <= _critical_Value)
        {
            _Critical_Fuel.gameObject.SetActive(true);
            _Normal_Fuel.gameObject.SetActive(false);
            return;
        }
        
        _Critical_Fuel.gameObject.SetActive(false);
        _Normal_Fuel.gameObject.SetActive(true);
            
    }
    
    public void ScorePoints(float _points) => _Score.text = _points.ToString("000000000");

    private void OnDisable()
    {
        GameEvents._Boss_Apperaring -= ShowRobotBossHealthBar;
        GameEvents._Boss_Apperaring -= HidePlayerFuelBar;
        
        GameEvents._On_Boss_Defeated -= HideRobotBossHealthBar;
        GameEvents._On_Boss_Defeated -= ShowPlayerFuelBar;
        
        GameEvents._On_Paused -= ShowPauseMenu;
        GameEvents._On_Continued -= HidePauseMenu;
        
        _Player_Data._On_Gems_Changed -= ShowGems;
        
        GameEvents._On_Player_Died -= DefeatPanel;
        
        _Pause_Button.onClick.RemoveListener(GameEvents.OnPaused);
    }
}