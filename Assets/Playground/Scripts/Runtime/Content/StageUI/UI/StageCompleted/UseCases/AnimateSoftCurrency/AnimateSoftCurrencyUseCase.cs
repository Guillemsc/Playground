using Juce.TweenPlayer;

namespace Playground.Content.StageUI.UI.StageCompleted
{
    public class AnimateSoftCurrencyUseCase : IAnimateSoftCurrencyUseCase
    {
        private readonly TweenPlayer softCurrencyFeedback;

        public AnimateSoftCurrencyUseCase(
            TweenPlayer softCurrencyFeedback
            )
        {
            this.softCurrencyFeedback = softCurrencyFeedback;
        }

        public void Execute(int softCurrency)
        {
            SoftCurrencyAnimationBindableData softCurrencyAnimationBindableData = new SoftCurrencyAnimationBindableData()
            {
                EndValue = softCurrency
            };

            softCurrencyFeedback.Play(softCurrencyAnimationBindableData);
        }
    }
}
