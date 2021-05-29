namespace Playground.Content.Stage.VisualLogic.UI.DemoStages
{
    public class DemoStagesUIInteractor
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
