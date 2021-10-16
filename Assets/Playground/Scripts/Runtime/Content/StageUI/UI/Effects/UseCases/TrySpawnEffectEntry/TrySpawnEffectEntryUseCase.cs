using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;
using Playground.Content.StageUI.UI.Effects.Entries;
using Playground.Content.StageUI.UI.Effects.Factories;

namespace Playground.Content.StageUI.UI.Effects.UseCases.TrySpawnEffectEntry
{
    public class TrySpawnEffectEntryUseCase : ITrySpawnEffectEntryUseCase
    {
        private readonly IFactory<EffectUIEntryFactoryDefinition, IDisposable<EffectUIEntry>> factory;
        private readonly IRepository<IDisposable<EffectUIEntry>> repository;

        public TrySpawnEffectEntryUseCase(
            IFactory<EffectUIEntryFactoryDefinition, IDisposable<EffectUIEntry>> factory,
            IRepository<IDisposable<EffectUIEntry>> repository
            )
        {
            this.factory = factory;
            this.repository = repository;
        }

        public bool Execute(out IDisposable<EffectUIEntry> result)
        {
            bool created = factory.TryCreate(
                new EffectUIEntryFactoryDefinition(),
                out result
                );

            if(!created)
            {
                return false;
            }

            repository.Add(result);

            return true;
        }
    }
}
