namespace Playground.Content.Stage.Logic.Entities
{
    public class ShipEntity
    {
        public int InstanceId { get; }
        public string TypeId { get; }

        public ShipEntity(
            int instanceId, 
            string typeId
            )
        {
            InstanceId = instanceId;
            TypeId = typeId;
        }
    }
}
