using Playground.Content.Stage.Logic.Mechanics;

namespace Playground.Content.Stage.Logic.Entities
{
    public class ShipEntity
    {
        public int InstanceId { get; }

        public ShipMechanics Mechanics { get; } = new ShipMechanics();

        public bool Destroyed { get; set; }

        public ShipEntity(int instanceId)
        {
            InstanceId = instanceId;
        }
    }
}
