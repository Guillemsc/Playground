using Juce.TweenPlayer.BindableData;

namespace Playground.Content.StageUI.UI.Coins.TweenData
{
    [BindableData("Change Coins", "Coins/Change Coins", "4f4a0388-9750-4164-b76f-f1584fedc1ab")]
    public class ChangeCoinsTweenData : IBindableData
    {
        public string Coins { get; }

        public ChangeCoinsTweenData(
            string coins
            )
        {
            Coins = coins;
        }
    }
}
