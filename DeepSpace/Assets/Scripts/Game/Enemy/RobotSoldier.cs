public class RobotSoldier : Enemy
{
    protected override void TakeDamage(float _damage)
    {
        Death();
        PlayerDataMediator.PlayerData.AddKill();
    }
}