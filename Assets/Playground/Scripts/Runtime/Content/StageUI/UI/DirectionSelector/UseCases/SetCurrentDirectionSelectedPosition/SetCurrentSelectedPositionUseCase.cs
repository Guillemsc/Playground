using Juce.TweenPlayer;
using Playground.Content.StageUI.UI.ActionInputDetection.UseCases.GetAnchoredFromNormalizedPosition;
using Playground.Content.StageUI.UI.DirectionSelector.TweenData;
using System.Threading;

namespace Playground.Content.StageUI.UI.ActionInputDetection.UseCases.SetCurrentSelectedPosition
{
    public class SetCurrentSelectedPositionUseCase : ISetCurrentSelectedPositionUseCase
    {
        private readonly TweenPlayer currentDirectionSelectedTween;
        private readonly TweenPlayer changeCurrentDirectionMarkerTween;
        private readonly IGetAnchoredFromNormalizedPositionUseCase getAnchoredFromNormalizedPositionUseCase;

        public SetCurrentSelectedPositionUseCase(
            TweenPlayer currentDirectionSelectedTween,
            TweenPlayer changeCurrentDirectionMarkerTween,
            IGetAnchoredFromNormalizedPositionUseCase getAnchoredFromNormalizedPositionUseCase
            )
        {
            this.currentDirectionSelectedTween = currentDirectionSelectedTween;
            this.changeCurrentDirectionMarkerTween = changeCurrentDirectionMarkerTween;
            this.getAnchoredFromNormalizedPositionUseCase = getAnchoredFromNormalizedPositionUseCase;
        }

        public void Execute(float normalizedPosition, bool instantly = false)
        {
            currentDirectionSelectedTween.Play(instantly, CancellationToken.None).RunAsync();

            CurrentDirectionPositionData currentDirectionPositionData = new CurrentDirectionPositionData(
                getAnchoredFromNormalizedPositionUseCase.Execute(normalizedPosition)
                ); ;

            changeCurrentDirectionMarkerTween.Play(
                currentDirectionPositionData,
                instantly,
                CancellationToken.None
                ).RunAsync();
        }
    }
}
