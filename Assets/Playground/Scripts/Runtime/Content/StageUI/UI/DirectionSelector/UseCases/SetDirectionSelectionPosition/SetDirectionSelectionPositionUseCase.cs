using Playground.Content.StageUI.UI.DirectionSelector;
using UnityEngine;

namespace Playground.Content.StageUI.UI.ActionInputDetection.UseCases.SetDirectionSelectionPosition
{
    public class SetDirectionSelectionPositionUseCase : ISetDirectionSelectionPositionUseCase
    {
        private readonly DirectionSelectorUIViewModel directionSelectorUIViewModel;
        private readonly RectTransform avaliableDirectionSpace;

        public SetDirectionSelectionPositionUseCase(
            DirectionSelectorUIViewModel directionSelectorUIViewModel,
            RectTransform avaliableDirectionSpace
            )
        {
            this.directionSelectorUIViewModel = directionSelectorUIViewModel;
            this.avaliableDirectionSpace = avaliableDirectionSpace;
        }

        public void Execute(float normalizedPosition)
        {
            float normalizedAnchoredPosition = avaliableDirectionSpace.rect.width * normalizedPosition;

            directionSelectorUIViewModel.DirectionSelectionAnchoredPositionX.Value = normalizedAnchoredPosition;
        }
    }
}
