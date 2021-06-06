namespace Playground.Content.StageUI.UI.StageCompleted
{
    public class StageCompletedUIUseCases
    {
        public IShowStarsUseCase ShowStarsUseCase { get; }
        public IContinueUseCase ContinueUseCase { get; }
        public IPlayAgainUseCase PlayAgainUseCase { get; }

        public StageCompletedUIUseCases(
            IShowStarsUseCase showStarsUseCase,
            IContinueUseCase continueUseCase,
            IPlayAgainUseCase playAgainUseCase
            )
        {
            ShowStarsUseCase = showStarsUseCase;
            ContinueUseCase = continueUseCase;
            PlayAgainUseCase = playAgainUseCase;
        }
    }
}
