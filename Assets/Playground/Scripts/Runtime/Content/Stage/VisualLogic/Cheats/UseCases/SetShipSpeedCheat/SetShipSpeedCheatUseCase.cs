using Juce.Core.Stats;
using Playground.Content.Stage.VisualLogic.Stats;

namespace Playground.Content.Stage.VisualLogic.Cheats.UseCases.SetShipSpeedCheat
{
    public class SetShipSpeedCheatUseCase : ISetShipSpeedCheatUseCase
    {
        private readonly ShipStats shipStats;
        private readonly StatModifier<float> statModifier;

        private bool added;

        public SetShipSpeedCheatUseCase(
            ShipStats shipStats,
            StatModifier<float> statModifier
            )
        {
            this.shipStats = shipStats;
            this.statModifier = statModifier;
        }

        public void Execute(float speed)
        {
            if(!added)
            {
                added = true;

                shipStats.ForwardMaxSpeed.Add(statModifier);
            }

            statModifier.ModificationValue = speed;
        }
    }
}
