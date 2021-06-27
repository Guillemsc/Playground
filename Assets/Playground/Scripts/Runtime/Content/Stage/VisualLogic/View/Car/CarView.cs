using Juce.CoreUnity.Contracts;
using System.Collections.Generic;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.View.Car
{
    public class CarView : MonoBehaviour
    {
        [Header("Controller")]
        [SerializeField] private CarViewController carViewController = default;

        [Header("References")]
        [SerializeField] private Rigidbody rigidBody = default;
        [SerializeField] private Transform wheelCollidersParent = default;
        [SerializeField] private List<CarViewSteeringWheelData> steeringWheelsTransforms = default;

        public string TypeId { get; private set; }
        public CarViewController CarViewController => carViewController;

        private void Awake()
        {
            Contract.IsNotNull(carViewController, this);
            Contract.IsNotNull(rigidBody, this);
            Contract.IsNotNull(wheelCollidersParent, this);
        }

        public void Init(string typeId)
        {
            TypeId = typeId;
        }

        public void EnablePhysics()
        {
            rigidBody.isKinematic = false;
            wheelCollidersParent.gameObject.SetActive(true);
        }

        public void DisablePhysics()
        {
            rigidBody.isKinematic = transform;
            wheelCollidersParent.gameObject.SetActive(false);
        }

        public void SetSteering(float steerAngle)
        {
            foreach(CarViewSteeringWheelData steeringWheelData in steeringWheelsTransforms)
            {
                if(steeringWheelData == null)
                {
                    continue;
                }

                if(steeringWheelData.SteeringWheelTransform == null)
                {
                    continue;
                }

                Vector3 currentRotation = steeringWheelData.SteeringWheelTransform.localRotation.eulerAngles;
                steeringWheelData.SteeringWheelTransform.localRotation = Quaternion.Euler(
                    currentRotation.x, 
                    steerAngle + steeringWheelData.RotationOffset, 
                    currentRotation.z
                    );
            }
        }
    }
}
