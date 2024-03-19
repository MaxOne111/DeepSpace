using System;
using UnityEngine;

public class BonusMark : MonoBehaviour
{
    [SerializeField] private BonusMarkConfig _Config;
    protected ActivableBonus _Bonus;

    public BonusMarkConfig Config => _Config;

    public ActivableBonus GetBonusType() => _Bonus;

}