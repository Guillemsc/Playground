using Cinemachine;
using UnityEngine;

namespace Playground.Contexts
{
    [System.Serializable]
    public class StageContextReferences 
    {
        [Header("References")]
        [SerializeField] private CinemachineVirtualCamera followCarVirtualCamera = default;

        public CinemachineVirtualCamera FollowCarVirtualCamera => followCarVirtualCamera;
    }
}
