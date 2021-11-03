using Juce.TweenPlayer;
using Playground.Content.StageUI.UI.Coins.TweenData;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.StageUI.UI.Coins.UseCases.SetPoints
{
    public class SetCoinsUseCase : ISetCoinsUseCase
    {
        private readonly TweenPlayer changeCoinsTween;

        public SetCoinsUseCase(
            TweenPlayer changeCoinsTween
            )
        {
            this.changeCoinsTween = changeCoinsTween;
        }

        public Task Execute(
            int coins,
            bool instantly,
            CancellationToken cancellationToken
            )
        {
            ChangeCoinsTweenData tweenData = new ChangeCoinsTweenData(
                coins.ToString()
                );

            return changeCoinsTween.Play(tweenData, instantly, cancellationToken);
        }
    }
}
