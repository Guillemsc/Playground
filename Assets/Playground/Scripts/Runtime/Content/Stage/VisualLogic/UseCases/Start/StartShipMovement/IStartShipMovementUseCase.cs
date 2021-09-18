using Juce.Core.Disposables;
using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.SetupStage
{
    public interface IStartShipMovementUseCase
    {
        void Execute(IDisposable<ShipEntityView> shipEntityView);
    }
}
