namespace Playground.Content.StageUI.UI.StageCompleted
{
    public class ShowStarsUseCase : IShowStarsUseCase
    {
        private readonly StageCompletedStarUIEntry stageCompletedStar1UIEntry;
        private readonly StageCompletedStarUIEntry stageCompletedStar2UIEntry;
        private readonly StageCompletedStarUIEntry stageCompletedStar3UIEntry;

        public ShowStarsUseCase(
            StageCompletedStarUIEntry stageCompletedStar1UIEntry,
            StageCompletedStarUIEntry stageCompletedStar2UIEntry,
            StageCompletedStarUIEntry stageCompletedStar3UIEntry
            ) 
        {
            this.stageCompletedStar1UIEntry = stageCompletedStar1UIEntry;
            this.stageCompletedStar2UIEntry = stageCompletedStar2UIEntry;
            this.stageCompletedStar3UIEntry = stageCompletedStar3UIEntry;
        }

        public void Execute(int stars)
        {
            if (stars > 0)
            {
                stageCompletedStar1UIEntry.ShowActiveFeedback.Play(new StageCompletedStarDelayBindableData(0.0f));
            }

            if (stars > 1)
            {
                stageCompletedStar2UIEntry.ShowActiveFeedback.Play(new StageCompletedStarDelayBindableData(0.4f));
            }

            if (stars > 2)
            {
                stageCompletedStar3UIEntry.ShowActiveFeedback.Play(new StageCompletedStarDelayBindableData(0.8f));
            }
        }
    }
}
