using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Time;
using Juce.CoreUnity.Services;
using Playground.Configuration.Stage;
using Playground.Content.Stage.VisualLogic.Stats;
using Playground.Content.Stage.VisualLogic.Tickables;
using Playground.Content.Stage.VisualLogic.Triggers;
using System;

namespace Playground.Content.Stage.VisualLogic.Effects
{
    public class EffectsFactory : IFactory<EffectConfiguration, IDisposable<EffectWithTriggerExpirator>>, 
        IEffectConfigurationVisitor
    {
        private readonly TimeTriggersTickable timeTriggersTickable;
        private readonly ShipStats shipStats;
        private readonly ITimeContext timeContext;

        private IDisposable<EffectWithTriggerExpirator> newCreation;

        public EffectsFactory(
            TimeTriggersTickable timeTriggersTickable,
            ShipStats shipStats,
            ITimeContext timeContext
            )
        {
            this.timeTriggersTickable = timeTriggersTickable;
            this.shipStats = shipStats;
            this.timeContext = timeContext;
        }

        public bool TryCreate(EffectConfiguration definition, out IDisposable<EffectWithTriggerExpirator> creation)
        {
            newCreation = null;

            definition.Accept(this);

            creation = newCreation;
            return creation != null;
        }

        public void Visit(ShipSpeedIncreaseEffectConfiguration visitor)
        {
            IEffect effect = new ShipSpeedModifiedEffect(
                shipStats,
                visitor.Ammount
                );

            TimeTrigger trigger = new TimeTrigger(
                timeContext.NewTimer(),
                TimeSpan.FromSeconds(visitor.Duration)
                );

            EffectWithTriggerExpirator effectWithTriggerExpirator = new EffectWithTriggerExpirator(
                effect,
                trigger
                );

            effectWithTriggerExpirator.Enable();

            timeTriggersTickable.Add(trigger);

            newCreation = new Disposable<EffectWithTriggerExpirator>(
                effectWithTriggerExpirator,
                (o) =>
                {
                    effectWithTriggerExpirator.Disable();

                    timeTriggersTickable.Remove(trigger);
                });
        }

        public void Visit(ShipSpeedDecreaseEffectConfiguration visitor)
        {
            IEffect effect = new ShipSpeedModifiedEffect(
                shipStats,
                -visitor.Ammount
                );

            TimeTrigger trigger = new TimeTrigger(
                timeContext.NewTimer(),
                TimeSpan.FromSeconds(visitor.Duration)
                );

            EffectWithTriggerExpirator effectWithTriggerExpirator = new EffectWithTriggerExpirator(
                effect,
                trigger
                );

            effectWithTriggerExpirator.Enable();

            timeTriggersTickable.Add(trigger);

            newCreation = new Disposable<EffectWithTriggerExpirator>(
                effectWithTriggerExpirator,
                (o) =>
                {
                    effectWithTriggerExpirator.Disable();

                    timeTriggersTickable.Remove(trigger);
                });
        }
    }
}
