using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;
using Juce.Core.Events;
using Juce.Core.Loading;
using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.Services;
using JuceUnity.Core.DI.Extensions;
using Playground.Content.Stage.Logic.EntryPoint;
using Playground.Content.Stage.Logic.Setup;
using Playground.Content.Stage.Setup;
using Playground.Content.Stage.VisualLogic.EntryPoint;
using Playground.Content.Stage.VisualLogic.Setup;
using Playground.Contexts.StageUI;
using Playground.Services;
using Playground.Services.ViewStack;
using System.Threading.Tasks;
using UnityEngine;

namespace Playground.Contexts.Stage
{
    public class StageContext : Context
    {
        [SerializeField] private StageContextReferences stageContextReferences;

        protected override void Init()
        {
            ContextsProvider.Register(this);
            AddCleanupAction(() => ContextsProvider.Unregister(this));
        }

        public Task LoadStage(StageSetup stageSetup)
        {
            TaskCompletionSource<object> stageLoadedTaskCompletionSource = new TaskCompletionSource<object>();

            ILoadingToken stageLoadedToken = new CallbackLoadingToken(() => stageLoadedTaskCompletionSource.SetResult(default));

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

            LogicStageSetup logicStageSetup = new LogicStageSetup(
                new LogicShipSetup()
                );

            VisualLogicStageSetup visualLogicStageSetup = new VisualLogicStageSetup(
                new VisualLogicShipSetup(stageSetup.ShipSetup.ShipEntityView),
                new VisualLogicSectionsSetup(
                    stageSetup.SectionsSetup.DistanceBetweenSections, 
                    stageSetup.SectionsSetup.Sections
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
                    viewToLogicEventDispatcherAndReceiver,
                    logicToViewEventDispatcherAndReceiver,
                    c.Resolve<TickablesService>(),
                    c.Resolve<TimeService>(),
                    c.Resolve<UIViewStackService>(),
                    c.Resolve<PersistenceService>(),
                    visualLogicStageSetup,
                    stageContextReferences,
                    stageUIContext.ActionInputDetectionUIInteractor
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

            return stageLoadedTaskCompletionSource.Task;
        }
    }
}
