public class MaxFuelSkillDisplay : SkillDisplay
{
    public override void ShowData()
    {
        for (int i = 0; i < _Player_Skills.MaxFuel.CurrentLevel; i++)
            _Level_Icons[i].SetActive(true);
        
        _Price.text = _Player_Skills.MaxFuel.Price.ToString("0");
    }
}