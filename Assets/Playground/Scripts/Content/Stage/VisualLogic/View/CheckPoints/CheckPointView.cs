using Juce.Core.Events.Generic;
using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.Physics;
using Playground.Content.Stage.VisualLogic.View.Car;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.View.CheckPoints
{
    public class CheckPointView : MonoBehaviour
    {
        [SerializeField] private PhysicsCallbacks physicsCallbacks = default;

        public int Index { get; private set; }

        public event GenericEvent<CheckPointView, ColliderData> OnCrossed;

        private void Awake()
        {
            Contract.IsNotNull(physicsCallbacks, this);

            physicsCallbacks.OnPhysicsTriggerEnter += OnPhysicsCallbacksTriggerEnter;
        }

        private void OnDestroy()
        {
            physicsCallbacks.OnPhysicsTriggerEnter -= OnPhysicsCallbacksTriggerEnter;
        }

        public void Init(int index)
        {
            Index = index;
        }

        private void OnPhysicsCallbacksTriggerEnter(PhysicsCallbacks physicsCallbacks, ColliderData colliderData)
        {
            CarViewCollider carView = colliderData.Collider.gameObject.GetComponent<CarViewCollider>();

            if(carView == null)
            {
                return;
            }

            OnCrossed?.Invoke(this, colliderData);
        }
    }
}
