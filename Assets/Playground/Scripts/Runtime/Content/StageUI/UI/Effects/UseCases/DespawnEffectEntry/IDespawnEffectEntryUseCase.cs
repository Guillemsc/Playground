using Juce.Core.Disposables;
using Playground.Content.StageUI.UI.Effects.Entries;

namespace Playground.Content.StageUI.UI.Effects.UseCases.DespawnEffectEntry
{
    public interface IDespawnEffectEntryUseCase
    {
        void Execute(IDisposable<EffectUIEntry> entry);
    }
}
