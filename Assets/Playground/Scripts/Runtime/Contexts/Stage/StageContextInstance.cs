using Cinemachine;
using Playground.Configuration.Stage;
using UnityEngine;

namespace Playground.Contexts.Stage
{
    public class StageContextInstance : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private StageSettings stageSettings = default;

        [Header("Cameras")]
        [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera = default;

        [Header("Parents")]
        [SerializeField] private Transform shipParent = default;
        [SerializeField] private Transform sectionsParent = default;
        [SerializeField] private Transform pointGoalsParent = default;

        [Header("Start Positions")]
        [SerializeField] private Transform shipStartPosition = default;
        [SerializeField] private Transform sectionsStartPosition = default;
        [SerializeField] private Transform cameraStartingTarget = default;

        public StageSettings StageSettings => stageSettings;

        public CinemachineVirtualCamera CinemachineVirtualCamera => cinemachineVirtualCamera;

        public Transform ShipParent => shipParent;
        public Transform SectionsParent => sectionsParent;
        public Transform PointGoalsParent => pointGoalsParent;

        public Transform ShipStartPosition => shipStartPosition;
        public Transform SectionsStartPosition => sectionsStartPosition;
        public Transform CameraStartingTarget => cameraStartingTarget;
    }
}
