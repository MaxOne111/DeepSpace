using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyBonusUI : MonoBehaviour
{
    [SerializeField] private BonusWheel _Bonus_Wheel;

    [SerializeField] private TextMeshProUGUI _Gems;

    [SerializeField] private TextMeshProUGUI _Free_Spins;
    
    [SerializeField] private Button _Spin_Button;

    [SerializeField] private GameObject _Gift_Panel;
    
    [SerializeField] private TextMeshProUGUI _Gift_Name;
    [SerializeField] private Image _Gift_Icon;

    private void OnEnable()
    {
        _Bonus_Wheel._On_Spin_Started += SpinButtonDisable;
        _Bonus_Wheel._On_Spin_Started += ShowFreeSpins;
        _Bonus_Wheel._On_Spin_Finished += SpinButtonEnable;

        _Bonus_Wheel._On_Gift_Haved += GiftData;

        PlayerDataMediator.PlayerData._On_Gems_Changed += ShowGems;
        
        _Spin_Button.onClick.AddListener(_Bonus_Wheel.Spin);
        
        ShowGems(PlayerDataMediator.PlayerData.Gems);
        ShowFreeSpins();
    }
    
    private void SpinButtonDisable() => _Spin_Button.interactable = false;

    private void SpinButtonEnable() => _Spin_Button.interactable = true;
    
    private void ShowGems(int _value) => _Gems.text = _value.ToString("0");
    private void ShowFreeSpins() => _Free_Spins.text = PlayerDataMediator.PlayerData.FreeSpins.ToString("0") + " free";

    private void GiftData(string _name, Sprite _icon, int _count)
    {
        _Gift_Panel.SetActive(true);
        
        _Gift_Name.text = $"+{_count} {_name} bonus";
        _Gift_Icon.sprite = _icon;
    }

    private void OnDisable()
    {
        _Bonus_Wheel._On_Spin_Started -= SpinButtonDisable;
        _Bonus_Wheel._On_Spin_Started -= ShowFreeSpins;
        _Bonus_Wheel._On_Spin_Finished -= SpinButtonEnable;
        
        _Bonus_Wheel._On_Gift_Haved -= GiftData;
        
        PlayerDataMediator.PlayerData._On_Gems_Changed -= ShowGems;
        
        _Spin_Button.onClick.RemoveListener(_Bonus_Wheel.Spin);
    }
}