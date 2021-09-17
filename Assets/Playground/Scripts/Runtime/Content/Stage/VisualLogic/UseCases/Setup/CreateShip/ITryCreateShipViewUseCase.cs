using Juce.Core.Disposables;
using Playground.Content.Stage.Logic.Snapshots;
using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.CreateShipView
{
    public interface ITryCreateShipViewUseCase
    {
        bool Execute(
            ShipEntitySnapshot shipEntitySnapshot,
            out IDisposable<ShipEntityView> shipEntityView
            );
    }
}
