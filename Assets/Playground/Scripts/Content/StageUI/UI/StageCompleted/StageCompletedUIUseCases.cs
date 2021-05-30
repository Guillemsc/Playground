namespace Playground.Content.StageUI.UI.StageCompleted
{
    public class StageCompletedUIUseCases
    {
        public IPlayAgainUseCase PlayAgainUseCase { get; }

        public StageCompletedUIUseCases(
            IPlayAgainUseCase playAgainUseCase
            )
        {
            PlayAgainUseCase = playAgainUseCase;
        }
    }
}
