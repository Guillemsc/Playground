using UnityEngine;

namespace Playground.Configuration.Stage
{
    [CreateAssetMenu(fileName = nameof(StageConfiguration), menuName = "Playground/Configuration/" + nameof(StageConfiguration), order = 1)]
    public class StageConfiguration : ScriptableObject
    {
        [SerializeField] private ShipConfiguration shipConfiguration = default;

        public ShipConfiguration ShipConfiguration => shipConfiguration;
    }
}
