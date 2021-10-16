using Juce.Core.Disposables;
using Playground.Content.StageUI.UI.Effects.Entries;

namespace Playground.Content.StageUI.UI.Effects.UseCases.TrySpawnEffectEntry
{
    public interface ITrySpawnEffectEntryUseCase
    {
        bool Execute(out IDisposable<EffectUIEntry> result);
    }
}
