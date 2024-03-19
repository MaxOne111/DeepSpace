using UnityEngine;

public class PlayerDisplay : MonoBehaviour
{
    [SerializeField] private PlayerCharacteristics _Player_Characteristics;
    [SerializeField] private ScoringPoints _Scoring;
    
    [SerializeField] private GameUI _Game_UI;

    private void OnEnable()
    {
        _Player_Characteristics._On_Fuel_Changed += FuelDisplay;
        _Player_Characteristics._On_Critical_Fuel_Value_Reached += CriticalFuelValueDisplay;

        _Scoring._On_Points_Changed += ScorePoints;
    }

    private void FuelDisplay(float _current_Fuel, float _max_Fuel)
    {
        if (!_Game_UI)
            return;
        
        _Game_UI.PlayerFuel(_current_Fuel, _max_Fuel);
    }

    private void CriticalFuelValueDisplay(float _current_Fuel, float _critical_Value)
    {
        if (!_Game_UI)
            return;
        
        _Game_UI.CriticalFuelValue(_current_Fuel, _critical_Value);
    }

    private void ScorePoints(float _points)
    {
        if (!_Scoring)
            return;
        
        _Game_UI.ScorePoints(_points);
    }
    
    private void OnDisable()
    {
        _Player_Characteristics._On_Fuel_Changed -= FuelDisplay;
        _Player_Characteristics._On_Critical_Fuel_Value_Reached -= CriticalFuelValueDisplay;
        
        _Scoring._On_Points_Changed -= ScorePoints;
    }
    
}