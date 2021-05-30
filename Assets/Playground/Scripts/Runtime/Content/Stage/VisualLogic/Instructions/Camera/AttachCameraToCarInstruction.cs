using Cinemachine;
using Cinemachine.PostFX;
using Playground.Content.Stage.VisualLogic.View.Car;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Instructions
{
    public class AttachCameraToCarInstruction
    {
        private readonly CarViewRepository carViewRepository;
        private readonly CinemachineVirtualCamera cinemachineVirtualCamera;

        public AttachCameraToCarInstruction(
            CarViewRepository carViewRepository,
            CinemachineVirtualCamera cinemachineVirtualCamera
            )
        {
            this.carViewRepository = carViewRepository;
            this.cinemachineVirtualCamera = cinemachineVirtualCamera;
        }

        public void Execute()
        {
            CinemachineComposer composer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineComposer>();
            CinemachineFollowZoom followZoom = cinemachineVirtualCamera.GetComponent<CinemachineFollowZoom>();
            CinemachinePostProcessing postProcessing = cinemachineVirtualCamera.GetComponent<CinemachinePostProcessing>();

            float lastHorizontalDamping = composer.m_HorizontalDamping;
            float lastVerticalDamping = composer.m_VerticalDamping;
            float lastFollowZoomDamping = followZoom.m_Damping;

            composer.m_HorizontalDamping = 0;
            composer.m_VerticalDamping = 0;

            followZoom.m_Damping = 0;

            cinemachineVirtualCamera.LookAt = carViewRepository.CarView.transform;
            //postProcessing.m_FocusTarget = carViewRepository.CarView.transform;

            cinemachineVirtualCamera.InternalUpdateCameraState(Vector3.up, 1.0f);

            composer.m_HorizontalDamping = lastHorizontalDamping;
            composer.m_VerticalDamping = lastVerticalDamping;
            followZoom.m_Damping = lastFollowZoomDamping;
        }
    }
}
