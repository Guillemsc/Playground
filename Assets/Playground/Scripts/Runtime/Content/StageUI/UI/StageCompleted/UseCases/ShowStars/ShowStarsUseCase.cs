using UnityEngine;

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
            float delay = 0.0f;

            for(int i = 0; i < 3; ++i)
            {
                bool earned = stars > i;

                StageCompletedStarUIEntry stageCompletedStarUIEntry = GetStar(i);

                if(earned)
                {
                    stageCompletedStarUIEntry.ShowEarnedFeedback.Play(new StageCompletedStarDelayBindableData(delay));
                }
                else
                {
                    stageCompletedStarUIEntry.ShowNotEarnedFeedback.Play(new StageCompletedStarDelayBindableData(delay));
                }

                delay += 0.4f;
            }
        }

        private StageCompletedStarUIEntry GetStar(int starIndex)
        {
            starIndex = Mathf.Clamp(starIndex, 0, 2);

            if (starIndex == 0)
            {
                return stageCompletedStar1UIEntry;
            }

            if (starIndex == 1)
            {
                return stageCompletedStar2UIEntry;
            }

            if (starIndex == 2)
            {
                return stageCompletedStar3UIEntry;
            }

            throw new System.ArgumentOutOfRangeException($"Tried to get {nameof(StageCompletedStarUIEntry)}" +
                $"at index {starIndex}");
        }
    }
}
