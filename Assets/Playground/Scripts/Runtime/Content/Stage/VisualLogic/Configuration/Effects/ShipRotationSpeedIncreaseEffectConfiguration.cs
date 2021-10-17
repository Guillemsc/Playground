using UnityEngine;

namespace Playground.Configuration.Stage
{
    [CreateAssetMenu(fileName = nameof(ShipRotationSpeedIncreaseEffectConfiguration), menuName = "Playground/Configuration/Effect/ShipRotationSpeedIncrease", order = 1)]
    public class ShipRotationSpeedIncreaseEffectConfiguration : EffectConfiguration
    {
        [SerializeField, Min(0)] private float ammount = default;
        [SerializeField, Min(0)] private float duration = default;

        public float Ammount => ammount;
        public float Duration => duration;

        public override void Accept(IEffectConfigurationVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
