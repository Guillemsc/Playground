using Playground.Content.Stage.Setup;
using Playground.Content.Stage.VisualLogic.Entities;
using UnityEngine;

namespace Playground.Configuration.Stage
{
    [CreateAssetMenu(fileName = nameof(ShipConfiguration), menuName = "Playground/Configuration/Stage/" + nameof(ShipConfiguration), order = 1)]
    public class ShipConfiguration : ScriptableObject
    {
        [Header("Prefab")]
        [SerializeField] private ShipEntityView shipEntityView = default;

        [Header("Stats")]
        [SerializeField] private float shipMaxSpeed = default;

        public ShipSetup ToSetup()
        {
            return new ShipSetup(
                shipEntityView,
                shipMaxSpeed
                );
        }
    }
}
