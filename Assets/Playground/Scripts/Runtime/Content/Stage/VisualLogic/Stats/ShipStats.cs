using Juce.Core.Stats;

namespace Playground.Content.Stage.VisualLogic.Stats
{
    public class ShipStats
    {
        public FloatStat MovementMaxSpeed { get; }

        public ShipStats(
            FloatStat movementMaxSpeed
            )
        {
            MovementMaxSpeed = movementMaxSpeed;
        }
    }
}
