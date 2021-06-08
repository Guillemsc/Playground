using UnityEngine;

namespace Playground.Configuration.CarSettings
{
    [CreateAssetMenu(fileName = "WheelConfiguration", menuName = "Playground/WheelConfiguration", order = 1)]
    public class WheelConfiguration : ScriptableObject
    {
        [Header("General")]
        [SerializeField] [Min(0)] private float mass = 20.0f;
        [SerializeField] [Min(0)] private float radius = 0.5f;
        [SerializeField] [Min(0)] private float wheelDampingRate = 0.25f;
        [SerializeField] [Min(0)] private float suspensionDistance = 0.3f;
        [SerializeField] private float forceAppPointDistance = 0.0f;
        [SerializeField] private Vector3 center = Vector3.zero;

        [Header("Suspension spring")]
        [SerializeField] [Min(0)] private float spring = 35000.0f;
        [SerializeField] [Min(0)] private float damper = 4500.0f;
        [SerializeField] [Min(0)] private float targetPosition = 0.5f;

        [Header("Forward friction")]
        [SerializeField] [Min(0)] private float forwardExtremumSlip = 0.4f;
        [SerializeField] [Min(0)] private float forwardExtremumValue = 1.0f;
        [SerializeField] [Min(0)] private float forwardAsymptoteSlip = 0.8f;
        [SerializeField] [Min(0)] private float forwardAsymptoteValue = 0.5f;
        [SerializeField] [Min(0)] private float forwardStiffness = 1.0f;

        [Header("Sideways friction")]
        [SerializeField] [Min(0)] private float sidewaysExtremumSlip = 0.2f;
        [SerializeField] [Min(0)] private float sidewaysExtremumValue = 1.0f;
        [SerializeField] [Min(0)] private float sidewaysAsymptoteSlip = 0.5f;
        [SerializeField] [Min(0)] private float sidewaysAsymptoteValue = 0.75f;
        [SerializeField] [Min(0)] private float sidewaysStiffness = 1.0f;

        public float Mass => mass;
        public float Radius => radius;
        public float WheelDampingRate => wheelDampingRate;
        public float SuspensionDistance => suspensionDistance;
        public float ForceAppPointDistance => forceAppPointDistance;
        public Vector3 Center => center;
        public float Spring => spring;
        public float Damper => damper;
        public float TargetPosition => targetPosition;
        public float ForwardExtremumSlip => forwardExtremumSlip;
        public float ForwardExtremumValue => forwardExtremumValue;
        public float ForwardAsymptoteSlip => forwardAsymptoteSlip;
        public float ForwardAsymptoteValue => forwardAsymptoteValue;
        public float ForwardStiffness => forwardStiffness;
        public float SidewaysExtremumSlip => sidewaysExtremumSlip;
        public float SidewaysExtremumValue => sidewaysExtremumValue;
        public float SidewaysAsymptoteSlip => sidewaysAsymptoteSlip;
        public float SidewaysAsymptoteValue => sidewaysAsymptoteValue;
        public float SidewaysStiffness => sidewaysStiffness;
    }
}
