using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;
using Juce.CoreUnity.Contexts;
using Playground.Content.StageUI.Installers;
using Playground.Content.StageUI.UI.ActionInputDetection;
using Playground.Content.StageUI.UI.Coins;
using Playground.Content.StageUI.UI.DirectionSelector;
using Playground.Content.StageUI.UI.Effects;
using Playground.Content.StageUI.UI.Points;
using Playground.Content.StageUI.UI.ToasterTexts;
using UnityEngine;

namespace Playground.Contexts.StageUI
{
    public class StageUIContext : IStageUIContext
    {
        //[SerializeField] private StageUIContextReferences stageUIContextReferences;

        public IDIContainer Container { get; private set; }

        //protected override void Init()
        //{
        //    IDIContainerBuilder containerBuilder = new DIContainerBuilder();

        //    containerBuilder.Bind(new ServicesInstaller());

        //    containerBuilder.Bind(
        //        stageUIContextReferences.ActionInputDetectionUIInstaller,
        //        stageUIContextReferences.MainStageUIInstaller,
        //        stageUIContextReferences.DirectionSelectorUIInstaller,
        //        stageUIContextReferences.EffectsUIInstaller,
        //        stageUIContextReferences.PointsUIInstaller,
        //        stageUIContextReferences.CoinsUIInstaller,
        //        stageUIContextReferences.ToasterTextsUIInstaller
        //        );

        //    IDIContainer container = containerBuilder.Build();
        //    AddCleanupAction(container.Dispose);

        //    CreateFinalContainer(container);

        //    ContextsProvider.Register<IStageUIContext>(this);
        //    AddCleanupAction(() => ContextsProvider.Unregister<IStageUIContext>());
        //}

        //private void CreateFinalContainer(IDIContainer container)
        //{
        //    IDIContainerBuilder finalContainerBuilder = new DIContainerBuilder();

        //    finalContainerBuilder.Bind<IActionInputDetectionUIInteractor>().FromContainer(container);
        //    finalContainerBuilder.Bind<IDirectionSelectorUIInteractor>().FromContainer(container);
        //    finalContainerBuilder.Bind<IEffectsUIInteractor>().FromContainer(container);
        //    finalContainerBuilder.Bind<IPointsUIInteractor>().FromContainer(container);
        //    finalContainerBuilder.Bind<ICoinsUIInteractor>().FromContainer(container);
        //    finalContainerBuilder.Bind<IToasterTextsUIInteractor>().FromContainer(container);

        //    Container = finalContainerBuilder.Build();
        //}
    }
}
