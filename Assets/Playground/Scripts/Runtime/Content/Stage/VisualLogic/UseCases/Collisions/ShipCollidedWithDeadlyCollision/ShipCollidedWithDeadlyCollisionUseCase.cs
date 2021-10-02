using Juce.Core.Events;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.ShipCollidedWithDeadlyCollision
{
    public class ShipCollidedWithDeadlyCollisionUseCase : IShipCollidedWithDeadlyCollisionUseCase
    {
        private readonly IEventDispatcher eventDispatcher;

        public ShipCollidedWithDeadlyCollisionUseCase(
            IEventDispatcher eventDispatcher
            )
        {
            this.eventDispatcher = eventDispatcher;
        }

        public void Execute(ShipEntityView shipEntityView)
        {
            eventDispatcher.Dispatch(new ShipCollidedWithDeadlyCollisionInEvent(shipEntityView.InstanceId));
        }
    }
}
