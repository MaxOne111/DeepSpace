using UnityEngine;

public class SkillUpdate : MonoBehaviour
{
    private PlayerSkills _Player_Skills;

    [SerializeField] private float _Jetpack_Up_Value;
    [SerializeField] private float _Max_Fuel_Up_Value;
    [SerializeField] private float _Projectile_Damage_Up_Value;

    private void Start() => PlayerData();

    private void PlayerData() => _Player_Skills = PlayerDataMediator.PlayerSkills;

    public void MaxFuelUp()
    {
        MaxFuel _player_Max_Fuel = _Player_Skills.MaxFuel;

        if (_player_Max_Fuel.CurrentLevel >= _player_Max_Fuel.MaxLevel)
            return;

        _player_Max_Fuel.Fuel += _Max_Fuel_Up_Value;
        _player_Max_Fuel.CurrentLevel++;
        _player_Max_Fuel.Price += 1000;

        _Player_Skills.MaxFuel = _player_Max_Fuel;
        
        GameEvents.DataSaving();
    }
    
    public void JetpackUp()
    {
        JetpackResponce _player_Jetpack = _Player_Skills.JetpackResponce;

        if (_player_Jetpack.CurrentLevel >= _player_Jetpack.MaxLevel)
            return;

        _player_Jetpack.Responce += _Jetpack_Up_Value;
        _player_Jetpack.CurrentLevel++;
        _player_Jetpack.Price += 1000;
        
        _Player_Skills.JetpackResponce = _player_Jetpack;
        
        GameEvents.DataSaving();
    }
    
    public void ProjectileDamageUp()
    {
        ProjectileDamage _player_Projectile = _Player_Skills.ProjectileDamage;

        if (_player_Projectile.CurrentLevel >= _player_Projectile.MaxLevel)
            return;

        _player_Projectile.Damage += _Projectile_Damage_Up_Value;
        _player_Projectile.CurrentLevel++;
        _player_Projectile.Price += 1000;
        
        _Player_Skills.ProjectileDamage = _player_Projectile;
        
        GameEvents.DataSaving();
    }
}