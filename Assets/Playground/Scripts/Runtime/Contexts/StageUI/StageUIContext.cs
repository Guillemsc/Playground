using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;
using Juce.CoreUnity.Contexts;
using Playground.Content.StageUI.Installers;
using Playground.Content.StageUI.UI.ActionInputDetection;
using Playground.Content.StageUI.UI.DirectionSelector;
using System.Collections.Generic;
using UnityEngine;

namespace Playground.Contexts.StageUI
{
    public class StageUIContext : Context
    {
        [SerializeField] private StageUIContextReferences stageUIContextReferences;

        public IDIContainer Container { get; private set; }

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

            CreateFinalContainer(container);

            ContextsProvider.Register(this);
            AddCleanupAction(() => ContextsProvider.Unregister(this));
        }

        private void CreateFinalContainer(IDIContainer container)
        {
            IDIContainerBuilder finalContainerBuilder = new DIContainerBuilder();

            finalContainerBuilder.Bind<IActionInputDetectionUIInteractor>().FromContainer(container);
            finalContainerBuilder.Bind<IDirectionSelectorUIInteractor>().FromContainer(container);

            Container = finalContainerBuilder.Build();
        }
    }
}
