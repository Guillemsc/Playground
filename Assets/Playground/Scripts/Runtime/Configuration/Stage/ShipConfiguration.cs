using Playground.Content.Stage.Setup;
using Playground.Content.Stage.VisualLogic.Entities;
using UnityEngine;

namespace Playground.Configuration.Stage
{
    [CreateAssetMenu(fileName = nameof(ShipConfiguration), menuName = "Playground/Configuration/" + nameof(ShipConfiguration), order = 1)]
    public class ShipConfiguration : ScriptableObject
    {
        [SerializeField] private ShipEntityView shipEntityView = default;

        public ShipSetup ToSetup()
        {
            return new ShipSetup(shipEntityView);
        }
    }
}
