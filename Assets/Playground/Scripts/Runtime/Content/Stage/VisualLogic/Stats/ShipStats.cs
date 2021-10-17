using Juce.Core.Stats;

namespace Playground.Content.Stage.VisualLogic.Stats
{
    public class ShipStats
    {
        public FloatStat ForwardMaxSpeed { get; }
        public FloatStat RotationSpeed { get; }

        public ShipStats(
            FloatStat forwardMaxSpeed,
            FloatStat rotationSpeed
            )
        {
            ForwardMaxSpeed = forwardMaxSpeed;
            RotationSpeed = rotationSpeed;
        }
    }
}
