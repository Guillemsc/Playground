namespace Playground.Content.Stage.VisualLogic.Entities
{
    public readonly struct SectionEntityViewDefinition
    {
        public int InstanceId { get; }
        public string TypeId { get; }

        public SectionEntityViewDefinition(
            int instanceId,
            string typeId
            )
        {
            InstanceId = instanceId;
            TypeId = typeId;
        }
    }
}
