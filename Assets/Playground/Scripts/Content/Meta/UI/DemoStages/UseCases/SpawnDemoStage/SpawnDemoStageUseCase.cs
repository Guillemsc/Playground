using Juce.Core.Disposables;
using System.IO;

namespace Playground.Content.Stage.VisualLogic.UI.DemoStages
{
    public class SpawnDemoStageUseCase : ISpawnDemoStageUseCase
    {
        private readonly DemoStageButtonUIEntryFactory demoStageButtonUIEntryFactory;
        private readonly DemoStageButtonUIEntryRepository demoStageButtonUIEntryRepository;

        public SpawnDemoStageUseCase(
            DemoStageButtonUIEntryFactory demoStageButtonUIEntryFactory,
            DemoStageButtonUIEntryRepository demoStageButtonUIEntryRepository
            )
        {
            this.demoStageButtonUIEntryFactory = demoStageButtonUIEntryFactory;
            this.demoStageButtonUIEntryRepository = demoStageButtonUIEntryRepository;
        }

        public void Execute(string stageScenePath)
        {
            string sceneName = Path.GetFileNameWithoutExtension(stageScenePath);

            IDisposable<DemoStageButtonUIEntry> instance = demoStageButtonUIEntryFactory.Create(sceneName);

            demoStageButtonUIEntryRepository.Add(instance);
        }
    }
}
