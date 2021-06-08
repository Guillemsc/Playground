using UnityEngine;

namespace Playground.Configuration.CarSettings
{
    [CreateAssetMenu(fileName = "CarControllerConfiguration", menuName = "Playground/CarControllerConfiguration", order = 1)]
    public class CarControllerConfiguration : ScriptableObject
    {
        [SerializeField] [Min(0)] private float torque = 6000.0f;
        [SerializeField] [Min(0)] private float steering = 300.0f;
        [SerializeField] [Min(0)] private float unsteering = 300.0f;
        [SerializeField] [Range(0, 180)] private float maxSteeringAngle = 40.0f;

        public float Torque => torque;
        public float Steering => steering;
        public float Unsteering => unsteering;
        public float MaxSteeringAngle => maxSteeringAngle;
    }
}
