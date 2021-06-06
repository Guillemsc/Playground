namespace Playground.Content.StageUI.UI.StageCompleted
{
    public class StageCompletedUIUseCases
    {
        public IShowStarsUseCase ShowStarsUseCase { get; }
        public IPlayAgainUseCase PlayAgainUseCase { get; }

        public StageCompletedUIUseCases(
            IShowStarsUseCase showStarsUseCase,
            IPlayAgainUseCase playAgainUseCase
            )
        {
            ShowStarsUseCase = showStarsUseCase;
            PlayAgainUseCase = playAgainUseCase;
        }
    }
}
