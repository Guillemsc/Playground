using Playground.Content.Stage.Logic.Entities;

namespace Playground.Content.Stage.Logic.Snapshots
{
    public class ShipEntitySnapshot 
    {
        public int InstanceId { get; }

        public ShipEntitySnapshot(ShipEntity shipEntity)
        {
            InstanceId = shipEntity.InstanceId;
        }

        public static ShipEntitySnapshot ToSnapshot(ShipEntity shipEntity)
        {
            return new ShipEntitySnapshot(shipEntity);
        }
    }
}
