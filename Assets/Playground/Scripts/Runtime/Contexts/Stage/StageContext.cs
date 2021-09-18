using Juce.Core.Events;
using Juce.Core.Loading;
using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.Services;
using Playground.Content.Stage.Logic.EntryPoint;
using Playground.Content.Stage.Logic.Setup;
using Playground.Content.Stage.Setup;
using Playground.Content.Stage.VisualLogic.EntryPoint;
using Playground.Content.Stage.VisualLogic.Setup;
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
            TickablesService tickablesService = ServicesProvider.GetService<TickablesService>();
            TimeService timeService = ServicesProvider.GetService<TimeService>();
            UIViewStackService uiViewStackService = ServicesProvider.GetService<UIViewStackService>();
            ConfigurationService configurationService = ServicesProvider.GetService<ConfigurationService>();
            PersistenceService persistenceService = ServicesProvider.GetService<PersistenceService>();

            EventDispatcherAndReceiver logicToViewEventDispatcherAndReceiver = new EventDispatcherAndReceiver();
            EventDispatcherAndReceiver viewToLogicEventDispatcherAndReceiver = new EventDispatcherAndReceiver();

            TaskCompletionSource<object> stageLoadedTaskCompletionSource = new TaskCompletionSource<object>();

            ILoadingToken stageLoadedToken = new CallbackLoadingToken(() => stageLoadedTaskCompletionSource.SetResult(default));

            EventDispatcherAndReceiverTickable logicToViewTickable = new EventDispatcherAndReceiverTickable(
                logicToViewEventDispatcherAndReceiver
                );
            EventDispatcherAndReceiverTickable viewToLogicTickable = new EventDispatcherAndReceiverTickable(
                viewToLogicEventDispatcherAndReceiver
                );

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

            StageLogicEntryPoint stageLogicEntryPoint = new StageLogicEntryPoint(
                logicToViewEventDispatcherAndReceiver,
                viewToLogicEventDispatcherAndReceiver,
                logicStageSetup
                );

            StageVisualLogicEntryPoint stageVisualLogicEntryPoint = new StageVisualLogicEntryPoint(
                stageLoadedToken,
                viewToLogicEventDispatcherAndReceiver,
                logicToViewEventDispatcherAndReceiver,
                tickablesService,
                timeService,
                uiViewStackService,
                persistenceService,
                visualLogicStageSetup,
                stageContextReferences
                );
            AddCleanupAction(stageVisualLogicEntryPoint.CleanUp);

            stageLogicEntryPoint.Execute();

            tickablesService.AddTickable(logicToViewTickable);
            AddCleanupAction(() => tickablesService.RemoveTickable(logicToViewTickable));

            tickablesService.AddTickable(viewToLogicTickable);
            AddCleanupAction(() => tickablesService.RemoveTickable(viewToLogicTickable));

            return stageLoadedTaskCompletionSource.Task;
        }
    }
}
