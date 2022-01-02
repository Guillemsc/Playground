using UnityEngine;

namespace Playground.Contexts.Cameras
{
    public class CamerasContextInstance : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Camera mainCamera = default;

        public Camera MainCamera => mainCamera;
    }
}
