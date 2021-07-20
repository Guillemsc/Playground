namespace Playground.Content.Meta.UI.MainMenu
{
    public class MainMenuUIUseCases
    {
        public IRefreshStarsUseCase RefreshStarsUseCase { get; }
        public IRefreshSoftCurrencyUseCase RefreshSoftCurrencyUseCase { get; }
        public IRefreshCarUseCase RefreshCarUseCase { get; }

        public MainMenuUIUseCases(
            IRefreshStarsUseCase refreshStarsUseCase,
            IRefreshSoftCurrencyUseCase refreshSoftCurrencyUseCase,
            IRefreshCarUseCase refreshCarUseCase
            )
        {
            RefreshStarsUseCase = refreshStarsUseCase;
            RefreshSoftCurrencyUseCase = refreshSoftCurrencyUseCase;
            RefreshCarUseCase = refreshCarUseCase;
        }
    }
}
