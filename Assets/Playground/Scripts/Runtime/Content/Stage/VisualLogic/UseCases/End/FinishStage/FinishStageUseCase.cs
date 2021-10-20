using Juce.Core.Time;
using Playground.Configuration.Stage;
using Playground.Content.Stage.UseCases.StageFinished;
using Playground.Content.Stage.VisualLogic.UseCases.SetDirectionSelectorUIVisible;
using Playground.Content.Stage.VisualLogic.UseCases.SetEffectsUIVisible;
using Playground.Content.Stage.VisualLogic.UseCases.SetPointsUIVisible;
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
        private readonly ISetActionInputDetectionUIVisibleUseCase setActionInputDetectionUIVisibleUseCase;
        private readonly ISetDirectionSelectorUIVisibleUseCase setDirectionSelectorUIVisibleUseCase;
        private readonly ISetEffectsUIVisibleUseCase setEffectsUIVisibleUseCase;
        private readonly ISetPointsUIVisibleUseCase setPointsUIVisibleUseCase;
        private readonly IStageFinishedUseCase stageFinishedUseCase;

        public FinishStageUseCase(
            StageSettings stageSettings,
            ITimer timer,
            ISetActionInputDetectionUIVisibleUseCase setActionInputDetectionUIVisibleUseCase,
            ISetDirectionSelectorUIVisibleUseCase setDirectionSelectorUIVisibleUseCase,
            ISetEffectsUIVisibleUseCase setEffectsUIVisibleUseCase,
            ISetPointsUIVisibleUseCase setPointsUIVisibleUseCase,
            IStageFinishedUseCase stageFinishedUseCase
            )
        {
            this.stageSettings = stageSettings;
            this.timer = timer;
            this.setActionInputDetectionUIVisibleUseCase = setActionInputDetectionUIVisibleUseCase;
            this.setDirectionSelectorUIVisibleUseCase = setDirectionSelectorUIVisibleUseCase;
            this.setEffectsUIVisibleUseCase = setEffectsUIVisibleUseCase;
            this.setPointsUIVisibleUseCase = setPointsUIVisibleUseCase;
            this.stageFinishedUseCase = stageFinishedUseCase;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            setActionInputDetectionUIVisibleUseCase.Execute(
                visible: false,
                instantly: true,
                cancellationToken
                ).RunAsync();

            await Task.WhenAll(
                setDirectionSelectorUIVisibleUseCase.Execute(
                    visible: false,
                    instantly: false,
                    cancellationToken
                    ),
                setEffectsUIVisibleUseCase.Execute(
                    visible: false,
                    instantly: false,
                    cancellationToken
                    ),
                setPointsUIVisibleUseCase.Execute(
                    visible: false,
                    instantly: false,
                    cancellationToken
                    )
                );

            timer.Start();
            await timer.AwaitReach(TimeSpan.FromSeconds(stageSettings.DelayOnStageFinished), cancellationToken);

            stageFinishedUseCase.Execute();
        }
    }
}
