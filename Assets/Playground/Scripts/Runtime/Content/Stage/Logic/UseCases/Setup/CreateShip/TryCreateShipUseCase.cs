using Juce.Core.Factories;
using Juce.Core.Repositories;
using Playground.Content.Stage.Logic.Entities;
using Playground.Content.Stage.Logic.Setup;

namespace Playground.Content.Stage.Logic.UseCases.TryCreateShip
{
    public class TryCreateShipUseCase : ITryCreateShipUseCase
    {
        private readonly IFactory<ShipLogicSetup, ShipEntity> shipEntityFactory;
        private readonly ISingleRepository<ShipEntity> shipEntityRepository;

        public TryCreateShipUseCase(
            IFactory<ShipLogicSetup, ShipEntity> shipEntityFactory,
            ISingleRepository<ShipEntity> shipEntityRepository
            )
        {
            this.shipEntityFactory = shipEntityFactory;
            this.shipEntityRepository = shipEntityRepository;
        }

        public bool Execute(ShipLogicSetup setup, out ShipEntity shipEntity)
        {
            bool couldCreate = shipEntityFactory.TryCreate(setup, out shipEntity);

            if(!couldCreate)
            {
                shipEntity = default;
                return false;
            }

            shipEntityRepository.Set(shipEntity);

            return true;
        }
    }
}
