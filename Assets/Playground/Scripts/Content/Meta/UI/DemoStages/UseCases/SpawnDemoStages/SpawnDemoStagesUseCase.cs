using Playground.Configuration.DemoStages;

namespace Playground.Content.Stage.VisualLogic.UI.DemoStages
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
            foreach(SceneReference sceneReference in demoStagesConfiguration.StagesScenes)
            {
                spawnDemoStageUseCase.Execute(sceneReference.ScenePath);
            }
        }
    }
}
