using Juce.TweenPlayer;
using Playground.Configuration.Car;
using Playground.Libraries.Car;
using Playground.Services;

namespace Playground.Content.Meta.UI.CarPanel
{
    public class SetupViewingCarUseCase : ISetupViewingCarUseCase
    {
        private readonly SharedService sharedService;
        private readonly CarLibrary carLibrary;
        private readonly ViewingCarData viewingCarData;
        private readonly CarPanelUIViewModel carPanelUIViewModel;
        private readonly TweenPlayer showPurchasedFeedback;
        private readonly TweenPlayer showNonPurchasedFeedback;
        private readonly TweenPlayer showEnoughSoftCurrencyFeedback;
        private readonly TweenPlayer showNotEnoughSoftCurrencyFeedback;

        public SetupViewingCarUseCase(
            SharedService sharedService,
            CarLibrary carLibrary,
            ViewingCarData viewingCarData,
            CarPanelUIViewModel carPanelUIViewModel,
            TweenPlayer showPurchasedFeedback,
            TweenPlayer showNonPurchasedFeedback,
            TweenPlayer showEnoughSoftCurrencyFeedback,
            TweenPlayer showNotEnoughSoftCurrencyFeedback
            )
        {
            this.sharedService = sharedService;
            this.carLibrary = carLibrary;
            this.viewingCarData = viewingCarData;
            this.carPanelUIViewModel = carPanelUIViewModel;
            this.showPurchasedFeedback = showPurchasedFeedback;
            this.showNonPurchasedFeedback = showNonPurchasedFeedback;
            this.showEnoughSoftCurrencyFeedback = showEnoughSoftCurrencyFeedback;
            this.showNotEnoughSoftCurrencyFeedback = showNotEnoughSoftCurrencyFeedback;
        }

        public void Execute(string carTypeId)
        {
            bool found = carLibrary.TryGet(carTypeId, out CarConfiguration carConfiguration);

            if (!found)
            {
                UnityEngine.Debug.LogError($"Car with id {carTypeId} could not be found at" +
                    $"{nameof(CarLibrary)}. Using default car at {nameof(SetupViewingCarUseCase)}");

                carConfiguration = carLibrary.Items[0];
            }

            bool isOwned = sharedService.SharedUseCases.IsCarOwnedUseCase.Execute(carConfiguration.CarTypeId);

            viewingCarData.CarTypeId = carConfiguration.CarTypeId;
            viewingCarData.CarIcon = carConfiguration.CarIcon;
            viewingCarData.CarPrice = carConfiguration.CarShopPrice;

            carPanelUIViewModel.CarNameVariable.Value = carConfiguration.CarName;
            carPanelUIViewModel.CarDescriptionVariable.Value = carConfiguration.CarDescription;
            carPanelUIViewModel.CarPriceVariable.Value = carConfiguration.CarShopPrice;

            if (isOwned)
            {
                showPurchasedFeedback.Play(instantly: true);
            }
            else
            {
                showNonPurchasedFeedback.Play(instantly: true);

                bool enoughSoftCurrency = sharedService.SharedUseCases.HasEnoughSoftCurrencyUseCase.Execute(
                    carConfiguration.CarShopPrice
                    );

                if(enoughSoftCurrency)
                {
                    showEnoughSoftCurrencyFeedback.Play(instantly: true);
                }
                else
                {
                    showNotEnoughSoftCurrencyFeedback.Play(instantly: true);
                }
            }
        }
    }
}
