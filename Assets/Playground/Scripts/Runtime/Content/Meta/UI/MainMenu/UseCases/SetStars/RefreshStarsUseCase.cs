using Playground.Persistence;
using Playground.Services;

namespace Playground.Content.Meta.UI.MainMenu
{
    public class RefreshStarsUseCase : IRefreshStarsUseCase
    {
        private readonly MainMenuUIViewModel mainMenuUIViewModel;
        private readonly PersistenceService persistenceService;

        public RefreshStarsUseCase(
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

            mainMenuUIViewModel.StarsVariable.Value = progressData.TotalStars;
        }
    }
}
