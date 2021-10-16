﻿using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;
using Playground.Configuration.Stage;
using Playground.Content.Stage.VisualLogic.Effects;
using Playground.Content.Stage.VisualLogic.UseCases.RemoveEffect;

namespace Playground.Content.Stage.VisualLogic.UseCases.AddEffect
{
    public class AddEffectUseCase : IAddEffectUseCase
    {
        private readonly IFactory<EffectConfiguration, IDisposable<EffectWithTriggerExpirator>> effectsFactory;
        private readonly IRepository<IDisposable<EffectWithTriggerExpirator>> effectsRepository;
        private readonly IRemoveEffectUseCase removeEffectUseCase;

        public AddEffectUseCase(
            IFactory<EffectConfiguration, IDisposable<EffectWithTriggerExpirator>> effectsFactory,
            IRepository<IDisposable<EffectWithTriggerExpirator>> effectsRepository,
            IRemoveEffectUseCase removeEffectUseCase
            )
        {
            this.effectsFactory = effectsFactory;
            this.effectsRepository = effectsRepository;
            this.removeEffectUseCase = removeEffectUseCase;
        }

        public void Execute(EffectConfiguration effectConfiguraiton)
        {
            bool created = effectsFactory.TryCreate(effectConfiguraiton, out IDisposable<EffectWithTriggerExpirator> creation);

            if(!created)
            {
                UnityEngine.Debug.LogError($"{nameof(EffectWithTriggerExpirator)} could not be created," +
                    $" at {nameof(AddEffectUseCase)}");
                return;
            }

            effectsRepository.Add(creation);

            creation.Value.OnExpired += () => removeEffectUseCase.Execute(creation);
        }
    }
}
