using Juce.Core.Disposables;
using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.SetupCamera
{
    public interface ISetupCameraUseCase
    {
        void Execute(IDisposable<ShipEntityView> shipEntityView);
    }
}
