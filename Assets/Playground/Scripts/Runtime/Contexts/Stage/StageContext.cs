using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;
using Juce.Core.Events;
using Juce.Core.Loading;
using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.Tickables;
using Juce.CoreUnity.Time;
using JuceUnity.Core.DI.Extensions;
using Playground.Content.Stage.Logic.EntryPoint;
using Playground.Content.Stage.Logic.Setup;
using Playground.Content.Stage.Setup;
using Playground.Content.Stage.UseCases.StageFinished;
using Playground.Content.Stage.VisualLogic.EntryPoint;
using Playground.Content.Stage.VisualLogic.Setup;
using Playground.Contexts.Stage.UseCases.LoadStage;
using Playground.Contexts.StageUI;
using Playground.Services;
using Playground.Services.Persistence;
using Playground.Services.ViewStack;
using System.Threading.Tasks;
using UnityEngine;

namespace Playground.Contexts.Stage
{
    public class StageContext : IStageContext
    {
        private readonly ILoadStageUseCase loadStageUseCase;

        public StageContext(
            ILoadStageUseCase loadStageUseCase
            )
        {
            this.loadStageUseCase = loadStageUseCase;
        }

        public Task LoadStage(StageSetup stageSetup, IStageFinishedUseCase stageFinishedUseCase)
        {
            return loadStageUseCase.Execute();
        }

        //public Task LoadStage(StageSetup stageSetup, IStageFinishedUseCase stageFinishedUseCase)
        //{
        //    TaskCompletionSource<object> stageLoadedTaskCompletionSource = new TaskCompletionSource<object>();

        //    ILoadingToken stageLoadedToken = new CallbackLoadingToken(
        //        () => stageLoadedTaskCompletionSource.SetResult(default)
        //        );

        //    StageUIContext stageUIContext = ContextsProvider.GetContext<StageUIContext>();

        //    EventDispatcherAndReceiver logicToViewEventDispatcherAndReceiver = new EventDispatcherAndReceiver();
        //    EventDispatcherAndReceiver viewToLogicEventDispatcherAndReceiver = new EventDispatcherAndReceiver();

        //    EventDispatcherAndReceiverTickable logicToViewTickable = new EventDispatcherAndReceiverTickable(
        //        logicToViewEventDispatcherAndReceiver
        //        );
        //    EventDispatcherAndReceiverTickable viewToLogicTickable = new EventDispatcherAndReceiverTickable(
        //        viewToLogicEventDispatcherAndReceiver
        //        );

        //    IDIContainerBuilder containerBuilder = new DIContainerBuilder();

        //    //containerBuilder.Bind<ITickablesService>().FromServicesProvider();
        //    //containerBuilder.Bind<ITimeService>().FromServicesProvider();
        //    //containerBuilder.Bind<UIViewStackService>().FromServicesProvider();
        //    //containerBuilder.Bind<ConfigurationService>().FromServicesProvider();
        //    //containerBuilder.Bind<PersistenceService>().FromServicesProvider();

        //    StageLogicSetup logicStageSetup = new StageLogicSetup(
        //        new ShipLogicSetup()
        //        );

        //    StageVisualLogicSetup visualLogicStageSetup = new StageVisualLogicSetup(
        //        new ShipVisualLogicSetup(
        //            stageSetup.ShipSetup.ShipEntityView,
        //            stageSetup.ShipSetup.ShipMaxSpeed,
        //            stageSetup.ShipSetup.ShipRotationSpeed
        //            ),

        //        new SectionsVisualLogicSetup(
        //            stageSetup.SectionsSetup.DistanceBetweenSections, 
        //            stageSetup.SectionsSetup.Sections,
        //            stageSetup.SectionsSetup.SpawnEffectProbabilty,
        //            stageSetup.SectionsSetup.SpawnCoinProbabilty
        //            ),

        //        new PointGoalsVisualLogicSetup(
        //            stageSetup.PointGoalsSetup.DistanceBetweenPointGoals,
        //            stageSetup.PointGoalsSetup.Prefab
        //            ),

        //        new EffectsVisualLogicSetup(
        //            stageSetup.EffectsSetup.SpawnPercentageProbabiliby,
        //            stageSetup.EffectsSetup.Effects
        //            ),

        //        new CoinsVisualLogicSetup(
        //            stageSetup.CoinsSetup.SpawnPercentageProbabiliby,
        //            stageSetup.CoinsSetup.Prefab
        //            ),

        //        new DirectionSelectorVisualLogicSetup(
        //            stageSetup.DirectionSelectorSetup.BaseSpeedMultiplier
        //            )
        //        );

        //    containerBuilder.Bind<StageLogicEntryPoint>()
        //        .FromFunction((c) => new StageLogicEntryPoint(
        //            logicToViewEventDispatcherAndReceiver,
        //            viewToLogicEventDispatcherAndReceiver,
        //            logicStageSetup
        //            ));

        //    containerBuilder.Bind<StageVisualLogicEntryPoint>()
        //        .FromFunction((c) => new StageVisualLogicEntryPoint(
        //            stageLoadedToken,
        //            stageFinishedUseCase,
        //            viewToLogicEventDispatcherAndReceiver,
        //            logicToViewEventDispatcherAndReceiver,
        //            c.Resolve<TickablesService>(),
        //            c.Resolve<ITimeService>(),
        //            c.Resolve<UIViewStackService>(),
        //            c.Resolve<PersistenceService>(),
        //            visualLogicStageSetup,
        //            stageContextReferences,
        //            stageUIContext.Container
        //            ))
        //        .WhenDispose((c) => c.CleanUp());

        //    IDIContainer container = containerBuilder.Build();
        //    AddCleanupAction(container.Dispose);

        //    StageLogicEntryPoint stageLogicEntryPoint = container.Resolve<StageLogicEntryPoint>();
        //    StageVisualLogicEntryPoint stageVisualLogicEntryPoint = container.Resolve<StageVisualLogicEntryPoint>();

        //    stageLogicEntryPoint.Execute();

        //    TickablesService tickablesService = container.Resolve<TickablesService>();

        //    tickablesService.AddTickable(logicToViewTickable);
        //    AddCleanupAction(() => tickablesService.RemoveTickable(logicToViewTickable));

        //    tickablesService.AddTickable(viewToLogicTickable);
        //    AddCleanupAction(() => tickablesService.RemoveTickable(viewToLogicTickable));

        //    SRDebug.Instance.AddOptionContainer(stageLogicEntryPoint.StageLogicCheats);
        //    AddCleanupAction(() => SRDebug.Instance.RemoveOptionContainer(stageLogicEntryPoint.StageLogicCheats));

        //    SRDebug.Instance.AddOptionContainer(stageVisualLogicEntryPoint.StageVisualLogicCheats);
        //    AddCleanupAction(() => SRDebug.Instance.RemoveOptionContainer(stageVisualLogicEntryPoint.StageVisualLogicCheats));

        //    return stageLoadedTaskCompletionSource.Task;
        //}
    }
}
