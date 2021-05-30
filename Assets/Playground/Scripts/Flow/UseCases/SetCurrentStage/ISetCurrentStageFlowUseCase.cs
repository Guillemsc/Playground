using Playground.Content.Stage.Configuration;

namespace Playground.Flow.UseCases
{
    public interface ISetCurrentStageFlowUseCase
    {
        void Execute(StageConfiguration stageConfiguration);
    }
}
