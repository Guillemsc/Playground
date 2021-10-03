using Juce.Core.Events.Generic;
using Juce.CoreUnity.Physics;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Entities
{
    public class ShipEntityView : MonoBehaviour
    {
        [SerializeField] private PhysicsCallbacks physicsCallbacks = default;

        public event GenericEvent<ShipEntityView, Collider2DData> OnTrigger;

        public int InstanceId { get; private set; }

        private void Awake()
        {
            physicsCallbacks.OnPhysicsTriggerEnter2D += OnPhysicsTriggerEnter2D;
        }

        protected void OnDestroy()
        {
            OnTrigger = null;
            physicsCallbacks.OnPhysicsTriggerEnter2D -= OnPhysicsTriggerEnter2D;
        }

        public void Init(int instanceId)
        {
            InstanceId = instanceId;
        }

        private void OnPhysicsTriggerEnter2D(PhysicsCallbacks physicsCallbacks, Collider2DData data)
        {
            OnTrigger?.Invoke(this, data);
        }
    }
}
