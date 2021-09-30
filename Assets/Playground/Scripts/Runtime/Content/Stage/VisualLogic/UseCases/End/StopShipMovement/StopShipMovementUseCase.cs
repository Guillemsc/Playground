using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.StopShipMovement
{
    public class StopShipMovementUseCase : IStopShipMovementUseCase
    {
        private readonly ShipEntityViewMovementTickable shipEntityViewMovementTickable;

        public StopShipMovementUseCase(
            ShipEntityViewMovementTickable shipEntityViewMovementTickable
            )
        {
            this.shipEntityViewMovementTickable = shipEntityViewMovementTickable;
        }

        public void Execute()
        {
            shipEntityViewMovementTickable.Enabled = false;
        }
    }
}
