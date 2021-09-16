using Juce.Core.Factories;
using Juce.Core.Id;
using Playground.Content.Stage.Logic.Setup;

namespace Playground.Content.Stage.Logic.Entities
{
    public class ShipEntityFactory : IFactory<LogicShipSetup, ShipEntity>
    {
        private readonly IIdGenerator idGenerator;

        public ShipEntityFactory(IIdGenerator idGenerator)
        {
            this.idGenerator = idGenerator;
        }

        public bool TryCreate(LogicShipSetup definition, out ShipEntity creation)
        {
            int instanceId = idGenerator.Generate();

            creation = new ShipEntity(
                instanceId,
                definition.TypeId
                );
            return true;
        }
    }
}
