using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerBonusButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private TextMeshProUGUI _Count;

    [SerializeField] private Image _Duration;
        
    private ActivableBonus _Bonus;

    private PlayerData _Player_Data;
    private MonoBehaviour _Mono;
    private Transform _Transform;

    public void Init(ActivableBonus _bonus)
    {
        _Bonus = _bonus;
        
        _Count.text = _Bonus.Count.ToString("0");
    }
    
    public void Init(ActivableBonus _bonus, MonoBehaviour _mono, PlayerData _player_Data)
    {
        _Bonus = _bonus;
        
        _bonus.Init(_mono, _player_Data);
        
        _Count.text = _Bonus.Count.ToString("0");
    }
    
    public void Init(ActivableBonus _bonus, MonoBehaviour _mono, Transform _transform)
    {
        _Bonus = _bonus;
        
        _bonus.Init(_mono, _transform);
        
        _Count.text = _Bonus.Count.ToString("0");
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        _Bonus.UseBonus();
        _Count.text = _Bonus.Count.ToString("0");
        
        StartCoroutine(BonusDurationDisplay());
    }

    private IEnumerator BonusDurationDisplay()
    {
        if (_Bonus is not IDuration)
            yield break;

        IDuration _duration = _Bonus as IDuration;

        while (_duration.CurrentTime > 0)
        {
            _duration.DisplayDuration(_Duration);

            yield return null;
        }
        
    }
    
}