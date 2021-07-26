using Juce.TweenPlayer;
using Playground.Content.Meta.UI.ConfirmPurchase;
using Playground.Services;
using Playground.Services.ViewStack;
using System.Threading;

namespace Playground.Content.Meta.UI.CarPanel
{
    public class PurchaseCarUseCase : IPurchaseCarUseCase
    {
        private readonly SharedService sharedService;
        private readonly UIViewStackService uiViewStackService;
        private readonly ViewingCarData viewingCarData;
        private readonly TweenPlayer showPurchasedFeedback;

        private ConfirmPurchaseUIInteractor confirmPurchaseUIInteractor;

        public PurchaseCarUseCase(
            SharedService sharedService,
            UIViewStackService uiViewStackService,
            ViewingCarData viewingCarData,
            TweenPlayer showPurchasedFeedback
            )
        {
            this.sharedService = sharedService;
            this.uiViewStackService = uiViewStackService;
            this.viewingCarData = viewingCarData;
            this.showPurchasedFeedback = showPurchasedFeedback;
        }

        public void Execute()
        {
            bool hasEnoughSoftCurrency = sharedService.SharedUseCases.HasEnoughSoftCurrencyUseCase.Execute(
                viewingCarData.CarPrice
                );

            if(!hasEnoughSoftCurrency)
            {
                return;
            }

            confirmPurchaseUIInteractor = uiViewStackService.GetInteractor<ConfirmPurchaseUIInteractor>();

            confirmPurchaseUIInteractor.Setup(
                viewingCarData.CarPrice, 
                viewingCarData.CarIcon
                );

            confirmPurchaseUIInteractor.OnPurchased += OnPurchased;

            uiViewStackService.New().Show<ConfirmPurchaseUIView>(instantly: false).Execute();
        }

        private void OnPurchased()
        {
            confirmPurchaseUIInteractor.OnPurchased -= OnPurchased;

            uiViewStackService.New().Hide<ConfirmPurchaseUIView>(instantly: false).Execute();

            sharedService.SharedUseCases.PurchaseCarUseCase.Execute(viewingCarData.CarTypeId);
            sharedService.SharedUseCases.SaveProgressUseCase.Execute(CancellationToken.None).RunAsync();

            showPurchasedFeedback.Play(instantly: false);
        }
    }
}
