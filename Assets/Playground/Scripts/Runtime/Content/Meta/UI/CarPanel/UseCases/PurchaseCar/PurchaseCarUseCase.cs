using Juce.TweenPlayer;
using Playground.Content.Meta.UI.ConfirmPurchase;
using Playground.Services.ViewStack;

namespace Playground.Content.Meta.UI.CarPanel
{
    public class PurchaseCarUseCase : IPurchaseCarUseCase
    {
        private readonly UIViewStackService uiViewStackService;
        private readonly ViewingCarData viewingCarData;
        private readonly TweenPlayer showPurchasedFeedback;

        private ConfirmPurchaseUIInteractor confirmPurchaseUIInteractor;

        public PurchaseCarUseCase(
            UIViewStackService uiViewStackService,
            ViewingCarData viewingCarData,
            TweenPlayer showPurchasedFeedback
            )
        {
            this.uiViewStackService = uiViewStackService;
            this.viewingCarData = viewingCarData;
            this.showPurchasedFeedback = showPurchasedFeedback;
        }

        public void Execute()
        {
            confirmPurchaseUIInteractor = uiViewStackService.GetInteractor<ConfirmPurchaseUIInteractor>();

            confirmPurchaseUIInteractor.Setup(viewingCarData.CarPrice, viewingCarData.CarIcon);

            confirmPurchaseUIInteractor.OnPurchased += OnPurchased;

            uiViewStackService.New().Show<ConfirmPurchaseUIView>(instantly: false).Execute();
        }

        private void OnPurchased()
        {
            confirmPurchaseUIInteractor.OnPurchased -= OnPurchased;

            uiViewStackService.New().Hide<ConfirmPurchaseUIView>(instantly: false).Execute();

            showPurchasedFeedback.Play(instantly: false);
        }
    }
}
