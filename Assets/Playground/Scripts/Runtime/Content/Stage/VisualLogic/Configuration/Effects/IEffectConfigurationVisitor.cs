namespace Playground.Configuration.Stage
{
    public interface IEffectConfigurationVisitor
    {
        void Visit(ShipForwardSpeedIncreaseEffectConfiguration visitor);
        void Visit(ShipForwardSpeedDecreaseEffectConfiguration visitor);
        void Visit(ShipRotationSpeedIncreaseEffectConfiguration visitor);
        void Visit(ShipRotationSpeedDecreaseEffectConfiguration visitor);
    }
}
