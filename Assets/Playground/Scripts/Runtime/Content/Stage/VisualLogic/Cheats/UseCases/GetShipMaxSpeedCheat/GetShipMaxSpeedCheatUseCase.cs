using Juce.Core.Stats;

namespace Playground.Content.Stage.VisualLogic.Cheats.UseCases.GetShipMaxSpeedCheat
{
    public class GetShipMaxSpeedCheatUseCase : IGetShipMaxSpeedCheatUseCase
    {
        private readonly StatModifier<float> statModifier;

        public GetShipMaxSpeedCheatUseCase(
            StatModifier<float> statModifier
            )
        {
            this.statModifier = statModifier;
        }

        public float Execute()
        {
            return statModifier.ModificationValue;
        }
    }
}
