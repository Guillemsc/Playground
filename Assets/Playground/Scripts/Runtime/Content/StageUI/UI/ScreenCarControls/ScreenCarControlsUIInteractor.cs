using Juce.CoreUnity.UI;

namespace Playground.Content.StageUI.UI.ScreenCarControls
{
    public class ScreenCarControlsUIInteractor : UIInteractor
    {
        private readonly ScreenCarControlsUIViewModel viewModel;
        private readonly ScreenCarControlsUIUseCases useCases;

        public ScreenCarControlsUIInteractor(
            ScreenCarControlsUIViewModel viewModel,
            ScreenCarControlsUIUseCases useCases
            )
        {
            this.viewModel = viewModel;
            this.useCases = useCases;
        }

        public void Subscribe()
        {

        }

        public void Unsubscribe()
        {

        }
    }
}
