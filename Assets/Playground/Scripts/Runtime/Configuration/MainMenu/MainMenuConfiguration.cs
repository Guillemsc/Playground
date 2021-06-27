using UnityEngine;

namespace Playground.Configuration.MainMenu
{
    [CreateAssetMenu(fileName = "MainMenuConfiguration", menuName = "Playground/MainMenuConfiguration", order = 1)]
    public class MainMenuConfiguration : ScriptableObject
    {
        [SerializeField] [Min(0)] private float manualRotationMultiplier = default;
        [SerializeField] [Min(0)] private float carCarryRotationMultiplier = default;
        [SerializeField] [Min(0)] private float carCarryRotationDecelerationTime = default;
        [SerializeField] private AnimationCurve carCarryRotationDecelerationCurve = default;

        public float ManualRotationMultiplier => manualRotationMultiplier;
        public float CarCarryRotationMultiplier => carCarryRotationMultiplier;
        public float CarCarryRotationDecelerationTime => carCarryRotationDecelerationTime;
        public AnimationCurve CarCarryRotationDecelerationCurve => carCarryRotationDecelerationCurve;
    }
}
