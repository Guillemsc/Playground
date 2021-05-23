using Cinemachine;
using Playground.Content.Stage.Libraries;
using UnityEngine;

namespace Playground.Contexts
{
    [System.Serializable]
    public class StageContextReferences 
    {
        [Header("References")]
        [SerializeField] private CinemachineVirtualCamera followCarVirtualCamera = default;

        [Header("Libraries")]
        [SerializeField] private CarLibrary carLibrary = default;

        public CinemachineVirtualCamera FollowCarVirtualCamera => followCarVirtualCamera;
        public CarLibrary CarLibrary => carLibrary;
    }
}
