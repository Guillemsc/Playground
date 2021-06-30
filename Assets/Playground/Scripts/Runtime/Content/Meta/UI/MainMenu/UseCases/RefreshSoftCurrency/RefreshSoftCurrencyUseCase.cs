using Playground.Persistence;
using Playground.Services;

namespace Playground.Content.Meta.UI.MainMenu
{
    public class RefreshSoftCurrencyUseCase : IRefreshSoftCurrencyUseCase
    {
        private readonly MainMenuUIViewModel mainMenuUIViewModel;
        private readonly PersistenceService persistenceService;

        public RefreshSoftCurrencyUseCase(
            MainMenuUIViewModel mainMenuUIViewModel,
            PersistenceService persistenceService
            )
        {
            this.mainMenuUIViewModel = mainMenuUIViewModel;
            this.persistenceService = persistenceService;
        }

        public void Execute()
        {
            ProgressData progressData = persistenceService.ProgressDataSerializableData.Data;

            mainMenuUIViewModel.SoftCurrencyVariable.Value = progressData.SoftCurrency;
        }
    }
}
