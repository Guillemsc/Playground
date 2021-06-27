using Juce.Core.Sequencing;
using Playground.Configuration.Stage;
using Playground.Content.Stage.VisualLogic.Instructions;
using Playground.Content.Stage.VisualLogic.Sequences;
using Playground.Content.Stage.VisualLogic.View.Car;
using Playground.Content.Stage.VisualLogic.View.Signals;
using Playground.Content.Stage.VisualLogic.View.Stage;
using Playground.Content.StageUI.UI.StageCompleted;
using Playground.Services;
using Playground.Services.ViewStack;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases
{
    public class StopAndShowUIStageFinishedUseCase : IStageFinishedUseCase
    {
        private readonly Sequencer sequencer;
        private readonly TimeService timeService;
        private readonly UIViewStackService uiViewStackService;
        private readonly StageStarsConfiguration stageStarsConfiguration;
        private readonly StageRewardsConfiguration stageRewardsConfiguration;
        private readonly StageCompletedUIView stageCompletedUIView;
        private readonly StageViewRepository stageViewRepository;
        private readonly CarViewRepository carViewRepository;
        private readonly StageTimerState stageTimerState;
        private readonly StopCarAndHideUISequence stopCarAndHideUISequence;

        private TaskCompletionSource<object> taskCompletitionSource = new TaskCompletionSource<object>();

        public StopAndShowUIStageFinishedUseCase(
            Sequencer sequencer,
            TimeService timeService,
            UIViewStackService uiViewStackService,
            StageStarsConfiguration stageStarsConfiguration,
            StageRewardsConfiguration stageRewardsConfiguration,
            StageCompletedUIView stageCompletedUIView,
            StageViewRepository stageViewRepository,
            CarViewRepository carViewRepository,
            StageTimerState stageTimerState,
            StopCarAndHideUISequence stopCarAndHideUISequence
            )
        {
            this.sequencer = sequencer;
            this.timeService = timeService;
            this.uiViewStackService = uiViewStackService;
            this.stageStarsConfiguration = stageStarsConfiguration;
            this.stageRewardsConfiguration = stageRewardsConfiguration;
            this.stageCompletedUIView = stageCompletedUIView;
            this.stageViewRepository = stageViewRepository;
            this.carViewRepository = carViewRepository;
            this.stageTimerState = stageTimerState;
            this.stopCarAndHideUISequence = stopCarAndHideUISequence;
        }

        public void Execute()
        {
            sequencer.Play((ct) => ExecuteSequence(ct));
        }

        private async Task ExecuteSequence(CancellationToken cancellationToken)
        {
            StageView stageView = stageViewRepository.StageView;

            new SetStageTimerPlayingInstruction(
                stageTimerState,
                playing: false
                ).Execute();

            await stopCarAndHideUISequence.Execute(cancellationToken);

            await new WaitTimeInstruction(timeService.UnscaledTimeContext, TimeSpan.FromSeconds(1.0f)).Execute(cancellationToken);

            StageCompletedUIInteractor stageCompletedUIInteractor = uiViewStackService.GetInteractor<StageCompletedUIInteractor>();
            stageCompletedUIInteractor.RegisterToCanUnloadStage(OnCanUnloadStageSignalTriggered);

            await new SetUIViewVisibleInstruction<StageCompletedUIView>(uiViewStackService, visible: true, instantly: false).Execute(cancellationToken);

            int stars = GetStars();
            int softCurrenctyReward = GetSoftCurrencyReward(stars);

            stageCompletedUIInteractor.SetStars(stars);

            await taskCompletitionSource.Task;

            stageCompletedUIInteractor.UnregisterToCanUnloadStage(OnCanUnloadStageSignalTriggered);
        }

        private void OnCanUnloadStageSignalTriggered()
        {
            taskCompletitionSource.SetResult(null);
        }

        private int GetStars()
        {
            if(stageStarsConfiguration)
            {
                UnityEngine.Debug.LogError($"Tried to get stars from timing, but {nameof(StageStarsConfiguration)} was null " +
                    $"at {nameof(StopAndShowUIStageFinishedUseCase)}");
                return 0;
            }

            if(!carViewRepository.HasItem())
            {
                UnityEngine.Debug.LogError($"Tried to get stars from timing, but {nameof(CarView)} was not " +
                    $"found on {nameof(CarViewRepository)}, at {nameof(StopAndShowUIStageFinishedUseCase)}");
                return 0;
            }

            bool stageCarStarsFound = stageStarsConfiguration.TryGet(
                carViewRepository.Item.TypeId,
                out StageStarsCarConfiguration stageStarsCarConfiguration
                );

            if(!stageCarStarsFound)
            {
                UnityEngine.Debug.LogError($"Tried to get stars from timing, but {nameof(StageStarsCarConfiguration)} was not " +
                    $"found for car {carViewRepository.Item.TypeId}. Using default, at {nameof(StopAndShowUIStageFinishedUseCase)}");
                stageStarsCarConfiguration = stageStarsConfiguration.GetDefault(carViewRepository.Item.TypeId);
            }

            float finalTime = (float)stageTimerState.Timer.Time.TotalSeconds;

            if (finalTime <= stageStarsCarConfiguration.Star3Timing)
            {
                return 3;
            }

            if (finalTime <= stageStarsCarConfiguration.Star2Timing)
            {
                return 2;
            }

            if (finalTime <= stageStarsCarConfiguration.Star1Timing)
            {
                return 1;
            }

            return 0;
        }

        private int GetSoftCurrencyReward(int stars)
        {
            if (stageRewardsConfiguration == null)
            {
                UnityEngine.Debug.LogError($"Tried to get soft currency reward, but {nameof(StageRewardsConfiguration)} was null " +
                    $"at {nameof(StopAndShowUIStageFinishedUseCase)}");
                return 0;
            }

            if (stars == 3)
            {
                return stageRewardsConfiguration.Star3SoftCurrencyReward;
            }

            if (stars == 2)
            {
                return stageRewardsConfiguration.Star2SoftCurrencyReward;
            }

            if (stars == 1)
            {
                return stageRewardsConfiguration.Star1SoftCurrencyReward;
            }

            return 0;
        }
    }
}
