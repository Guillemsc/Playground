using Juce.Core.Sequencing;
using Playground.Configuration.Stage;
using Playground.Content.Shared;
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
        private readonly SharedUseCases sharedUseCases;
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
            SharedUseCases sharedUseCases,
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
            this.sharedUseCases = sharedUseCases;
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
            StageView stageView = stageViewRepository.Item;
            CarView carView = carViewRepository.Item;

            new SetStageTimerPlayingInstruction(
                stageTimerState,
                playing: false
                ).Execute();

            await stopCarAndHideUISequence.Execute(cancellationToken);

            await new WaitTimeInstruction(timeService.UnscaledTimeContext, TimeSpan.FromSeconds(1.0f)).Execute(cancellationToken);

            int stars = GetStars();
            int softCurrenctyReward = GetSoftCurrencyReward(stars);

            StageCompletedUIInteractor stageCompletedUIInteractor = uiViewStackService.GetInteractor<StageCompletedUIInteractor>();
            stageCompletedUIInteractor.RegisterToCanUnloadStage(OnCanUnloadStageSignalTriggered);

            stageCompletedUIInteractor.SetTime(stageTimerState.Timer.Time);

            await new SetUIViewVisibleInstruction<StageCompletedUIView>(uiViewStackService, visible: true, instantly: false).Execute(cancellationToken);

            stageCompletedUIInteractor.SetStars(stars);

            await sharedUseCases.SetStageCarStarsUseCase.Execute(stageView.TypeId, carView.TypeId, stars, cancellationToken);

            await taskCompletitionSource.Task;

            stageCompletedUIInteractor.UnregisterToCanUnloadStage(OnCanUnloadStageSignalTriggered);
        }

        private void OnCanUnloadStageSignalTriggered()
        {
            taskCompletitionSource.SetResult(null);
        }

        private int GetStars()
        {
            if(stageStarsConfiguration == null)
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

            float finalTime = (float)stageTimerState.Timer.Time.TotalSeconds;

            return sharedUseCases.GetStageStarsFromTimingUseCase.Execute(
                stageStarsConfiguration,
                carViewRepository.Item.TypeId,
                finalTime
                );
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
