using Juce.Core.Factories;
using Playground.Content.Stage.Logic.Entities;
using Playground.Content.Stage.Logic.Setup;

namespace Playground.Content.Stage.Logic.UseCases.TryCreateShip
{
    public class TryCreateShipUseCase : ITryCreateShipUseCase
    {
        private readonly IFactory<LogicShipSetup, ShipEntity> shipEntityFactory;
        private readonly IRepository<int, ShipEntity> shipEntityRepository;

        public TryCreateShipUseCase(
            IFactory<LogicShipSetup, ShipEntity> shipEntityFactory,
            IRepository<int, ShipEntity> shipEntityRepository
            )
        {
            this.shipEntityFactory = shipEntityFactory;
            this.shipEntityRepository = shipEntityRepository;
        }

        public bool Execute(LogicShipSetup setup, out ShipEntity shipEntity)
        {
            bool couldCreate = shipEntityFactory.TryCreate(setup, out shipEntity);

            if(!couldCreate)
            {
                shipEntity = default;
                return false;
            }

            shipEntityRepository.Add(shipEntity.InstanceId, shipEntity);

            return true;
        }
    }
}
