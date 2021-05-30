using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.View.Car.Wheels
{
    public class WheelConfigurationApplier : MonoBehaviour
    {
        [SerializeField] private WheelCollider wheelCollider = default;
        [SerializeField] private WheelConfiguration wheelConfiguration = default;

        private void Update()
        {
            JointSpring spring = wheelCollider.suspensionSpring;
            WheelFrictionCurve forwardFriction = wheelCollider.forwardFriction;
            WheelFrictionCurve sidewaysFriction = wheelCollider.sidewaysFriction;

            wheelCollider.mass = wheelConfiguration.Mass;
            wheelCollider.radius = wheelConfiguration.Radius;
            wheelCollider.wheelDampingRate = wheelConfiguration.WheelDampingRate;
            wheelCollider.suspensionDistance = wheelConfiguration.SuspensionDistance;
            wheelCollider.forceAppPointDistance = wheelConfiguration.ForceAppPointDistance;

            wheelCollider.center = wheelConfiguration.Center;

            spring.spring = wheelConfiguration.Spring;
            spring.damper = wheelConfiguration.Damper;
            spring.targetPosition = wheelConfiguration.TargetPosition;

            forwardFriction.extremumSlip = wheelConfiguration.ForwardExtremumSlip;
            forwardFriction.extremumValue = wheelConfiguration.ForwardExtremumValue;
            forwardFriction.asymptoteSlip = wheelConfiguration.ForwardAsymptoteSlip;
            forwardFriction.asymptoteValue = wheelConfiguration.ForwardAsymptoteValue;
            forwardFriction.stiffness = wheelConfiguration.ForwardStiffness;

            sidewaysFriction.extremumSlip = wheelConfiguration.SidewaysExtremumSlip;
            sidewaysFriction.extremumValue = wheelConfiguration.SidewaysExtremumValue;
            sidewaysFriction.asymptoteSlip = wheelConfiguration.SidewaysAsymptoteSlip;
            sidewaysFriction.asymptoteValue = wheelConfiguration.SidewaysAsymptoteValue;
            sidewaysFriction.stiffness = wheelConfiguration.SidewaysStiffness;

            wheelCollider.suspensionSpring = spring;
            wheelCollider.forwardFriction = forwardFriction;
            wheelCollider.sidewaysFriction = sidewaysFriction;
        }
    }
}
