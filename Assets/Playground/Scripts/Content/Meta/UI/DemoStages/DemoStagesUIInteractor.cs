using Juce.CoreUnity.UI;

namespace Playground.Content.Stage.VisualLogic.UI.DemoStages
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

        public void Subscribe()
        {

        }

        public void Unsubscribe()
        {

        }
    }
}
