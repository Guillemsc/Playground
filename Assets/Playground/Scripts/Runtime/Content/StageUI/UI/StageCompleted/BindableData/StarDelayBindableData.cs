using Juce.TweenPlayer.BindableData;

namespace Playground.Content.StageUI.UI.StageCompleted
{
    [BindableData("Star delay", "StageCompleted/StarDelay", "01bf5ecd-28ae-46e7-add3-2c3097d4d59f")]
    public class StarDelayBindableData : IBindableData
    {
        public float Delay { get; }

        public StarDelayBindableData(float delay)
        {
            Delay = delay;
        }
    }
}
