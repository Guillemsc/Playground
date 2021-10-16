using Juce.Core.Stats;
using Playground.Content.Stage.VisualLogic.Stats;

namespace Playground.Content.Stage.VisualLogic.Effects
{
    public class ShipSpeedModifiedEffect : IEffect
    {
        private readonly ShipStats shipStats;

        private readonly StatModifier<float> speedStatModifier;

        public ShipSpeedModifiedEffect(
            ShipStats shipStats,
            float ammount
            )
        {
            this.shipStats = shipStats;

            speedStatModifier = new StatModifier<float>(StatModificationType.AddAbsolute, ammount);
        }

        public void Enable()
        {
            shipStats.MovementMaxSpeed.Add(speedStatModifier);
        }

        public void Disable()
        {
            shipStats.MovementMaxSpeed.Remove(speedStatModifier);
        }
    }
}
