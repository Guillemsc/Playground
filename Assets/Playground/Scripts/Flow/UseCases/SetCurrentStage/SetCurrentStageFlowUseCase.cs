using Playground.Content.Stage.Configuration;
using Playground.Flow.Data;

namespace Playground.Flow.UseCases
{
    public class SetCurrentStageFlowUseCase : ISetCurrentStageFlowUseCase
    {
        private readonly CurrentStageFlowData currentStageFlowData;

        public SetCurrentStageFlowUseCase(CurrentStageFlowData currentStageFlowData)
        {
            this.currentStageFlowData = currentStageFlowData;
        }

        public void Execute(StageConfiguration stageConfiguration)
        {
            currentStageFlowData.StageConfiguration = stageConfiguration;
        }
    }
}
