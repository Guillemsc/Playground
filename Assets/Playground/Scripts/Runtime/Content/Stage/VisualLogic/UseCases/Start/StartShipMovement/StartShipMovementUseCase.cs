using Juce.Core.Disposables;
using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.SetupStage
{
    public class StartShipMovementUseCase : IStartShipMovementUseCase
    {
        private readonly ShipEntityViewMovementTickable shipEntityViewMovementTickable;

        public StartShipMovementUseCase(ShipEntityViewMovementTickable shipEntityViewMovementTickable)
        {
            this.shipEntityViewMovementTickable = shipEntityViewMovementTickable;
        }

        public void Execute(IDisposable<ShipEntityView> shipEntityView)
        {
            shipEntityViewMovementTickable.Start(shipEntityView.Value.transform);
            shipEntityViewMovementTickable.Enabled = true;
        }
    }
}
