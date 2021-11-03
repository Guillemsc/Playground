using Playground.Content.Stage.VisualLogic.Setup;
using Playground.Content.Stage.VisualLogic.UseCases.TrySpawnRandomSectionEffect;
using Playground.Content.Stage.VisualLogic.UseCases.TrySpawnSectionCoin;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.UseCases.TrySpawnRandomSectionElement
{
    public class TrySpawnRandomSectionElementUseCase : ITrySpawnRandomSectionElementUseCase
    {
        private readonly SectionsVisualLogicSetup visualLogicSectionsSetup;
        private readonly ITrySpawnRandomSectionEffectUseCase trySpawnRandomSectionEffectUseCase;
        private readonly ITrySpawnSectionCoinUseCase trySpawnSectionCoinUseCase;

        public TrySpawnRandomSectionElementUseCase(
            SectionsVisualLogicSetup visualLogicSectionsSetup,
            ITrySpawnRandomSectionEffectUseCase trySpawnRandomSectionEffectUseCase,
            ITrySpawnSectionCoinUseCase trySpawnSectionCoinUseCase
            )
        {
            this.visualLogicSectionsSetup = visualLogicSectionsSetup;
            this.trySpawnRandomSectionEffectUseCase = trySpawnRandomSectionEffectUseCase;
            this.trySpawnSectionCoinUseCase = trySpawnSectionCoinUseCase;
        }

        public void Execute(Transform position)
        {
            Dictionary<float, Action> probabilities = new Dictionary<float, Action>();

            probabilities.Add(
                visualLogicSectionsSetup.SpawnEffectProbabilty, 
                () => trySpawnRandomSectionEffectUseCase.Execute(position)
                );

            probabilities.Add(
                visualLogicSectionsSetup.SpawnCoinProbabilty,
                () => trySpawnSectionCoinUseCase.Execute(position)
                );

            float totalProbability = 0.0f;

            foreach(KeyValuePair<float, Action> value in probabilities)
            {
                totalProbability += value.Key;
            }

            float randomValue = UnityEngine.Random.Range(0f, totalProbability);

            float accumulatedProbability = 0.0f;

            foreach (KeyValuePair<float, Action> value in probabilities)
            {
                accumulatedProbability += value.Key;

                if (randomValue < accumulatedProbability)
                {
                    value.Value?.Invoke();
                    return;
                }
            }
        }
    }
}
