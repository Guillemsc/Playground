using Juce.Core.Time;
using Playground.Configuration.Stage;
using Playground.Content.Stage.UseCases.StageFinished;
using Playground.Content.Stage.VisualLogic.State;
using Playground.Content.Stage.VisualLogic.UseCases.SetMainStageUIVisible;
using Playground.Content.Stage.VisualLogic.UseCases.SetupCamera;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.FinishStage
{
    public class FinishStageUseCase : IFinishStageUseCase
    {
        private readonly StageSettings stageSettings;
        private readonly ITimer timer;
        private readonly PointsState pointsState;
        private readonly ISetActionInputDetectionUIVisibleUseCase setActionInputDetectionUIVisibleUseCase;
        private readonly ISetMainStageUIVisibleUseCase setMainStageUIVisibleUseCase;
        private readonly IStageFinishedUseCase stageFinishedUseCase;

        public FinishStageUseCase(
            StageSettings stageSettings,
            ITimer timer,
            PointsState pointsState,
            ISetActionInputDetectionUIVisibleUseCase setActionInputDetectionUIVisibleUseCase,
            ISetMainStageUIVisibleUseCase setMainStageUIVisibleUseCase,
            IStageFinishedUseCase stageFinishedUseCase
            )
        {
            this.stageSettings = stageSettings;
            this.timer = timer;
            this.pointsState = pointsState;
            this.setActionInputDetectionUIVisibleUseCase = setActionInputDetectionUIVisibleUseCase;
            this.setMainStageUIVisibleUseCase = setMainStageUIVisibleUseCase;
            this.stageFinishedUseCase = stageFinishedUseCase;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            setActionInputDetectionUIVisibleUseCase.Execute(
                visible: false,
                instantly: true,
                cancellationToken
                ).RunAsync();

            await setMainStageUIVisibleUseCase.Execute(
                visible: false,
                instantly: false,
                cancellationToken
                );

            timer.Start();
            await timer.AwaitReach(TimeSpan.FromSeconds(stageSettings.DelayOnStageFinished), cancellationToken);

            stageFinishedUseCase.Execute(pointsState.CurrentPoints);
        }
    }
}
