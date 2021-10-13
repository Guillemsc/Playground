using Playground.Content.StageUI.UI.ActionInputDetection.UseCases.GetAnchoredFromNormalizedPosition;
using Playground.Content.StageUI.UI.DirectionSelector;
using UnityEngine;

namespace Playground.Content.StageUI.UI.ActionInputDetection.UseCases.SetDirectionSelectionPosition
{
    public class SetDirectionSelectionPositionUseCase : ISetDirectionSelectionPositionUseCase
    {
        private readonly DirectionSelectorUIViewModel directionSelectorUIViewModel;
        private readonly IGetAnchoredFromNormalizedPositionUseCase getAnchoredFromNormalizedPositionUseCase;

        public SetDirectionSelectionPositionUseCase(
            DirectionSelectorUIViewModel directionSelectorUIViewModel,
            IGetAnchoredFromNormalizedPositionUseCase getAnchoredFromNormalizedPositionUseCase
            )
        {
            this.directionSelectorUIViewModel = directionSelectorUIViewModel;
            this.getAnchoredFromNormalizedPositionUseCase = getAnchoredFromNormalizedPositionUseCase;
        }

        public void Execute(float normalizedPosition)
        {
            directionSelectorUIViewModel.DirectionSelectionAnchoredPositionX.Value =
                getAnchoredFromNormalizedPositionUseCase.Execute(normalizedPosition);
        }
    }
}
