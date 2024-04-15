using System;

public class JetpackSkillDisplay : SkillDisplay
{
    public override void ShowData()
    {
        for (int i = 0; i < _Player_Skills.JetpackResponce.CurrentLevel; i++)
            _Level_Icons[i].SetActive(true);

        _Price.text = _Player_Skills.JetpackResponce.Price.ToString("0");
    }
}