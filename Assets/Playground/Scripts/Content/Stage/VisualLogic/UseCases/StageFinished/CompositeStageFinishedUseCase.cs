namespace Playground.Content.Stage.VisualLogic.UseCases
{
    public class CompositeStageFinishedUseCase : IStageFinishedUseCase
    {
        private readonly IStageFinishedUseCase[] useCases;

        public CompositeStageFinishedUseCase(IStageFinishedUseCase[] useCases)
        {
            this.useCases = useCases;
        }

        public void Execute()
        {
            foreach(IStageFinishedUseCase useCase in useCases)
            {
                useCase.Execute();
            }
        }
    }
}
