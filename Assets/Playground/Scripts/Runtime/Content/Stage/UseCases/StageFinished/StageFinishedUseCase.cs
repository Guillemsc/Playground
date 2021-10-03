using System;

namespace Playground.Content.Stage.UseCases.StageFinished
{
    public class StageFinishedUseCase : IStageFinishedUseCase
    {
        private readonly Action onStageFinished;

        public StageFinishedUseCase(Action onStageFinished)
        {
            this.onStageFinished = onStageFinished;
        }

        public void Execute()
        {
            onStageFinished?.Invoke();
        }
    }
}
