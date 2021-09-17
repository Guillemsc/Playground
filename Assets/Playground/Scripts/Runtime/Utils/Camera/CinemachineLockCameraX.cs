using UnityEngine;
using Cinemachine;

namespace Playground.Utils.Camera
{
    [ExecuteInEditMode] [SaveDuringPlay] [AddComponentMenu("")] 
    public class CinemachineLockCameraX : CinemachineExtension
    {
        [Tooltip("Lock the camera's X position to this value")]
        [SerializeField] private float xPosition = 0;

        protected override void PostPipelineStageCallback(
            CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, 
            ref CameraState state, 
            float deltaTime
            )
        {
            if(stage != CinemachineCore.Stage.Finalize)
            {
                return;
            }

            Vector3 currentPosition = state.RawPosition;
            currentPosition.x = xPosition;

            state.RawPosition = currentPosition;
        }
    }
}
