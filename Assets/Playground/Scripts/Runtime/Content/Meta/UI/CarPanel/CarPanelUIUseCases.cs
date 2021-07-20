namespace Playground.Content.Meta.UI.CarPanel
{
    public class CarPanelUIUseCases
    {
        public ISetupViewingCarUseCase SetupViewingCarUseCase { get; }
        public IRefreshCarUseCase RefreshCarUseCase { get; }
        public ISelectCarUseCase SelectCarUseCase { get; }

        public CarPanelUIUseCases(
            ISetupViewingCarUseCase setupViewingCarUseCase,
            IRefreshCarUseCase refreshCarUseCase,
            ISelectCarUseCase selectCarUseCase
            )
        {
            SetupViewingCarUseCase = setupViewingCarUseCase;
            RefreshCarUseCase = refreshCarUseCase;
            SelectCarUseCase = selectCarUseCase;
        }
    }
}
