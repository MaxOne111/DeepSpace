using System;
using UnityEngine;

[Serializable]
public class PlayerSkills
{
    [SerializeField] private JetpackResponce _Jetpack_Responce;

    [SerializeField] private MaxFuel _Max_Fuel;

    [SerializeField] private ProjectileDamage _Projectile_Damage;


    public JetpackResponce JetpackResponce
    {
        get => _Jetpack_Responce;
        set => _Jetpack_Responce = value;
    }

    public MaxFuel MaxFuel
    {
        get => _Max_Fuel;
        set => _Max_Fuel = value;
    }

    public ProjectileDamage ProjectileDamage
    {
        get => _Projectile_Damage;
        set => _Projectile_Damage = value;
    }

    public void DefaultValues()
    {
        _Jetpack_Responce.Responce = 1;
        _Jetpack_Responce.MaxLevel = 6;
        _Jetpack_Responce.CurrentLevel = 1;
        _Jetpack_Responce.Price = 1000;

        _Max_Fuel.Fuel = 100;
        _Max_Fuel.MaxLevel = 6;
        _Max_Fuel.CurrentLevel = 1;
        _Max_Fuel.Price = 1000;
        
        _Projectile_Damage.Damage = 2.5f;
        _Projectile_Damage.MaxLevel = 6;
        _Projectile_Damage.CurrentLevel = 1;
        _Projectile_Damage.Price = 1000;
    }
}