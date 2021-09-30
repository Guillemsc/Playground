using Juce.Core.Disposables;
using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.StartShipMovement
{
    public interface IStartShipMovementUseCase
    {
        void Execute(ShipEntityView shipEntityView);
    }
}
