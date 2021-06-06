namespace Playground.Content.Meta.UI.DemoStages
{
    public class DemoStagesUIUseCases
    {
        public ISpawnDemoStageUseCase SpawnDemoStageUseCase { get; }
        public ISpawnDemoStagesUseCase SpawnDemoStagesUseCase { get; }

        public DemoStagesUIUseCases(
            ISpawnDemoStageUseCase spawnDemoStageUseCase,
            ISpawnDemoStagesUseCase spawnDemoStagesUseCase
            )
        {
            SpawnDemoStageUseCase = spawnDemoStageUseCase;
            SpawnDemoStagesUseCase = spawnDemoStagesUseCase;
        }
    }
}
