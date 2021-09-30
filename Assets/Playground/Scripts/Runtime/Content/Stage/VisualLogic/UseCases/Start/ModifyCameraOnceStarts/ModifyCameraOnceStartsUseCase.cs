using Cinemachine;
using Playground.Configuration.Stage;
using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.ModifyCameraOnceStarts
{
    public class ModifyCameraOnceStartsUseCase : IModifyCameraOnceStartsUseCase
    {
        private readonly CinemachineVirtualCamera cinemachineVirtualCamera;

        public ModifyCameraOnceStartsUseCase(
            CinemachineVirtualCamera cinemachineVirtualCamera
            )
        {
            this.cinemachineVirtualCamera = cinemachineVirtualCamera;
        }

        public void Execute(ShipEntityView shipEntityView)
        {
            cinemachineVirtualCamera.Follow = shipEntityView.transform;
        }
    }
}
