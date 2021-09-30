using Juce.Core.Disposables;
using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.StartShipMovement
{
    public class StartShipMovementUseCase : IStartShipMovementUseCase
    {
        private readonly ShipEntityViewMovementTickable shipEntityViewMovementTickable;

        public StartShipMovementUseCase(ShipEntityViewMovementTickable shipEntityViewMovementTickable)
        {
            this.shipEntityViewMovementTickable = shipEntityViewMovementTickable;
        }

        public void Execute(ShipEntityView shipEntityView)
        {
            shipEntityViewMovementTickable.Start(shipEntityView.transform);
            shipEntityViewMovementTickable.Enabled = true;
        }
    }
}
