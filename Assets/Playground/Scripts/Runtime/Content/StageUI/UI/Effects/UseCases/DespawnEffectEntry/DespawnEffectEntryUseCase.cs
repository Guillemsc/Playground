using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Playground.Content.StageUI.UI.Effects.Entries;

namespace Playground.Content.StageUI.UI.Effects.UseCases.DespawnEffectEntry
{
    public class DespawnEffectEntryUseCase : IDespawnEffectEntryUseCase
    {
        private readonly IRepository<IDisposable<EffectUIEntry>> repository;

        public DespawnEffectEntryUseCase(
            IRepository<IDisposable<EffectUIEntry>> repository
            )
        {
            this.repository = repository;
        }

        public void Execute(IDisposable<EffectUIEntry> entry)
        {
            repository.Remove(entry);

            entry.Dispose();
        }
    }
}
