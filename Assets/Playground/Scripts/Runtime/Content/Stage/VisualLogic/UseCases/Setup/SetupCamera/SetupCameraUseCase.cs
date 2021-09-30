using Cinemachine;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.UseCases.SetupCamera
{
    public class SetupCameraUseCase : ISetupCameraUseCase
    {
        private readonly CinemachineVirtualCamera cinemachineVirtualCamera;
        private readonly Transform cameraStartingTarget;

        public SetupCameraUseCase(
            CinemachineVirtualCamera cinemachineVirtualCamera,
            Transform cameraStartingTarget
            )
        {
            this.cinemachineVirtualCamera = cinemachineVirtualCamera;
            this.cameraStartingTarget = cameraStartingTarget;
        }

        public void Execute()
        {
            cinemachineVirtualCamera.Follow = cameraStartingTarget;

            cinemachineVirtualCamera.PreviousStateIsValid = false;
        }
    }
}
