using Cinemachine;
using Playground.Configuration.Stage;
using UnityEngine;

namespace Playground.Contexts.Stage
{
    [System.Serializable]
    public class StageContextReferences 
    {
        [Header("Settings")]
        [SerializeField] private StageSettings stageSettings = default;

        [Header("Cameras")]
        [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera = default;

        [Header("Parents")]
        [SerializeField] private Transform shipParent = default;
        [SerializeField] private Transform sectionsParent = default;

        [Header("Misc")]
        [SerializeField] private Transform sectionsStartPosition = default;

        public StageSettings StageSettings => stageSettings;

        public CinemachineVirtualCamera CinemachineVirtualCamera => cinemachineVirtualCamera;

        public Transform ShipParent => shipParent;
        public Transform SectionsParent => sectionsParent;

        public Transform SectionsStartPosition => sectionsStartPosition;
    }
}
