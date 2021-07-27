using Cinemachine;
using UnityEngine;

namespace Playground.Contexts
{
    [System.Serializable]
    public class StageContextReferences 
    {
        [Header("References")]
        [SerializeField] private Camera mainCamera = default;
        [SerializeField] private CinemachineVirtualCamera followCarVirtualCamera = default;

        public Camera MainCamera => mainCamera;
        public CinemachineVirtualCamera FollowCarVirtualCamera => followCarVirtualCamera;
    }
}
