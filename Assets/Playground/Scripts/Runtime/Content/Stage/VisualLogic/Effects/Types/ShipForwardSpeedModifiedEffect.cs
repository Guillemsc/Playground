using Juce.Core.Stats;
using Playground.Content.Stage.VisualLogic.Stats;

namespace Playground.Content.Stage.VisualLogic.Effects
{
    public class ShipForwardSpeedModifiedEffect : IEffect
    {
        private readonly ShipStats shipStats;

        private readonly StatModifier<float> speedStatModifier;

        public ShipForwardSpeedModifiedEffect(
            ShipStats shipStats,
            float ammount
            )
        {
            this.shipStats = shipStats;

            speedStatModifier = new StatModifier<float>(StatModificationType.AddAbsolute, ammount);
        }

        public void Enable()
        {
            shipStats.ForwardMaxSpeed.Add(speedStatModifier);
        }

        public void Disable()
        {
            shipStats.ForwardMaxSpeed.Remove(speedStatModifier);
        }
    }
}
