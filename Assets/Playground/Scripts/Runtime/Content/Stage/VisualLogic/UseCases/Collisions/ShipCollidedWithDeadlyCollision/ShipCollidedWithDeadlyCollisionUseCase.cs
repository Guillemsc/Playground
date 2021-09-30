using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.UseCases.StopShipMovement;

namespace Playground.Content.Stage.VisualLogic.UseCases.ShipCollidedWithDeadlyCollision
{
    public class ShipCollidedWithDeadlyCollisionUseCase : IShipCollidedWithDeadlyCollisionUseCase
    {
        private readonly IStopShipMovementUseCase stopShipMovementUseCase;

        public ShipCollidedWithDeadlyCollisionUseCase(
            IStopShipMovementUseCase stopShipMovementUseCase
            )
        {
            this.stopShipMovementUseCase = stopShipMovementUseCase;
        }

        public void Execute(ShipEntityView shipEntityView)
        {
            stopShipMovementUseCase.Execute();
        }
    }
}
