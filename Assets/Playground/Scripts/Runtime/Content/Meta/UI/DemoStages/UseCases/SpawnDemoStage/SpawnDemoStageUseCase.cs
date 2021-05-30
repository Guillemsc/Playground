using Juce.Core.Disposables;
using Playground.Content.Stage.Configuration;
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

        public void Execute(StageConfiguration stageConfiguration)
        {
            IDisposable<DemoStageButtonUIEntry> instance = demoStageButtonUIEntryFactory.Create(stageConfiguration);

            demoStageButtonUIEntryRepository.Add(instance);
        }
    }
}
