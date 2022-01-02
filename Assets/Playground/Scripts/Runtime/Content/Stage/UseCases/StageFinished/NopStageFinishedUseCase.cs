namespace Playground.Content.Stage.UseCases.StageFinished
{
    public class NopStageFinishedUseCase : IStageFinishedUseCase
    {
        public static readonly NopStageFinishedUseCase Instance = new NopStageFinishedUseCase();

        private NopStageFinishedUseCase()
        {

        }

        public void Execute(int currentPoints)
        {

        }
    }
}
