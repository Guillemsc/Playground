using Juce.CoreUnity.UI;

namespace Playground.Content.StageUI.UI.ActionInputDetection
{
    public class ActionInputDetectionUIInteractor : UIInteractor
    {
        private readonly ActionInputDetectionUIViewModel viewModel;
        private readonly ActionInputDetectionUIUseCases useCases;

        public ActionInputDetectionUIInteractor(
            ActionInputDetectionUIViewModel viewModel,
            ActionInputDetectionUIUseCases useCases
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

        public void Refresh()
        {

        }
    }
}
