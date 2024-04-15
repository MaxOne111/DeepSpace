using System;
using TMPro;
using UnityEngine;

public abstract class SkillDisplay : MonoBehaviour
{
    [SerializeField] private UpdatesPurchasing _Purchasing;
    [SerializeField] protected GameObject[] _Level_Icons;
    [SerializeField] protected TextMeshProUGUI _Price;

    protected PlayerSkills _Player_Skills;
    
    public abstract void ShowData();
    
    private void OnEnable() => _Purchasing._On_Purchased += ShowData;

    private void Start()
    {
        _Player_Skills = PlayerDataMediator.PlayerSkills;
        
        ShowData();
    }
    
    private void OnDisable() => _Purchasing._On_Purchased -= ShowData;
}