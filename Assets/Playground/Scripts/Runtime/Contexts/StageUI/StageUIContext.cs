using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;
using Juce.CoreUnity.Contexts;
using Playground.Content.StageUI.Installers;
using Playground.Content.StageUI.UI.ActionInputDetection;
using Playground.Content.StageUI.UI.DirectionSelector;
using UnityEngine;

namespace Playground.Contexts.StageUI
{
    public class StageUIContext : Context
    {
        [SerializeField] private StageUIContextReferences stageUIContextReferences;

        public IActionInputDetectionUIInteractor ActionInputDetectionUIInteractor { get; private set; }
        public IDirectionSelectorUIInteractor DirectionSelectorUIInteractor { get; private set; }

        protected override void Init()
        {
            IDIContainerBuilder containerBuilder = new DIContainerBuilder();

            containerBuilder.Bind(new ServicesInstaller());

            containerBuilder.Bind(
                stageUIContextReferences.ActionInputDetectionUIInstaller,
                stageUIContextReferences.DirectionSelectorUIInstaller
                );

            IDIContainer container = containerBuilder.Build();
            AddCleanupAction(container.Dispose);

            ActionInputDetectionUIInteractor = container.Resolve<IActionInputDetectionUIInteractor>();
            DirectionSelectorUIInteractor = container.Resolve<IDirectionSelectorUIInteractor>();

            ContextsProvider.Register(this);
            AddCleanupAction(() => ContextsProvider.Unregister(this));
        }
    }
}
