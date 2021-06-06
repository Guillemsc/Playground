using Juce.TweenPlayer.BindableData;

namespace Playground.Content.StageUI.UI.StageCompleted
{
    [BindableData("Star delay", "Stage completed/Star delay", "01bf5ecd-28ae-46e7-add3-2c3097d4d59f")]
    public class StageCompletedStarDelayBindableData : IBindableData
    {
        public float Delay { get; }

        public StageCompletedStarDelayBindableData(float delay)
        {
            Delay = delay;
        }
    }
}
