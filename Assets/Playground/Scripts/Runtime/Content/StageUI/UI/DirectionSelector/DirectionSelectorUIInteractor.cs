using Juce.Core.Subscribables;
using Playground.Content.StageUI.UI.ActionInputDetection.UseCases.SetCurrentSelectedPosition;
using Playground.Content.StageUI.UI.ActionInputDetection.UseCases.SetDirectionSelectionPosition;

namespace Playground.Content.StageUI.UI.DirectionSelector
{
    public class DirectionSelectorUIInteractor : IDirectionSelectorUIInteractor, ISubscribable
    {
        private readonly DirectionSelectorUIViewModel viewModel;
        private readonly ISetDirectionSelectionPositionUseCase setDirectionSelectionPositionUseCase;
        private readonly ISetCurrentSelectedPositionUseCase setCurrentSelectedPositionUseCase;

        public DirectionSelectorUIInteractor(
            DirectionSelectorUIViewModel viewModel,
            ISetDirectionSelectionPositionUseCase setDirectionSelectionPositionUseCase,
            ISetCurrentSelectedPositionUseCase setCurrentSelectedPositionUseCase
            )
        {
            this.viewModel = viewModel;
            this.setDirectionSelectionPositionUseCase = setDirectionSelectionPositionUseCase;
            this.setCurrentSelectedPositionUseCase = setCurrentSelectedPositionUseCase;
        }

        public void Subscribe()
        {
            setCurrentSelectedPositionUseCase.Execute(normalizedPosition: 0.5f, instantly: true);
        }

        public void Unsubscribe()
        {
          
        }

        public void SetDirectionSelectionPosition(float normalizedPosition)
        {
            setDirectionSelectionPositionUseCase.Execute(normalizedPosition);
        }

        public void SetCurrentSelectedPosition(float normalizedPosition)
        {
            setCurrentSelectedPositionUseCase.Execute(normalizedPosition);
        }
    }
}
