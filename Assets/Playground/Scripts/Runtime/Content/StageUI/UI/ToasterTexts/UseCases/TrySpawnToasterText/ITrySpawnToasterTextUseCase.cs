using Juce.Core.Disposables;
using Playground.Content.StageUI.UI.ToasterTexts.Entries;
using Playground.Content.StageUI.UI.ToasterTexts.Factories;

namespace Playground.Content.StageUI.UI.ToasterTexts.UseCases.TrySpawnToasterText
{
    public interface ITrySpawnToasterTextUseCase
    {
        bool Execute(
            ToasterTextUIEntryFactoryDefinition definition,
            out IDisposable<ToasterTextUIEntry> creation
            );
    }
}
