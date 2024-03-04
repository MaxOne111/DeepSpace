using System;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private PlayerMovement _Player_Movement;
    [SerializeField] private PlayerShooting _Player_Shooting;

    [SerializeField] private PlayerMovementButton _Movement_Button;
    [SerializeField] private PlayerShootButton _Shooting_Button;

    private void Awake()
    {
        _Movement_Button.Init(_Player_Movement);
        _Shooting_Button.Init(_Player_Shooting);
    }
}