namespace Playground.Content.StageUI.UI.StageCompleted
{
    public class StageCompletedUIUseCases
    {
        public IShowStarsUseCase ShowStarsUseCase { get; }
        public ISetTimeUseCase SetTimeUseCase { get; }
        public IContinueUseCase ContinueUseCase { get; }
        public IPlayAgainUseCase PlayAgainUseCase { get; }

        public StageCompletedUIUseCases(
            IShowStarsUseCase showStarsUseCase,
            ISetTimeUseCase setTimeUseCase,
            IContinueUseCase continueUseCase,
            IPlayAgainUseCase playAgainUseCase
            )
        {
            ShowStarsUseCase = showStarsUseCase;
            SetTimeUseCase = setTimeUseCase;
            ContinueUseCase = continueUseCase;
            PlayAgainUseCase = playAgainUseCase;
        }
    }
}
