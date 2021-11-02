using Playground.Content.Stage.Setup;
using UnityEngine;

namespace Playground.Configuration.Stage
{
    [CreateAssetMenu(fileName = nameof(StageConfiguration), menuName = "Playground/Configuration/Stage/" + nameof(StageConfiguration), order = 1)]
    public class StageConfiguration : ScriptableObject
    {
        [SerializeField] private ShipConfiguration shipConfiguration = default;
        [SerializeField] private SectionsConfiguration sectionsConfiguration = default;
        [SerializeField] private PointGoalsConfiguration pointGoalsConfiguration = default;
        [SerializeField] private EffectsConfiguration effectsConfiguration = default;
        [SerializeField] private CoinsConfiguration coinsConfiguration = default;
        [SerializeField] private DirectionSelectorConfiguration directionSelectorConfiguration = default;

        public StageSetup ToSetup()
        {
            return new StageSetup(
                shipConfiguration.ToSetup(),
                sectionsConfiguration.ToSetup(),
                pointGoalsConfiguration.ToSetup(),
                effectsConfiguration.ToSetup(),
                coinsConfiguration.ToSetup(),
                directionSelectorConfiguration.ToSetup()
                );
        }
    }
}
