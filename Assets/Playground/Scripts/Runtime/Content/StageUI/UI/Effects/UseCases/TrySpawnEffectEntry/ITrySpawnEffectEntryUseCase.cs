using Juce.Core.Disposables;
using Playground.Content.StageUI.UI.Effects.Entries;
using Playground.Content.StageUI.UI.Effects.Factories;

namespace Playground.Content.StageUI.UI.Effects.UseCases.TrySpawnEffectEntry
{
    public interface ITrySpawnEffectEntryUseCase
    {
        bool Execute(
            EffectUIEntryFactoryDefinition effectUIEntryFactoryDefinition,
            out IDisposable<EffectUIEntry> result
            );
    }
}
