using Playground.Content.Stage.Setup;
using Playground.Content.Stage.VisualLogic.Entities;
using System.Collections.Generic;
using UnityEngine;

namespace Playground.Configuration.Stage
{
    [CreateAssetMenu(fileName = nameof(CoinsConfiguration), menuName = "Playground/Configuration/Stage/" + nameof(CoinsConfiguration), order = 1)]
    public class CoinsConfiguration : ScriptableObject
    {
        [SerializeField, Range(0, 100)] private float spawnPercentageProbabiliby = default;
        [SerializeField] private CoinEntityView prefab = default;

        public CoinsSetup ToSetup()
        {
            return new CoinsSetup(
                spawnPercentageProbabiliby,
                prefab
                );
        }
    }
}
