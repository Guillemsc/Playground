namespace Playground.Content.Meta.UI.CarPanel
{
    public class CarPanelUIUseCases
    {
        public ISetupViewingCarUseCase SetupViewingCarUseCase { get; }
        public IRefreshCarUseCase RefreshCarUseCase { get; }
        public ISelectCarUseCase SelectCarUseCase { get; }
        public IPurchaseCaseUseCase PurchaseCaseUseCase { get; }

        public CarPanelUIUseCases(
            ISetupViewingCarUseCase setupViewingCarUseCase,
            IRefreshCarUseCase refreshCarUseCase,
            ISelectCarUseCase selectCarUseCase,
            IPurchaseCaseUseCase purchaseCaseUseCase
            )
        {
            SetupViewingCarUseCase = setupViewingCarUseCase;
            RefreshCarUseCase = refreshCarUseCase;
            SelectCarUseCase = selectCarUseCase;
            PurchaseCaseUseCase = purchaseCaseUseCase;
        }
    }
}
