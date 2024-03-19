using System;
using UnityEngine;

[Serializable]
public struct ProjectileDamage
{
    [SerializeField] public float Damage;
    [SerializeField] public int CurrentLevel;
    [SerializeField] public int MaxLevel;
    [SerializeField] public int Price;
}