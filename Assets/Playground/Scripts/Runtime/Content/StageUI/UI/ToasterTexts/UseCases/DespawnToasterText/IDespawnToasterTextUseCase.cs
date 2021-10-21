using Juce.Core.Disposables;
using Playground.Content.StageUI.UI.ToasterTexts.Entries;

namespace Playground.Content.StageUI.UI.ToasterTexts.UseCases.DespawnToasterText
{
    public interface IDespawnToasterTextUseCase
    {
        void Execute(IDisposable<ToasterTextUIEntry> toasterText);
    }
}
