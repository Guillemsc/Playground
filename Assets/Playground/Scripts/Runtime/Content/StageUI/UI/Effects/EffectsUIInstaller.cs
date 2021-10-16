using Juce.Core.DI.Builder;
using Juce.Core.DI.Extensions;
using Juce.Core.DI.Installers;
using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;
using Juce.CoreUnity.Layout;
using JuceUnity.Core.DI.Extensions;
using Playground.Content.Stage.VisualLogic.Effects;
using Playground.Content.StageUI.UI.Effects.Entries;
using Playground.Content.StageUI.UI.Effects.Factories;
using Playground.Content.StageUI.UI.Effects.UseCases.DespawnEffectEntry;
using Playground.Content.StageUI.UI.Effects.UseCases.EffectAdded;
using Playground.Content.StageUI.UI.Effects.UseCases.EffectExpired;
using Playground.Content.StageUI.UI.Effects.UseCases.TrySpawnEffectEntry;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Content.StageUI.UI.Effects
{
    [RequireComponent(typeof(EffectsUIView))]
    public class EffectsUIInstaller : MonoBehaviour, IInstaller
    {
        [Header("References")]
        [SerializeField] private ManualHorizontalLayout manualHorizontalLayout = default;

        [Header("Prefabs")]
        [SerializeField] private EffectUIEntry effectUIEntryPrefab = default;

        public void Install(IDIContainerBuilder container)
        {
            container.Bind<EffectsUIViewModel>().FromNew();

            container.Bind<EffectsUIView>()
                .FromGameObject(gameObject)
                .WhenInit((c, o) => o.Init(c.Resolve<EffectsUIViewModel>()))
                .WhenInit((c, o) => c.Resolve<UIViewStackService>().Register(
                    c.Resolve<IEffectsUIInteractor>(),
                    o
                    ))
                .WhenDispose((c, o) => c.Resolve<UIViewStackService>().Unregister(o))
                .NonLazy();

            container.Bind(InstallUseCases);

            container.Bind<EffectsUIController>()
                .FromFunction(c => new EffectsUIController(
                    c.Resolve<EffectsUIViewModel>()
                    ))
                .LinkSubscribable()
                .NonLazy();

            container.Bind<IEffectsUIInteractor, EffectsUIInteractor>()
                .FromFunction(c => new EffectsUIInteractor(
                    c.Resolve<EffectsUIViewModel>(),
                    c.Resolve<IEffectAddedUseCase>(),
                    c.Resolve<IEffectExpiredUseCase>()
                    ))
                .LinkSubscribable()
                .NonLazy();
        }

        private void InstallUseCases(IDIContainerBuilder container)
        {
            container.Bind<IFactory<EffectUIEntryFactoryDefinition, IDisposable<EffectUIEntry>>>()
                .FromFunction(c => new EffectUIEntryFactory(
                    effectUIEntryPrefab
                    ));

            container.Bind<IKeyValueRepository<EffectWithTriggerExpirator, IDisposable<EffectUIEntry>>,
                SimpleKeyValueRepository<EffectWithTriggerExpirator, IDisposable<EffectUIEntry>>>()
                .FromNew();

            container.Bind<IRepository<IDisposable<EffectUIEntry>>, SimpleRepository<IDisposable<EffectUIEntry>>>()
                .FromNew();

            container.Bind<ITrySpawnEffectEntryUseCase>()
                .FromFunction(c => new TrySpawnEffectEntryUseCase(
                    c.Resolve<IFactory<EffectUIEntryFactoryDefinition, IDisposable<EffectUIEntry>>>(),
                    c.Resolve<IRepository<IDisposable<EffectUIEntry>>>()
                    ));

            container.Bind<IDespawnEffectEntryUseCase>()
                .FromFunction(c => new DespawnEffectEntryUseCase(
                    c.Resolve<IRepository<IDisposable<EffectUIEntry>>>()
                    ));

            container.Bind<IEffectAddedUseCase>()
                .FromFunction(c => new EffectAddedUseCase(
                    manualHorizontalLayout,
                    c.Resolve<IKeyValueRepository<EffectWithTriggerExpirator, IDisposable<EffectUIEntry>>>(),
                    c.Resolve<ITrySpawnEffectEntryUseCase>()
                    ));

            container.Bind<IEffectExpiredUseCase>()
                .FromFunction(c => new EffectExpiredUseCase(
                    manualHorizontalLayout,
                    c.Resolve<IKeyValueRepository<EffectWithTriggerExpirator, IDisposable<EffectUIEntry>>>(),
                    c.Resolve<IDespawnEffectEntryUseCase>()
                    ));
        }
    }
}
