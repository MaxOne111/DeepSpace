using UnityEngine;

public class RobotBossDisplay : MonoBehaviour
{
    [SerializeField] private RobotBoss _Robot_Boss;

    private GameUI _Game_UI;

    private void Awake() => _Game_UI = GameObject.FindWithTag("GameUI").GetComponent<GameUI>();

    private void OnEnable() => _Robot_Boss._On_Health_Changed += HealthDisplay;

    private void HealthDisplay(float _current_Health, float _max_Health)
    {
        if (!_Game_UI)
            return;

        _Game_UI.RobotBossHealth(_current_Health, _max_Health);
    }

    private void OnDisable() => _Robot_Boss._On_Health_Changed -= HealthDisplay;

    private void OnDestroy() => _Robot_Boss._On_Health_Changed -= HealthDisplay;
}