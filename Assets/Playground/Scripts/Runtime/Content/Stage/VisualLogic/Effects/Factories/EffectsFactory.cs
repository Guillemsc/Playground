using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Time;
using Juce.CoreUnity.Tickables;
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

        public void Visit(ShipForwardSpeedIncreaseEffectConfiguration visitor)
        {
            IEffect effect = new ShipForwardSpeedModifiedEffect(
                shipStats,
                visitor.Ammount
                );

            TimeTrigger trigger = new TimeTrigger(
                timeContext.NewTimer(),
                TimeSpan.FromSeconds(visitor.Duration)
                );

            newCreation = GenerateEffectWithTimeTriggerExpiratorDisposable(
                effect,
                trigger
                );
        }

        public void Visit(ShipForwardSpeedDecreaseEffectConfiguration visitor)
        {
            IEffect effect = new ShipForwardSpeedModifiedEffect(
                shipStats,
                -visitor.Ammount
                );

            TimeTrigger trigger = new TimeTrigger(
                timeContext.NewTimer(),
                TimeSpan.FromSeconds(visitor.Duration)
                );

            newCreation = GenerateEffectWithTimeTriggerExpiratorDisposable(
                effect,
                trigger
                );
        }

        public void Visit(ShipRotationSpeedIncreaseEffectConfiguration visitor)
        {
            IEffect effect = new ShipRotationSpeedModifiedEffect(
               shipStats,
               visitor.Ammount
               );

            TimeTrigger trigger = new TimeTrigger(
                timeContext.NewTimer(),
                TimeSpan.FromSeconds(visitor.Duration)
                );

            newCreation = GenerateEffectWithTimeTriggerExpiratorDisposable(
                effect,
                trigger
                );
        }

        public void Visit(ShipRotationSpeedDecreaseEffectConfiguration visitor)
        {
            IEffect effect = new ShipRotationSpeedModifiedEffect(
               shipStats,
               -visitor.Ammount
               );

            TimeTrigger trigger = new TimeTrigger(
                timeContext.NewTimer(),
                TimeSpan.FromSeconds(visitor.Duration)
                );

            newCreation = GenerateEffectWithTimeTriggerExpiratorDisposable(
                effect,
                trigger
                );
        }

        private IDisposable<EffectWithTriggerExpirator> GenerateEffectWithTimeTriggerExpiratorDisposable(
            IEffect effect,
            TimeTrigger timeTrigger
            )
        {
            EffectWithTriggerExpirator effectWithTriggerExpirator = new EffectWithTriggerExpirator(
                effect,
                timeTrigger
                );

            effectWithTriggerExpirator.Enable();

            timeTriggersTickable.Add(timeTrigger);

            return new Disposable<EffectWithTriggerExpirator>(
                effectWithTriggerExpirator,
                (o) =>
                {
                    effectWithTriggerExpirator.Disable();

                    timeTriggersTickable.Remove(timeTrigger);
                });
        }
    }
}
