using Cinemachine;
using UnityEngine;

namespace Playground.Contexts.Stage
{
    [System.Serializable]
    public class StageContextReferences 
    {
        [Header("Cameras")]
        [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera = default;

        [Header("Parents")]
        [SerializeField] private Transform shipParent = default;
        [SerializeField] private Transform sectionsParent = default;

        public CinemachineVirtualCamera CinemachineVirtualCamera => cinemachineVirtualCamera;

        public Transform ShipParent => shipParent;
        public Transform SectionsParent => sectionsParent;
    }
}
