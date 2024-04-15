using UnityEngine;

public sealed class Fuel : MovableBonus
{
    [SerializeField] private float _Fuel_Value;
    
    protected override void Accept(IBonusVisitor _visitor)
    {
        _visitor.Visit(this, _Fuel_Value);
    }
    
}