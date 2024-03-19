using System;
using UnityEngine;

[Serializable]
public struct JetpackResponce
{
    [SerializeField] public float Responce;
    [SerializeField] public int CurrentLevel;
    [SerializeField] public int MaxLevel;
    [SerializeField] public int Price;
}