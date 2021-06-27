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
        private readonly CinemachinePath cinemachinePath;

        public AttachCameraToCarInstruction(
            CarViewRepository carViewRepository,
            CinemachineVirtualCamera cinemachineVirtualCamera,
            CinemachinePath cinemachinePath
            )
        {
            this.carViewRepository = carViewRepository;
            this.cinemachineVirtualCamera = cinemachineVirtualCamera;
            this.cinemachinePath = cinemachinePath;
        }

        public void Execute()
        {
            if(cinemachinePath == null)
            {
                UnityEngine.Debug.LogError($"{nameof(CinemachinePath)} is null at {nameof(AttachCameraToCarInstruction)}");
            }

            CinemachineComposer composer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineComposer>();
            CinemachineTrackedDolly trackedDolly = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
            CinemachineFollowZoom followZoom = cinemachineVirtualCamera.GetComponent<CinemachineFollowZoom>();

            float lastHorizontalDamping = composer.m_HorizontalDamping;
            float lastVerticalDamping = composer.m_VerticalDamping;
            float lastFollowZoomDamping = followZoom.m_Damping;

            composer.m_HorizontalDamping = 0;
            composer.m_VerticalDamping = 0;

            followZoom.m_Damping = 0;

            cinemachineVirtualCamera.LookAt = carViewRepository.Item.transform;
            cinemachineVirtualCamera.Follow = carViewRepository.Item.transform;

            trackedDolly.m_Path = cinemachinePath;

            cinemachineVirtualCamera.InternalUpdateCameraState(Vector3.up, 1.0f);

            composer.m_HorizontalDamping = lastHorizontalDamping;
            composer.m_VerticalDamping = lastVerticalDamping;
            followZoom.m_Damping = lastFollowZoomDamping;
        }
    }
}
