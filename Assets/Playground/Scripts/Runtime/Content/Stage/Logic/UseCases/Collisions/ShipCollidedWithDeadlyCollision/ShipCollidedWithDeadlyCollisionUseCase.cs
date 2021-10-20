using Juce.Core.Events;
using Juce.Core.Repositories;
using Playground.Content.Stage.Logic.Entities;
using Playground.Content.Stage.Logic.Events;

namespace Playground.Content.Stage.Logic.UseCases.ShipCollidedWithDeadlyCollision
{
    public class ShipCollidedWithDeadlyCollisionUseCase : IShipCollidedWithDeadlyCollisionUseCase
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly IReadOnlySingleRepository<ShipEntity> shipEntityRepository;

        public ShipCollidedWithDeadlyCollisionUseCase(
            IEventDispatcher eventDispatcher,
            IReadOnlySingleRepository<ShipEntity> shipEntityRepository
            )
        {
            this.eventDispatcher = eventDispatcher;
            this.shipEntityRepository = shipEntityRepository;
        }

        public void Execute(int shipInstanceId)
        {
            bool found = shipEntityRepository.TryGet(out ShipEntity shipEntity);

            if(!found)
            {
                return;
            }

            if(shipEntity.Destroyed)
            {
                return;
            }

            if(shipEntity.Mechanics.Immortality.Active)
            {
                return;
            }

            shipEntity.Destroyed = true;

            eventDispatcher.Dispatch(new ShipDestroyedOutEvent());
        }
    }
}
