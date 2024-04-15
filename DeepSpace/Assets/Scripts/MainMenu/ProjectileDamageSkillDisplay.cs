public class ProjectileDamageSkillDisplay : SkillDisplay
{
    public override void ShowData()
    {
        for (int i = 0; i < _Player_Skills.ProjectileDamage.CurrentLevel; i++)
            _Level_Icons[i].SetActive(true);
        
        _Price.text = _Player_Skills.ProjectileDamage.Price.ToString("0");
    }
}