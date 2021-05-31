namespace Playground.Content.StageUI.UI.StageOverlay.UseCases
{
    public class RestartSelectedUseCase : IRestartSelectedUseCase
    {
        private readonly StageOverlayUIViewModel viewModel;

        public RestartSelectedUseCase(StageOverlayUIViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public void Execute()
        {
            viewModel.RegisteredRestartCallbacks?.Invoke();
        }
    }
}
