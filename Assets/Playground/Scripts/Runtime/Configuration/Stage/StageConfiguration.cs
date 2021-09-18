using Playground.Content.Stage.Setup;
using UnityEngine;

namespace Playground.Configuration.Stage
{
    [CreateAssetMenu(fileName = nameof(StageConfiguration), menuName = "Playground/Configuration/" + nameof(StageConfiguration), order = 1)]
    public class StageConfiguration : ScriptableObject
    {
        [SerializeField] private ShipConfiguration shipConfiguration = default;
        [SerializeField] private SectionsConfiguration sectionsConfiguration = default;

        public ShipConfiguration ShipConfiguration => shipConfiguration;
        public SectionsConfiguration SectionsConfiguration => sectionsConfiguration;

        public StageSetup ToSetup()
        {
            return new StageSetup(
                ShipConfiguration.ToSetup(),
                SectionsConfiguration.ToSetup()
                );
        }
    }
}
