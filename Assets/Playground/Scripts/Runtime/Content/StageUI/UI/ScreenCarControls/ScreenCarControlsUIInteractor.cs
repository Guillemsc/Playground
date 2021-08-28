using Juce.Core.Activables;
using Juce.CoreUnity.UI;

namespace Playground.Content.StageUI.UI.ScreenCarControls
{
    public class ScreenCarControlsUIInteractor : UIInteractor
    {
        private readonly ScreenCarControlsUIViewModel viewModel;
        private readonly ScreenCarControlsUIUseCases useCases;

        public IActivable MainActivable { get; }

        public ScreenCarControlsUIInteractor(
            ScreenCarControlsUIViewModel viewModel,
            ScreenCarControlsUIUseCases useCases
            )
        {
            this.viewModel = viewModel;
            this.useCases = useCases;
        }

        public void Refresh()
        {

        }

        public void Subscribe()
        {

        }

        public void Unsubscribe()
        {

        }
    }
}
