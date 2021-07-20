namespace Playground.Content.Meta.UI.CarPanel
{
    public class CarPanelUIUseCases
    {
        public ISetupViewingCarUseCase SetupViewingCarUseCase { get; }
        public IRefreshCarUseCase RefreshCarUseCase { get; }

        public CarPanelUIUseCases(
            ISetupViewingCarUseCase setupViewingCarUseCase,
            IRefreshCarUseCase refreshCarUseCase
            )
        {
            SetupViewingCarUseCase = setupViewingCarUseCase;
            RefreshCarUseCase = refreshCarUseCase;
        }
    }
}
