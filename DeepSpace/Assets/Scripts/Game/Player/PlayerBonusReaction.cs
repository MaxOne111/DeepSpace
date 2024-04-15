using System;
using System.Collections;
using UnityEngine;

public class PlayerBonusReaction : MonoBehaviour, IBonusVisitor
{
    [SerializeField] private PlayerCharacteristics _Characteristics;
    
    public void Visit(Fuel _fuel, float _value)
    {
        _Characteristics.AddFuel(_value);
    }

    public void Visit(Gem _gem, int _value)
    {
        PlayerDataMediator.PlayerData.AddGems(_value);
        PlayerDataMediator.PlayerData.AddGemScore(_value);
    }
    
}