using Playground.Configuration.DemoStages;
using Playground.Content.Stage.Configuration;

namespace Playground.Content.Meta.UI.DemoStages
{
    public class SpawnDemoStagesUseCase : ISpawnDemoStagesUseCase
    {
        private readonly DemoStagesConfiguration demoStagesConfiguration;
        private readonly ISpawnDemoStageUseCase spawnDemoStageUseCase;

        public SpawnDemoStagesUseCase(
            DemoStagesConfiguration demoStagesConfiguration,
            ISpawnDemoStageUseCase spawnDemoStageUseCase
            )
        {
            this.demoStagesConfiguration = demoStagesConfiguration;
            this.spawnDemoStageUseCase = spawnDemoStageUseCase;
        }

        public void Execute()
        {
            foreach(StageConfiguration stageConfiguration in demoStagesConfiguration.StageConfigurations)
            {
                spawnDemoStageUseCase.Execute(stageConfiguration);
            }
        }
    }
}
