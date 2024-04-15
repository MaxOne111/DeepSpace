using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayerMovementButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private PlayerMovement _Player;

    private void OnEnable() => GameEvents._On_Player_Died += StopMovement;


    public void Init(PlayerMovement _player)
    {
        _Player = _player;
    }

    private void StopMovement()
    {
        _Player = null;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_Player || !_Player.gameObject.activeSelf)
            return;
        
        _Player.StartMove();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!_Player || !_Player.gameObject.activeSelf)
            return;
        
        _Player.StopMove();
    }

    private void OnDisable() => GameEvents._On_Player_Died -= StopMovement;
}