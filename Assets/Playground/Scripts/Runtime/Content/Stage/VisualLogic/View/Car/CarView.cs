using Juce.CoreUnity.Contracts;
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

        public CarViewController CarViewController => carViewController;

        private void Awake()
        {
            Contract.IsNotNull(carViewController, this);
            Contract.IsNotNull(rigidBody, this);
            Contract.IsNotNull(wheelCollidersParent, this);
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
    }
}
