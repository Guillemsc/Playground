using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.View.Car
{
    [System.Serializable]
    public class CarViewSteeringWheelData
    {
        [SerializeField] private Transform steeringWheelTransform = default;
        [SerializeField] private float rotationOffset = default;

        public Transform SteeringWheelTransform => steeringWheelTransform;
        public float RotationOffset => rotationOffset;
    }
}
