using Juce.Core.Triggers;
using System;

namespace Playground.Content.Stage.VisualLogic.Effects
{
    public class EffectWithTriggerExpirator
    {
        private readonly IEffect effect;
        private readonly ITrigger expirator;

        private bool enabled;

        public event Action OnExpired;

        public EffectWithTriggerExpirator(
            IEffect effect,
            ITrigger expirator
            )
        {
            this.effect = effect;
            this.expirator = expirator;
        }

        public void Enable()
        {
            if(enabled)
            {
                return;
            }

            enabled = true;

            effect.Enable();

            expirator.OnTrigger += () =>
            {
                Disable();

                OnExpired?.Invoke();
            };
        }

        public void Disable()
        {
            if (!enabled)
            {
                return;
            }

            enabled = false;

            expirator.OnTrigger -= Disable;

            effect.Disable();
        }
    }
}
