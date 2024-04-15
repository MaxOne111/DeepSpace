using System;
using Object = UnityEngine.Object;

[Serializable]
public sealed class BombBonus : ActivableBonus
{
    private void Effect()
    {
        if (!HaveBonus())
            return;
        
        SpendBonus();

        RobotSoldier[] _enemies = Object.FindObjectsOfType<RobotSoldier>();

        if (_enemies.Length > 0)
        {
            for (int i = 0; i < _enemies.Length; i++)
            {
                Object.Destroy(_enemies[i].gameObject);
            }
        }
    }

    public override void UseBonus() => Effect();
}