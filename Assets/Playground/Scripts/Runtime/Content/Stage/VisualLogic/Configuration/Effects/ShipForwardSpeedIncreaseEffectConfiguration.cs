using UnityEngine;

namespace Playground.Configuration.Stage
{
    [CreateAssetMenu(fileName = nameof(ShipForwardSpeedIncreaseEffectConfiguration), menuName = "Playground/Configuration/Effect/ShipForwardSpeedIncrease", order = 1)]
    public class ShipForwardSpeedIncreaseEffectConfiguration : EffectConfiguration
    {
        [Header("Specific")]
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
