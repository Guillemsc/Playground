using Playground.Content.Stage.VisualLogic.Setup;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.UseCases.GetDirectionSelectionValue
{
    public class GetDirectionSelectionValueUseCase : IGetDirectionSelectionValueUseCase
    {
        private readonly DirectionSelectorVisualLogicSetup directionSelectorSetup;

        public GetDirectionSelectionValueUseCase(
            DirectionSelectorVisualLogicSetup directionSelectorSetup
            )
        {
            this.directionSelectorSetup = directionSelectorSetup;
        }

        public float Execute(float timeValue)
        {
            float sinValue = Mathf.Sin(timeValue * directionSelectorSetup.BaseSpeedMultiplier);

            float normalizedValue = (sinValue + 1) * 0.5f;

            return normalizedValue;
        }
    }
}
