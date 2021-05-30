using Juce.CoreUnity.UI;

namespace Playground.Content.StageUI.UI.StageOverlay
{
    public class StageOverlayUIInteractor : UIInteractor
    {
        private readonly StageOverlayUIViewModel viewModel;
        private readonly StageOverlayUIUseCases useCases;

        public StageOverlayUIInteractor(
            StageOverlayUIViewModel viewModel,
            StageOverlayUIUseCases useCases
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
