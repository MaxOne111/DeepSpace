using System;
using UnityEngine;

[Serializable]
public struct MaxFuel
{
    [SerializeField] public float Fuel;
    [SerializeField] public int CurrentLevel;
    [SerializeField] public int MaxLevel;
    [SerializeField] public int Price;
}