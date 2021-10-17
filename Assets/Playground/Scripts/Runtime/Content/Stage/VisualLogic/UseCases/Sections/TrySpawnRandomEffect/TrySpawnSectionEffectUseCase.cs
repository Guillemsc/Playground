﻿using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;
using Playground.Content.Stage.Setup;
using Playground.Content.Stage.VisualLogic.Entities;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.UseCases.TrySpawnSectionEffect
{
    public class TrySpawnSectionEffectUseCase : ITrySpawnSectionEffectUseCase
    {
        private readonly IFactory<EffectEntityViewDefinition, IDisposable<EffectEntityView>> effectEntityViewFactory;
        private readonly IRepository<IDisposable<EffectEntityView>> effectEntityViewRepository;
        private readonly EffectsVisualLogicSetup effectsVisualLogicSetup;

        public TrySpawnSectionEffectUseCase(
            IFactory<EffectEntityViewDefinition, IDisposable<EffectEntityView>> effectEntityViewFactory,
            IRepository<IDisposable<EffectEntityView>> effectEntityViewRepository,
            EffectsVisualLogicSetup effectsVisualLogicSetup
            )
        {
            this.effectEntityViewFactory = effectEntityViewFactory;
            this.effectEntityViewRepository = effectEntityViewRepository;
            this.effectsVisualLogicSetup = effectsVisualLogicSetup;
        }

        public void Execute(Transform position)
        {
            if (effectsVisualLogicSetup.Effects.Count == 0)
            {
                UnityEngine.Debug.LogError("No avaliable effects to spawn");
                return;
            }

            int randomIndex = Random.Range(0, effectsVisualLogicSetup.Effects.Count);

            EffectEntityView prefab = effectsVisualLogicSetup.Effects[randomIndex];

            bool created = effectEntityViewFactory.TryCreate(
                new EffectEntityViewDefinition(
                    prefab
                    ),
                out IDisposable<EffectEntityView> effectEntityView
                );

            if (!created)
            {
                UnityEngine.Debug.LogError("Effect could not be created");
                return;
            }

            effectEntityViewRepository.Add(effectEntityView);
        }
    }
}
