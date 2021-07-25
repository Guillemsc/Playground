namespace Playground.Content.Meta.UI.CarPanel
{
    public class CarPanelUIUseCases
    {
        public ISetupViewingCarUseCase SetupViewingCarUseCase { get; }
        public IRefreshCarUseCase RefreshCarUseCase { get; }
        public ISelectCarUseCase SelectCarUseCase { get; }
        public IPurchaseCarUseCase PurchaseCarUseCase { get; }

        public CarPanelUIUseCases(
            ISetupViewingCarUseCase setupViewingCarUseCase,
            IRefreshCarUseCase refreshCarUseCase,
            ISelectCarUseCase selectCarUseCase,
            IPurchaseCarUseCase purchaseCarUseCase
            )
        {
            SetupViewingCarUseCase = setupViewingCarUseCase;
            RefreshCarUseCase = refreshCarUseCase;
            SelectCarUseCase = selectCarUseCase;
            PurchaseCarUseCase = purchaseCarUseCase;
        }
    }
}
