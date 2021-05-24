using Juce.Core.Events.Generic;
using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.Physics;
using Juce.TweenPlayer;
using Playground.Content.Stage.VisualLogic.View.Car;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.View.CheckPoints
{
    public class CheckPointView : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PhysicsCallbacks physicsCallbacks = default;

        [Header("Feedbacks")]
        [SerializeField] private TweenPlayer setActiveFeedback = default;
        [SerializeField] private TweenPlayer setCrossedFeedback = default;

        public int Index { get; private set; }

        public event GenericEvent<CheckPointView, ColliderData> OnCrossed;

        private void Awake()
        {
            Contract.IsNotNull(physicsCallbacks, this);
            Contract.IsNotNull(setCrossedFeedback, this);

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

        public void SetAsActive()
        {
            setActiveFeedback.Play();
        }

        public void SetAsCrossed()
        {
            setCrossedFeedback.Play();
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
