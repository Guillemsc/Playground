using UnityEngine;

namespace Playground.Content.StageUI.UI.ActionInputDetection.UseCases.GetAnchoredFromNormalizedPosition
{
    public class GetAnchoredFromNormalizedPositionUseCase : IGetAnchoredFromNormalizedPositionUseCase
    {
        private readonly RectTransform avaliableDirectionSpace;

        public GetAnchoredFromNormalizedPositionUseCase(
            RectTransform avaliableDirectionSpace
            )
        {
            this.avaliableDirectionSpace = avaliableDirectionSpace;
        }

        public float Execute(float normalizedPosition)
        {
            return avaliableDirectionSpace.rect.width * normalizedPosition; ;
        }
    }
}
