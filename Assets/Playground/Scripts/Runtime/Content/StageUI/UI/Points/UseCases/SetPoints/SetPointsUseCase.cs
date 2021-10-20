using Juce.TweenPlayer;
using Playground.Content.StageUI.UI.Points.TweenData;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.StageUI.UI.Effects.UseCases.SetPoints
{
    public class SetPointsUseCase : ISetPointsUseCase
    {
        private readonly TweenPlayer changePointsTween;

        public SetPointsUseCase(
            TweenPlayer changePointsTween
            )
        {
            this.changePointsTween = changePointsTween;
        }

        public Task Execute(
            int points,
            bool instantly,
            CancellationToken cancellationToken
            )
        {
            ChangePointsTweenData tweenData = new ChangePointsTweenData(
                points.ToString()
                );

            return changePointsTween.Play(tweenData, instantly, cancellationToken);
        }
    }
}
