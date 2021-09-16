using Juce.Core.Events;
using Juce.Core.Loading;
using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.Services;
using Playground.Content.Stage.Logic.EntryPoint;
using Playground.Content.Stage.Logic.Setup;
using Playground.Content.Stage.Setup;
using Playground.Content.Stage.VisualLogic.EntryPoint;
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
        }

        protected override void CleanUp()
        {
            ContextsProvider.Unregister(this);
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
                new LogicShipSetup(stageSetup.ShipSetup.TypeId)
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
                persistenceService
                );

            stageLogicEntryPoint.Execute();

            tickablesService.AddTickable(logicToViewTickable);
            tickablesService.AddTickable(viewToLogicTickable);

            return stageLoadedTaskCompletionSource.Task;
        }

        //    public void RunStage(
        //        StageUIContext stageUIContext,
        //        StageView stageView,
        //        StageStarsConfiguration stageStarsConfiguration,
        //        StageRewardsConfiguration stageRewardsConfiguration,
        //        string carTypeId,
        //        ILoadingToken loadingToken
        //        )
        //    {  
        //        bool created = new CheckPointsRepositoryFactory().Create(
        //            stageView.CheckPointsView, 
        //            out CheckPointRepository checkPointRepository
        //            );

        //        if(!created)
        //        {
        //            UnityEngine.Debug.LogError($"Could not create {nameof(CheckPointRepository)}, at {nameof(StageContext)}");
        //            return;
        //        }

        //        TickablesService tickablesService = ServicesProvider.GetService<TickablesService>();
        //        TimeService timeService = ServicesProvider.GetService<TimeService>();
        //        UIViewStackService uiViewStackService = ServicesProvider.GetService<UIViewStackService>();
        //        ConfigurationService configurationService = ServicesProvider.GetService<ConfigurationService>();
        //        PersistenceService userService = ServicesProvider.GetService<PersistenceService>();
        //        SharedService sharedService = ServicesProvider.GetService<SharedService>();

        //        PauseStageService pauseStageService = new PauseStageService(timeService);
        //        ServicesProvider.Register(pauseStageService);
        //        cleanUpActionsRepository.Add(() => ServicesProvider.Unregister(pauseStageService));

        //        EventDispatcherAndReceiver logicToViewEventDispatcherAndReceiver = new EventDispatcherAndReceiver();
        //        EventDispatcherAndReceiver viewToLogicEventDispatcherAndReceiver = new EventDispatcherAndReceiver();

        //        EventDispatcherAndReceiverTickable logicToViewTickable = new EventDispatcherAndReceiverTickable(
        //            logicToViewEventDispatcherAndReceiver
        //            );
        //        EventDispatcherAndReceiverTickable viewToLogicTickable = new EventDispatcherAndReceiverTickable(
        //            viewToLogicEventDispatcherAndReceiver
        //            );

        //        StageLogicEntryPoint stageLogicEntryPoint = new StageLogicEntryPoint(
        //            logicToViewEventDispatcherAndReceiver,
        //            viewToLogicEventDispatcherAndReceiver,
        //            checkPointRepository
        //            );

        //        StageVisualLogicEntryPoint stageVisualLogicEntryPoint = new StageVisualLogicEntryPoint(
        //            loadingToken,
        //            viewToLogicEventDispatcherAndReceiver,
        //            logicToViewEventDispatcherAndReceiver,
        //            tickablesService,
        //            timeService,
        //            uiViewStackService,
        //            userService,
        //            sharedService,
        //            stageUIContext.StageUIContextReferences.ScreenCarControlsUIView,
        //            stageUIContext.StageUIContextReferences.StageOverlayUIView,
        //            stageUIContext.StageUIContextReferences.StageCompletedUIView,
        //            stageView,
        //            stageStarsConfiguration,
        //            stageRewardsConfiguration,
        //            configurationService.CarLibrary,
        //            carTypeId,
        //            stageContextReferences.FollowCarVirtualCamera,
        //            cleanUpActionsRepository
        //            );

        //        stageLogicEntryPoint.Execute();

        //        tickablesService.AddTickable(logicToViewTickable);
        //        cleanUpActionsRepository.Add(() => tickablesService.RemoveTickable(logicToViewTickable));

        //        tickablesService.AddTickable(viewToLogicTickable);
        //        cleanUpActionsRepository.Add(() => tickablesService.RemoveTickable(viewToLogicTickable));
        //    }
    }
}
