using Juce.Core.Subscribables;

namespace Playground.Content.StageUI.UI.DirectionSelector
{
    public class DirectionSelectorUIInteractor : IDirectionSelectorUIInteractor, ISubscribable
    {
        private readonly DirectionSelectorUIViewModel viewModel;

        public DirectionSelectorUIInteractor(
            DirectionSelectorUIViewModel viewModel
            )
        {
            this.viewModel = viewModel;
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
    }
}
