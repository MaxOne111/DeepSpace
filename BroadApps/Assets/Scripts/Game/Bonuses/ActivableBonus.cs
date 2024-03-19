using System;
using UnityEngine;

[Serializable]
public abstract class ActivableBonus
{
    [SerializeField] private int _Count;

    public int Count => _Count;

    public void DefaultCount(int _count)
    {
        _Count = _count;
    }

    public void AddCount(int _value)
    {
        if (_value < 0)
            return;

        _Count += _value;
    }

    public abstract void UseBonus();
    
    public virtual void Init(){}
    public virtual void Init(MonoBehaviour _mono, Transform _transform){}
    public virtual void Init(MonoBehaviour _mono, PlayerData _player_Data){}

    protected void SpendBonus()
    {
        if (_Count == 0)
            return;

        _Count--;
        
        GameEvents.DataSaving();
    }

    protected bool HaveBonus()
    {
        if (_Count > 0)
            return true;

        return false;
    }
}