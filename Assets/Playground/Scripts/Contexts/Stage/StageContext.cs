using Juce.Core.Disposables;
using Juce.Core.Events;
using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.Services;
using Playground.Content.LoadingScreen.UI;
using Playground.Content.Stage.Configuration;
using Playground.Content.Stage.Logic.CheckPoints;
using Playground.Content.Stage.Logic.EntryPoint;
using Playground.Content.Stage.Setup;
using Playground.Content.Stage.VisualLogic.EntryPoint;
using Playground.Content.Stage.VisualLogic.View.Stage;
using Playground.Services;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Contexts
{
    public class StageContext : Context
    {
        public readonly static string SceneName = "StageContext";

        [SerializeField] private StageContextReferences stageContextReferences;

        private StageUIContext stageUIContext;

        private EventDispatcherAndReceiverTickable logicToViewTickable;
        private EventDispatcherAndReceiverTickable viewToLogicTickable;

        protected override void Init()
        {
            ContextsProvider.Register(this);
        }

        protected override void CleanUp()
        {
            TickablesService tickablesService = ServicesProvider.GetService<TickablesService>();

            tickablesService.RemoveTickable(logicToViewTickable);
            tickablesService.RemoveTickable(viewToLogicTickable);

            ContextsProvider.Unregister(this);
        }

        public void RunStage(
            StageUIContext stageUIContext,
            StageView stageView, 
            ILoadingToken loadingToken
            )
        {  
            bool created = new CheckPointsRepositoryFactory().Create(
                stageView.CheckPointsView, 
                out CheckPointRepository checkPointRepository
                );

            if(!created)
            {
                UnityEngine.Debug.LogError($"Could not create {nameof(CheckPointRepository)}, at {nameof(StageContext)}");
                return;
            }

            TickablesService tickablesService = ServicesProvider.GetService<TickablesService>();
            TimeService timeService = ServicesProvider.GetService<TimeService>();
            UIViewStackService uiViewStackService = ServicesProvider.GetService<UIViewStackService>();

            EventDispatcherAndReceiver logicToViewEventDispatcherAndReceiver = new EventDispatcherAndReceiver();
            EventDispatcherAndReceiver viewToLogicEventDispatcherAndReceiver = new EventDispatcherAndReceiver();

            logicToViewTickable = new EventDispatcherAndReceiverTickable(logicToViewEventDispatcherAndReceiver);
            viewToLogicTickable = new EventDispatcherAndReceiverTickable(viewToLogicEventDispatcherAndReceiver);

            StageLogicEntryPoint stageLogicEntryPoint = new StageLogicEntryPoint(
                logicToViewEventDispatcherAndReceiver,
                viewToLogicEventDispatcherAndReceiver,
                checkPointRepository
                );

            StageVisualLogicEntryPoint stageVisualLogicEntryPoint = new StageVisualLogicEntryPoint(
                loadingToken,
                viewToLogicEventDispatcherAndReceiver,
                logicToViewEventDispatcherAndReceiver,
                timeService,
                uiViewStackService,
                stageUIContext.StageUIContextReferences.ScreenCarControlsUIView,
                stageUIContext.StageUIContextReferences.StageOverlayUIView,
                stageUIContext.StageUIContextReferences.StageCompletedUIView,
                stageView,
                stageContextReferences.CarLibrary,
                stageContextReferences.FollowCarVirtualCamera
                );

            stageLogicEntryPoint.Execute();

            tickablesService.AddTickable(logicToViewTickable);
            tickablesService.AddTickable(viewToLogicTickable);
        }
    }
}
