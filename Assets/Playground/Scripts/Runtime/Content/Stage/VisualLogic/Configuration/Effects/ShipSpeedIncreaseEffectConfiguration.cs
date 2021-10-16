using UnityEngine;

namespace Playground.Configuration.Stage
{
    [CreateAssetMenu(fileName = nameof(ShipSpeedIncreaseEffectConfiguration), menuName = "Playground/Configuration/Effect/ShipSpeedIncrease", order = 1)]
    public class ShipSpeedIncreaseEffectConfiguration : EffectConfiguration
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
