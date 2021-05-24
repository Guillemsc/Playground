using Playground.Content.Stage.Logic.State;

namespace Playground.Content.Stage.Logic.UseCases
{
    public class IsStageCompletedUseCase : IIsStageCompletedUseCase
    {
        private readonly StageState stageState;

        public IsStageCompletedUseCase(StageState stageState)
        {
            this.stageState = stageState;
        }

        public bool Execute()
        {
            return stageState.Completed;
        }
    }
}
