using Cinemachine;
using Juce.Core.Disposables;
using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.SetupCamera
{
    public class SetupCameraUseCase : ISetupCameraUseCase
    {
        private readonly CinemachineVirtualCamera cinemachineVirtualCamera;

        public SetupCameraUseCase(CinemachineVirtualCamera cinemachineVirtualCamera)
        {
            this.cinemachineVirtualCamera = cinemachineVirtualCamera;
        }

        public void Execute(IDisposable<ShipEntityView> shipEntityView)
        {
            cinemachineVirtualCamera.Follow = shipEntityView.Value.transform;

            cinemachineVirtualCamera.PreviousStateIsValid = false;
        }
    }
}
