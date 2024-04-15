public interface IBonusVisitor
{
    void Visit(Fuel _fuel, float _value);
    void Visit(Gem _gem, int _value);
}