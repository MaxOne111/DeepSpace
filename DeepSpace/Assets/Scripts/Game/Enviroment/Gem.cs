using UnityEngine;

public sealed class Gem : MovableBonus
{
    [SerializeField] private int _Value;
    protected override void Accept(IBonusVisitor _visitor)
    {
        _visitor.Visit(this, _Value);
    }
}