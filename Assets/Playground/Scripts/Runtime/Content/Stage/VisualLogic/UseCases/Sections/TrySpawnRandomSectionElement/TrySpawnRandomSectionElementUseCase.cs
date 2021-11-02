using Playground.Content.Stage.VisualLogic.UseCases.TrySpawnRandomSectionEffect;
using Playground.Content.Stage.VisualLogic.UseCases.TrySpawnSectionCoin;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.UseCases.TrySpawnRandomSectionElement
{
    public class TrySpawnRandomSectionElementUseCase : ITrySpawnRandomSectionElementUseCase
    {
        private readonly ITrySpawnRandomSectionEffectUseCase trySpawnRandomSectionEffectUseCase;
        private readonly ITrySpawnSectionCoinUseCase trySpawnSectionCoinUseCase;

        public TrySpawnRandomSectionElementUseCase(
            ITrySpawnRandomSectionEffectUseCase trySpawnRandomSectionEffectUseCase,
            ITrySpawnSectionCoinUseCase trySpawnSectionCoinUseCase
            )
        {
            this.trySpawnRandomSectionEffectUseCase = trySpawnRandomSectionEffectUseCase;
            this.trySpawnSectionCoinUseCase = trySpawnSectionCoinUseCase;
        }

        public void Execute(Transform position)
        {
            int randomValue = UnityEngine.Random.Range(0, 2);

            if(randomValue == 0)
            {
                trySpawnRandomSectionEffectUseCase.Execute(position);
            }
            else
            {
                trySpawnSectionCoinUseCase.Execute(position);
            }
        }
    }
}
