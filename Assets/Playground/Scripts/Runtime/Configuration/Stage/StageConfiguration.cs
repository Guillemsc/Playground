using Playground.Content.Stage.Setup;
using UnityEngine;

namespace Playground.Configuration.Stage
{
    [CreateAssetMenu(fileName = nameof(StageConfiguration), menuName = "Playground/Configuration/" + nameof(StageConfiguration), order = 1)]
    public class StageConfiguration : ScriptableObject
    {
        [SerializeField] private ShipConfiguration shipConfiguration = default;
        [SerializeField] private SectionsConfiguration sectionsConfiguration = default;
        [SerializeField] private DirectionSelectorConfiguration directionSelectorConfiguration = default;

        public StageSetup ToSetup()
        {
            return new StageSetup(
                shipConfiguration.ToSetup(),
                sectionsConfiguration.ToSetup(),
                directionSelectorConfiguration.ToSetup()
                );
        }
    }
}
