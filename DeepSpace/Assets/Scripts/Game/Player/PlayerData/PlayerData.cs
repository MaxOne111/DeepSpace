using System;
using UnityEngine;

[Serializable]
public sealed class PlayerData
{
    [SerializeField] private int _Gems;

    [SerializeField] private int _Free_Spins;

    [SerializeField] private MagnetBonus _Magnet_Bonus;
    [SerializeField] private BombBonus _Bomb_Bonus;
    [SerializeField] private DoubleGemsBonus _Gems_Bonus;

    [SerializeField] private float _Best_Score;

    [SerializeField] private int _Total_Gems;

    [SerializeField] private int _Total_Kills;

    [SerializeField] private int _Total_Bosses;

    [SerializeField] private int _Total_Deaths;

    public int FreeSpins => _Free_Spins;
    public MagnetBonus MagnetBonus => _Magnet_Bonus;
    public DoubleGemsBonus DoubleGemsBonus => _Gems_Bonus;
    public BombBonus BombBonus => _Bomb_Bonus;

    public float BestScore => _Best_Score;
    public int TotalGems => _Total_Gems;
    public int TotalKills => _Total_Kills;
    public int TotalBosses => _Total_Bosses;
    public int TotalDeaths => _Total_Deaths;
    public int Gems => _Gems;
    
    private int _Gems_Multiplier = 1;

    public event Action<int> _On_Gems_Changed;
    
    public void DefaultMultiplier() => _Gems_Multiplier = 1;

    public void SetMultiplier(int _value) => _Gems_Multiplier = _value;
    
    public void AddSpin()
    {
        _Free_Spins++;
        GameEvents.DataSaving();
    }

    public void SpendSpin()
    {
        if (_Free_Spins <= 0)
            return;
        
        _Free_Spins--;
        GameEvents.DataSaving();
    }

    public void AddKill()
    {
        _Total_Kills++;
        GameEvents.DataSaving();
    }

    public void AddGemScore(int _gems)
    {
        _Total_Gems += _gems;
        GameEvents.DataSaving();
    }

    public void AddBosses()
    {
        _Total_Bosses++;
        GameEvents.DataSaving();
    }

    public void AddDeaths()
    {
        _Total_Deaths++;
        GameEvents.DataSaving();
    }

    public void AddBonus(ActivableBonus _bonus, int _value)
    {
        if (_bonus is MagnetBonus)
            _Magnet_Bonus.AddCount(_value);
        else if (_bonus is BombBonus)
            _Bomb_Bonus.AddCount(_value);
        else if (_bonus is DoubleGemsBonus)
            _Gems_Bonus.AddCount(_value);
    }
    
    public void DefaultValues()
    {
        _Gems = 1000;
        
        _Magnet_Bonus = new MagnetBonus();
        _Magnet_Bonus.DefaultCount(3);

        _Gems_Bonus = new DoubleGemsBonus();
        _Gems_Bonus.DefaultCount(3);
        
        _Bomb_Bonus = new BombBonus();
        _Bomb_Bonus.DefaultCount(3);

        _Free_Spins = 3;

        _Total_Gems = _Gems;
    }
    
    public void AddGems(int _value)
    {
        if (_value < 0)
            return;

        _Gems += _value * _Gems_Multiplier;
        _On_Gems_Changed?.Invoke(_Gems);
    }

    public void SpendGems(int _value)
    {
        if (_value < 0 && _value > _Gems)
            return;

        _Gems -= _value;
        _On_Gems_Changed?.Invoke(_Gems);
    }

    public void CheckScore(float _score)
    {
        if (_score <= _Best_Score)
            return;

        _Best_Score = _score;
        GameEvents.DataSaving();
    }
    
}