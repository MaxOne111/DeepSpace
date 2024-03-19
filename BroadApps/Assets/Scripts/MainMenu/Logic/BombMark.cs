public class BombMark : BonusMark
{
    private void Awake() => _Bonus = new BombBonus();
}