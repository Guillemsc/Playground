using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Entities
{
    public readonly struct ShipEntityViewDefinition
    {
        public int InstanceId { get; }
        public Vector2 Position { get; }

        public ShipEntityViewDefinition(
            int instanceId,
            Vector2 position
            )
        {
            InstanceId = instanceId;
            Position = position;
        }
    }
}
