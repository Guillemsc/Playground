namespace Playground.Configuration.Stage
{
    public interface IEffectConfigurationVisitor
    {
        void Visit(ShipSpeedIncreaseEffectConfiguration visitor);
        void Visit(ShipSpeedDecreaseEffectConfiguration visitor);
    }
}
