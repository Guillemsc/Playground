using Juce.Core.Subscribables;
using Playground.Content.StageUI.UI.ActionInputDetection.UseCases.SetDirectionSelectionPosition;

namespace Playground.Content.StageUI.UI.DirectionSelector
{
    public class DirectionSelectorUIInteractor : IDirectionSelectorUIInteractor, ISubscribable
    {
        private readonly DirectionSelectorUIViewModel viewModel;
        private readonly ISetDirectionSelectionPositionUseCase setDirectionSelectionPositionUseCase;

        public DirectionSelectorUIInteractor(
            DirectionSelectorUIViewModel viewModel,
            ISetDirectionSelectionPositionUseCase setDirectionSelectionPositionUseCase
            )
        {
            this.viewModel = viewModel;
            this.setDirectionSelectionPositionUseCase = setDirectionSelectionPositionUseCase;
        }

        public void Subscribe()
        {
        
        }

        public void Unsubscribe()
        {
          
        }

        public void Refresh()
        {

        }

        public void SetDirectionSelectionPosition(float normalizedPosition)
        {
            setDirectionSelectionPositionUseCase.Execute(normalizedPosition);
        }
    }
}
