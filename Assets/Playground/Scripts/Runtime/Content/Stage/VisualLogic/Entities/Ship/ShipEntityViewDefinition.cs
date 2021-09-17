namespace Playground.Content.Stage.VisualLogic.Entities
{
    public readonly struct ShipEntityViewDefinition
    {
        public int InstanceId { get; }
        public string TypeId { get; }

        public ShipEntityViewDefinition(
            int instanceId,
            string typeId
            )
        {
            InstanceId = instanceId;
            TypeId = typeId;
        }
    }
}
