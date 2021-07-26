using Juce.CoreUnity.Service;
using Playground.Configuration.Car;
using Playground.Persistence;
using Playground.Services;

namespace Playground.Shared.UseCases
{
    public class PurchaseCarUseCase : IPurchaseCarUseCase
    {
        private readonly IHasEnoughSoftCurrencyUseCase hasEnoughSoftCurrencyUseCase;
        private readonly IRemoveSoftCurrencyUseCase removeSoftCurrencyUseCase;

        public PurchaseCarUseCase(
            IHasEnoughSoftCurrencyUseCase hasEnoughSoftCurrencyUseCase,
            IRemoveSoftCurrencyUseCase removeSoftCurrencyUseCase
            )
        {
            this.hasEnoughSoftCurrencyUseCase = hasEnoughSoftCurrencyUseCase;
            this.removeSoftCurrencyUseCase = removeSoftCurrencyUseCase;
        }

        public void Execute(string carTypeId)
        {
            ConfigurationService configurationService = ServicesProvider.GetService<ConfigurationService>();
            PersistenceService persistanceService = ServicesProvider.GetService<PersistenceService>();

            ProgressData progressData = persistanceService.ProgressDataSerializableData.Data;

            bool carFound = configurationService.CarLibrary.TryGet(carTypeId, out CarConfiguration carConfiguration);

            if(!carFound)
            {
                return;
            }

            bool alreadyOwned = progressData.OwnedCars.Contains(carTypeId);

            if(alreadyOwned)
            {
                return;
            }

            bool canBuy = hasEnoughSoftCurrencyUseCase.Execute(carConfiguration.CarShopPrice);

            if(!canBuy)
            {
                return;
            }

            removeSoftCurrencyUseCase.Execute(carConfiguration.CarShopPrice);

            progressData.OwnedCars.Add(carTypeId);
        }
    }
}
