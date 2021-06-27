using System.Collections.Generic;
using UnityEngine;

namespace Playground.Configuration.Stage
{
    [CreateAssetMenu(fileName = "StageRewardsConfiguration", menuName = "Playground/Configuration/StageRewardsConfiguration", order = 1)]
    public class StageRewardsConfiguration : ScriptableObject
    {
        [SerializeField] [Min(0)] private int star1SoftCurrencyReward = default;
        [SerializeField] [Min(0)] private int star2SoftCurrencyReward = default;
        [SerializeField] [Min(0)] private int star3SoftCurrencyReward = default;

        public int Star1SoftCurrencyReward => star1SoftCurrencyReward;
        public int Star2SoftCurrencyReward => star2SoftCurrencyReward;
        public int Star3SoftCurrencyReward => star3SoftCurrencyReward;
    }
}
