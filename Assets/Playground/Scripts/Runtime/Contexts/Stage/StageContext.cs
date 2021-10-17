﻿using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;
using Juce.Core.Events;
using Juce.Core.Loading;
using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.Services;
using JuceUnity.Core.DI.Extensions;
using Playground.Content.Stage.Logic.EntryPoint;
using Playground.Content.Stage.Logic.Setup;
using Playground.Content.Stage.Setup;
using Playground.Content.Stage.UseCases.StageFinished;
using Playground.Content.Stage.VisualLogic.EntryPoint;
using Playground.Content.Stage.VisualLogic.Setup;
using Playground.Contexts.StageUI;
using Playground.Services;
using Playground.Services.ViewStack;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Playground.Contexts.Stage
{
    public class StageContext : Context
    {
        [SerializeField] private StageContextReferences stageContextReferences;

        public event Action OnStageFinished;

        protected override void Init()
        {
            ContextsProvider.Register(this);
            AddCleanupAction(() => ContextsProvider.Unregister(this));
        }

        public Task LoadStage(StageSetup stageSetup)
        {
            TaskCompletionSource<object> stageLoadedTaskCompletionSource = new TaskCompletionSource<object>();

            ILoadingToken stageLoadedToken = new CallbackLoadingToken(
                () => stageLoadedTaskCompletionSource.SetResult(default)
                );

            IStageFinishedUseCase stageFinishedUseCase = new StageFinishedUseCase(OnStageFinished);

            StageUIContext stageUIContext = ContextsProvider.GetContext<StageUIContext>();

            EventDispatcherAndReceiver logicToViewEventDispatcherAndReceiver = new EventDispatcherAndReceiver();
            EventDispatcherAndReceiver viewToLogicEventDispatcherAndReceiver = new EventDispatcherAndReceiver();

            EventDispatcherAndReceiverTickable logicToViewTickable = new EventDispatcherAndReceiverTickable(
                logicToViewEventDispatcherAndReceiver
                );
            EventDispatcherAndReceiverTickable viewToLogicTickable = new EventDispatcherAndReceiverTickable(
                viewToLogicEventDispatcherAndReceiver
                );

            IDIContainerBuilder containerBuilder = new DIContainerBuilder();

            containerBuilder.Bind<TickablesService>().FromServicesProvider();
            containerBuilder.Bind<TimeService>().FromServicesProvider();
            containerBuilder.Bind<UIViewStackService>().FromServicesProvider();
            containerBuilder.Bind<ConfigurationService>().FromServicesProvider();
            containerBuilder.Bind<PersistenceService>().FromServicesProvider();

            StageLogicSetup logicStageSetup = new StageLogicSetup(
                new ShipLogicSetup()
                );

            StageVisualLogicSetup visualLogicStageSetup = new StageVisualLogicSetup(
                new ShipVisualLogicSetup(
                    stageSetup.ShipSetup.ShipEntityView,
                    stageSetup.ShipSetup.ShipMaxSpeed,
                    stageSetup.ShipSetup.ShipRotationSpeed
                    ),

                new SectionsVisualLogicSetup(
                    stageSetup.SectionsSetup.DistanceBetweenSections, 
                    stageSetup.SectionsSetup.Sections
                    ),

                new EffectsVisualLogicSetup(
                    stageSetup.EffectsSetup.Effects
                    ),

                new DirectionSelectorSetup(
                    stageSetup.DirectionSelectorSetup.BaseSpeedMultiplier
                    )
                );

            containerBuilder.Bind<StageLogicEntryPoint>()
                .FromFunction((c) => new StageLogicEntryPoint(
                    logicToViewEventDispatcherAndReceiver,
                    viewToLogicEventDispatcherAndReceiver,
                    logicStageSetup
                    ));

            containerBuilder.Bind<StageVisualLogicEntryPoint>()
                .FromFunction((c) => new StageVisualLogicEntryPoint(
                    stageLoadedToken,
                    stageFinishedUseCase,
                    viewToLogicEventDispatcherAndReceiver,
                    logicToViewEventDispatcherAndReceiver,
                    c.Resolve<TickablesService>(),
                    c.Resolve<TimeService>(),
                    c.Resolve<UIViewStackService>(),
                    c.Resolve<PersistenceService>(),
                    visualLogicStageSetup,
                    stageContextReferences,
                    stageUIContext.Container
                    ))
                .WhenDispose((c) => c.CleanUp());

            IDIContainer container = containerBuilder.Build();
            AddCleanupAction(container.Dispose);

            StageLogicEntryPoint stageLogicEntryPoint = container.Resolve<StageLogicEntryPoint>();
            StageVisualLogicEntryPoint stageVisualLogicEntryPoint = container.Resolve<StageVisualLogicEntryPoint>();

            stageLogicEntryPoint.Execute();

            TickablesService tickablesService = container.Resolve<TickablesService>();

            tickablesService.AddTickable(logicToViewTickable);
            AddCleanupAction(() => tickablesService.RemoveTickable(logicToViewTickable));

            tickablesService.AddTickable(viewToLogicTickable);
            AddCleanupAction(() => tickablesService.RemoveTickable(viewToLogicTickable));

            SRDebug.Instance.AddOptionContainer(stageLogicEntryPoint.StageLogicCheats);
            AddCleanupAction(() => SRDebug.Instance.RemoveOptionContainer(stageLogicEntryPoint.StageLogicCheats));

            SRDebug.Instance.AddOptionContainer(stageVisualLogicEntryPoint.StageVisualLogicCheats);
            AddCleanupAction(() => SRDebug.Instance.RemoveOptionContainer(stageVisualLogicEntryPoint.StageVisualLogicCheats));

            return stageLoadedTaskCompletionSource.Task;
        }
    }
}
