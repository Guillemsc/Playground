using UnityEngine;

namespace Playground.Contexts.Cameras
{
    [System.Serializable]
    public class CamerasContextReferences
    {
        [Header("References")]
        [SerializeField] private Camera mainCamera = default;

        public Camera MainCamera => mainCamera;
    }
}
