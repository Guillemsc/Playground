using Juce.CoreUnity.UI;

namespace Playground.Content.Meta.UI.DemoStages
{
    public class DemoStagesUIInteractor : UIInteractor
    {
        private readonly DemoStagesUIViewModel viewModel;
        private readonly DemoStagesUIUseCases useCases;

        public DemoStagesUIInteractor(
            DemoStagesUIViewModel viewModel,
            DemoStagesUIUseCases useCases
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
