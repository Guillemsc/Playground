using Playground.Content.Meta.UI.ConfirmPurchase;
using Playground.Services.ViewStack;

namespace Playground.Content.Meta.UI.CarPanel
{
    public class PurchaseCarUseCase : IPurchaseCaseUseCase
    {
        private readonly UIViewStackService uiViewStackService;
        private readonly ViewingCarData viewingCarData;

        public PurchaseCarUseCase(
            UIViewStackService uiViewStackService,
            ViewingCarData viewingCarData
            )
        {
            this.uiViewStackService = uiViewStackService;
            this.viewingCarData = viewingCarData;
        }

        public void Execute()
        {
            ConfirmPurchaseUIInteractor confirmPurchaseUIInteractor = uiViewStackService.GetInteractor<ConfirmPurchaseUIInteractor>();

            confirmPurchaseUIInteractor.Setup(viewingCarData.CarPrice, viewingCarData.CarIcon);

            uiViewStackService.New().Show<ConfirmPurchaseUIView>(instantly: false).Execute();
        }
    }
}
