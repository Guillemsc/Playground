using Playground.Configuration.Stage;

namespace Playground.Flow.UseCases
{
    public interface ISetCurrentStageFlowUseCase
    {
        void Execute(StageConfiguration stageConfiguration);
    }
}
