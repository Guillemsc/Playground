
namespace Playground.Content.Meta.UI.ConfirmPurchase
{
    public class ConfirmPurchaseUIUseCases
    {
        public ISetupDataUseCase SetupDataUseCase { get; }
        public IPurchasedUseCase PurchasedUseCase { get; }

        public ConfirmPurchaseUIUseCases(
            ISetupDataUseCase setupDataUseCase,
            IPurchasedUseCase purchasedUseCase
            )
        {
            SetupDataUseCase = setupDataUseCase;
            PurchasedUseCase = purchasedUseCase;
        }
    }
}
