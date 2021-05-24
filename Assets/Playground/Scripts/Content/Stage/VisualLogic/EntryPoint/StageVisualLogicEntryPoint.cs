using Cinemachine;
using Juce.Core.Events;
using Juce.Core.Sequencing;
using Playground.Content.LoadingScreen.UI;
using Playground.Content.Stage.Libraries;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.VisualLogic.UseCases;
using Playground.Content.Stage.VisualLogic.View.Car;
using Playground.Content.Stage.VisualLogic.View.CheckPoints;
using Playground.Content.Stage.VisualLogic.View.Signals;
using Playground.Content.Stage.VisualLogic.View.Stage;
using Playground.Services;

namespace Playground.Content.Stage.VisualLogic.EntryPoint
{
    public class StageVisualLogicEntryPoint
    {
        private readonly ILoadingToken loadingToken;
        private readonly IEventDispatcher eventDispatcher;
        private readonly IEventReceiver eventReceiver;
        private readonly TimeService timeService;
        private readonly StageView stageViewPrefab;
        private readonly CarLibrary carLibrary;
        private readonly CinemachineVirtualCamera followCarVirtualCamera;

        public StageVisualLogicEntryPoint(
            ILoadingToken loadingToken,
            IEventDispatcher eventDispatcher,
            IEventReceiver eventReceiver,
            TimeService timeService,
            StageView stageViewPrefab,
            CarLibrary carLibrary,
            CinemachineVirtualCamera followCarVirtualCamera
            )
        {
            this.loadingToken = loadingToken;
            this.eventDispatcher = eventDispatcher;
            this.eventReceiver = eventReceiver;
            this.timeService = timeService;
            this.stageViewPrefab = stageViewPrefab;
            this.carLibrary = carLibrary;
            this.followCarVirtualCamera = followCarVirtualCamera;

            Sequencer sequencer = new Sequencer();

            StageViewRepository stageViewRepository = new StageViewRepository();
            CarViewRepository carViewRepository = new CarViewRepository();

            GenericSignal<CheckPointsView, CheckPointView> checkPointCrossedSignal = new GenericSignal<CheckPointsView, CheckPointView>();

            UseCasesRepository useCasesRepository = new UseCasesRepository(
                new LoadStageUseCase(
                    sequencer,
                    timeService,
                    carLibrary,
                    carViewRepository,
                    stageViewRepository,
                    stageViewPrefab,
                    checkPointCrossedSignal,
                    followCarVirtualCamera,
                    loadingToken
                    ),

                new CheckPointCrossedUseCase(
                    eventDispatcher
                    ),

                new CurrentCheckPointChangedUseCase(
                    sequencer,
                    stageViewRepository
                    ),

                new StageFinishedUseCase()
                );

            eventReceiver.Subscribe((LoadStageOutEvent ev) =>
            {
                useCasesRepository.LoadStageUseCase.Execute();
            });

            eventReceiver.Subscribe((CurrentCheckPointChangedOutEvent ev) =>
            {
                useCasesRepository.CurrentCheckPointChangedUseCase.Execute(ev.CheckPointIndex);
            });

            eventReceiver.Subscribe((StageFinishedOutEvent ev) =>
            {
                useCasesRepository.StageFinishedUseCase.Execute();
            });

            checkPointCrossedSignal.OnTrigger += (CheckPointsView checkPointsView, CheckPointView checkPointView) =>
            {
                useCasesRepository.CheckPointCrossedUseCase.Execute(checkPointView);
            };
        }
    }
}
