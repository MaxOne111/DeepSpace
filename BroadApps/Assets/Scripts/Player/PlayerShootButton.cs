using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerShootButton : MonoBehaviour, IPointerDownHandler
{
    private PlayerShooting _Player;

    public void Init(PlayerShooting _player)
    {
        _Player = _player;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        _Player.Shoot();
    }
    
}