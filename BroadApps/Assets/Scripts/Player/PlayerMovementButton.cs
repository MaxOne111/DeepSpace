using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayerMovementButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private PlayerMovement _Player;

    public void Init(PlayerMovement _player)
    {
        _Player = _player;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        _Player.StartMove();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _Player.StopMove();
    }
}