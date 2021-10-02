using Playground.Content.Stage.VisualLogic.UseCases.StopShipMovement;

namespace Playground.Content.Stage.VisualLogic.UseCases.ShipDestroyed
{
    public class ShipDestroyedUseCase : IShipDestroyedUseCase
    {
        private readonly IStopShipMovementUseCase stopShipMovementUseCase;

        public ShipDestroyedUseCase(
            IStopShipMovementUseCase stopShipMovementUseCase
            )
        {
            this.stopShipMovementUseCase = stopShipMovementUseCase;
        }

        public void Execute()
        {
            stopShipMovementUseCase.Execute();
        }
    }
}
