using Juce.TweenPlayer.BindableData;

namespace Playground.Content.StageUI.UI.Points.TweenData
{
    [BindableData("Change Points", "Points/Change Points", "4f4a0377-9750-4164-b76f-f1584fedc1ab")]
    public class ChangePointsTweenData : IBindableData
    {
        public string Points { get; }

        public ChangePointsTweenData(
            string points
            )
        {
            Points = points;
        }
    }
}
