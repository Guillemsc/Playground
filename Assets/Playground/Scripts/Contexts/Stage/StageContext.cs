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
using Playground.Utils.Addressable;
using System.Threading.Tasks;
using UnityEngine;

namespace Playground.Contexts
{
    public class StageContext : Context
    {
        public readonly static string SceneName = "StageContext";

        [SerializeField] private StageContextReferences stageContextReferences;

        private StageUIContext stageUIContext;
        private StageConfiguration stageConfiguration;

        private EventDispatcherAndReceiverTickable logicToViewTickable;
        private EventDispatcherAndReceiverTickable viewToLogicTickable;

        private IDisposable<GameObject> stageAddressable; 

        protected override void Init()
        {
            ContextsProvider.Register(this);
        }

        protected override void CleanUp()
        {
            TickablesService tickablesService = ServicesProvider.GetService<TickablesService>();

            tickablesService.RemoveTickable(logicToViewTickable);
            tickablesService.RemoveTickable(viewToLogicTickable);

            if (stageAddressable != null)
            {
                stageAddressable.Dispose();
            }

            ContextsProvider.Unregister(this);
        }

        public async Task RunStage(
            StageUIContext stageUIContext,
            StageConfiguration stageConfiguration, 
            ILoadingToken loadingToken
            )
        {
            this.stageConfiguration = stageConfiguration;

            await LoadStageAddressable();
  
            StageView stageViewPrefab = stageAddressable.Value.GetComponent<StageView>();

            bool created = new CheckPointsRepositoryFactory().Create(
                stageViewPrefab.CheckPointsView, 
                out CheckPointRepository checkPointRepository
                );

            if(!created)
            {
                UnityEngine.Debug.LogError($"Could not create {nameof(CheckPointRepository)}");
                return;
            }

            TickablesService tickablesService = ServicesProvider.GetService<TickablesService>();
            TimeService timeService = ServicesProvider.GetService<TimeService>();

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
                stageUIContext.StageUIContextReferences.ScreenCarControlsUIView,
                stageUIContext.StageUIContextReferences.StageOverlayUIView,
                stageUIContext.StageUIContextReferences.StageCompletedUIView,
                stageViewPrefab,
                stageContextReferences.CarLibrary,
                stageContextReferences.FollowCarVirtualCamera
                );

            stageLogicEntryPoint.Execute();

            tickablesService.AddTickable(logicToViewTickable);
            tickablesService.AddTickable(viewToLogicTickable);
        }

        private async Task LoadStageAddressable()
        {
            if(stageAddressable != null)
            {
                return;
            }

            if(stageConfiguration == null)
            {
                UnityEngine.Debug.LogError($"Null {nameof(StageConfiguration)} at {nameof(StageContext)}");
            }

            stageAddressable = await AddressablesUtils.Load<GameObject>(stageConfiguration.AssetReference);

            if (stageAddressable == null)
            {
                UnityEngine.Debug.LogError($"Stage with path {stageConfiguration.AssetReference} could not be found");
            }
        }
    }
}
