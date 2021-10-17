using Juce.Core.Events.Generic;
using Juce.CoreUnity.Physics;
using Juce.TweenPlayer;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Entities
{
    public class ShipEntityView : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PhysicsCallbacks physicsCallbacks = default;

        [Header("Tweens")]
        [SerializeField] private TweenPlayer startTween = default;
        [SerializeField] private TweenPlayer deathTween = default;

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

        public Task PlayStart(bool instantly, CancellationToken cancellationToken)
        {
            return startTween.Play(instantly, cancellationToken);
        }

        public Task PlayDeath(bool instantly, CancellationToken cancellationToken)
        {
            return deathTween.Play(instantly, cancellationToken);
        }

        private void OnPhysicsTriggerEnter2D(PhysicsCallbacks physicsCallbacks, Collider2DData data)
        {
            OnTrigger?.Invoke(this, data);
        }
    }
}
