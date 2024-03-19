using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatesPurchasing : MonoBehaviour
{
    [SerializeField] private SkillUpdate _Skill_Update;

    private PlayerData _Player_Data;
    private PlayerSkills _Player_Skills;

    public event Action _On_Purchased;

    private void Start()
    {
        _Player_Data = PlayerDataMediator.PlayerData;
        _Player_Skills = PlayerDataMediator.PlayerSkills;
    }

    public void BuyJetpackUpdate()
    {
        if (_Player_Data.Gems < _Player_Skills.JetpackResponce.Price)
            return;
        
        _Player_Data.SpendGems(_Player_Skills.JetpackResponce.Price);
        _Skill_Update.JetpackUp();
        _On_Purchased?.Invoke();
    }
    
    public void BuyMaxFuelUpdate()
    {
        if (_Player_Data.Gems < _Player_Skills.MaxFuel.Price)
            return;
        
        _Player_Data.SpendGems(_Player_Skills.MaxFuel.Price);
        _Skill_Update.MaxFuelUp();
        _On_Purchased?.Invoke();
    }
    
    public void BuyProjectileDamageUpdate()
    {
        if (_Player_Data.Gems < _Player_Skills.ProjectileDamage.Price)
            return;
        
        _Player_Data.SpendGems(_Player_Skills.ProjectileDamage.Price);
        _Skill_Update.ProjectileDamageUp();
        _On_Purchased?.Invoke();
    }
}
