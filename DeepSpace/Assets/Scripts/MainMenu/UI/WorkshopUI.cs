using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkshopUI : MonoBehaviour
{
    [SerializeField] private UpdatesPurchasing _Purcasing;

    [SerializeField] private TextMeshProUGUI _Gems;

    [SerializeField] private Button _Jetpuck_Update_Button;
    [SerializeField] private Button _Max_Fuel_Update_Button;
    [SerializeField] private Button _Projectile_Damage_Update_Button;
    
    private void OnEnable()
    {
        PlayerDataMediator.PlayerData._On_Gems_Changed += ShowGems;
        
        _Jetpuck_Update_Button.onClick.AddListener(_Purcasing.BuyJetpackUpdate);
        _Max_Fuel_Update_Button.onClick.AddListener(_Purcasing.BuyMaxFuelUpdate);
        _Projectile_Damage_Update_Button.onClick.AddListener(_Purcasing.BuyProjectileDamageUpdate);
        
        ShowGems(PlayerDataMediator.PlayerData.Gems);
    }
    
    private void OnDisable()
    {
        PlayerDataMediator.PlayerData._On_Gems_Changed -= ShowGems;
        
        _Jetpuck_Update_Button.onClick.RemoveListener(_Purcasing.BuyJetpackUpdate);
        _Max_Fuel_Update_Button.onClick.RemoveListener(_Purcasing.BuyMaxFuelUpdate);
        _Projectile_Damage_Update_Button.onClick.RemoveListener(_Purcasing.BuyProjectileDamageUpdate);
    }

    private void ShowGems(int _value) => _Gems.text = _value.ToString("0");
}