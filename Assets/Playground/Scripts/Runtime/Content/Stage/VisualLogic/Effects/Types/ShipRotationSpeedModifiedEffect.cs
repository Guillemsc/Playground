using Juce.Core.Stats;
using Playground.Content.Stage.VisualLogic.Stats;

namespace Playground.Content.Stage.VisualLogic.Effects
{
    public class ShipRotationSpeedModifiedEffect : IEffect
    {
        private readonly ShipStats shipStats;

        private readonly StatModifier<float> speedStatModifier;

        public ShipRotationSpeedModifiedEffect(
            ShipStats shipStats,
            float ammount
            )
        {
            this.shipStats = shipStats;

            speedStatModifier = new StatModifier<float>(StatModificationType.AddAbsolute, ammount);
        }

        public void Enable()
        {
            shipStats.RotationSpeed.Add(speedStatModifier);
        }

        public void Disable()
        {
            shipStats.RotationSpeed.Remove(speedStatModifier);
        }
    }
}
