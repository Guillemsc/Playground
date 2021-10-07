using Juce.Core.Subscribables;

namespace Playground.Content.StageUI.UI.DirectionSelector
{
    public class DirectionSelectorUIController : ISubscribable
    {
        private readonly DirectionSelectorUIViewModel viewModel;

        public DirectionSelectorUIController(
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
    }
}
