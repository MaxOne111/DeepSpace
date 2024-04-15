using UnityEngine;

[CreateAssetMenu(menuName = "BonusMarkConfig", fileName = "BonusMarkConfig", order = 0)]
public class BonusMarkConfig : ScriptableObject
{
    [SerializeField] private string _Name;
    [SerializeField] private Sprite _Icon;

    public string Name => _Name;
    public Sprite Icon => _Icon;
}