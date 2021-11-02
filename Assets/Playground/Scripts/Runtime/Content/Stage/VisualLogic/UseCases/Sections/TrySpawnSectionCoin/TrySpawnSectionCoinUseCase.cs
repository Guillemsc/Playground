using Juce.Core.Disposables;
using Juce.Core.Factories;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.Setup;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.UseCases.TrySpawnSectionCoin
{
    public class TrySpawnSectionCoinUseCase : ITrySpawnSectionCoinUseCase
    {
        private readonly IFactory<CoinEntityViewDefinition, IDisposable<CoinEntityView>> coinEntityViewFactory;
        private readonly CoinsVisualLogicSetup coinsVisualLogicSetup;

        public TrySpawnSectionCoinUseCase(
            IFactory<CoinEntityViewDefinition, IDisposable<CoinEntityView>> coinEntityViewFactory,
            CoinsVisualLogicSetup coinsVisualLogicSetup
            )
        {
            this.coinEntityViewFactory = coinEntityViewFactory;
            this.coinsVisualLogicSetup = coinsVisualLogicSetup;
        }

        public void Execute(Transform position)
        {
            float randomProbability = Random.Range(0, 100f);

            if (randomProbability > coinsVisualLogicSetup.SpawnPercentageProbabiliby)
            {
                return;
            }

            bool created = coinEntityViewFactory.TryCreate(
                new CoinEntityViewDefinition(
                    coinsVisualLogicSetup.Prefab
                    ),
                out IDisposable<CoinEntityView> coinEntityView
                );

            if (!created)
            {
                UnityEngine.Debug.LogError("Coin could not be created");
                return;
            }

            coinEntityView.Value.transform.SetParent(position, worldPositionStays: false);
        }
    }
}
