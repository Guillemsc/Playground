
namespace Playground.Content.Meta.UI.ConfirmPurchase
{
    public class ConfirmPurchaseUIUseCases
    {
        public ISetupDataUseCase SetupDataUseCase { get; }

        public ConfirmPurchaseUIUseCases(
            ISetupDataUseCase setupDataUseCase
            )
        {
            SetupDataUseCase = setupDataUseCase;
        }
    }
}
