using Juce.TweenPlayer.BindableData;

namespace Playground.Content.StageUI.UI.DirectionSelector.TweenData
{
    [BindableData("Current Direction Position", "Direction Selector/Current Direction Position", "4f4a0377-9750-4164-b76f-f1584fedc1ac")]
    public class CurrentDirectionPositionData : IBindableData
    {
        public float AnchoredPositionX { get; }

        public CurrentDirectionPositionData(
            float anchoredPositionX
            )
        {
            AnchoredPositionX = anchoredPositionX;
        }
    }
}
