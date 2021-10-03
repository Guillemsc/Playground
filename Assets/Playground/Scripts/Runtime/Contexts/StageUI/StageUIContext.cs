using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;
using Juce.CoreUnity.Contexts;
using Playground.Content.StageUI.Installers;
using Playground.Content.StageUI.UI.ActionInputDetection;
using UnityEngine;

namespace Playground.Contexts.StageUI
{
    public class StageUIContext : Context
    {
        [SerializeField] private StageUIContextReferences stageUIContextReferences;

        public IActionInputDetectionUIInteractor ActionInputDetectionUIInteractor { get; private set; }

        protected override void Init()
        {
            IDIContainerBuilder containerBuilder = new DIContainerBuilder();

            containerBuilder.Bind(new ServicesInstaller());
            containerBuilder.Bind(stageUIContextReferences.ActionInputDetectionUIInstaller);

            IDIContainer container = containerBuilder.Build();
            AddCleanupAction(container.Dispose);

            ActionInputDetectionUIInteractor = container.Resolve<IActionInputDetectionUIInteractor>();

            ContextsProvider.Register(this);
            AddCleanupAction(() => ContextsProvider.Unregister(this));
        }
    }
}
